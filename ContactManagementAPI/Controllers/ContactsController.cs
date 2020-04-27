using ContactManagementAPI.Models;
using ContactManagementAPI.Repository;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Net;
using System.Web.Http;
using System.Web.Http.Description;


namespace ContactManagementAPI.Controllers
{
    public class ContactsController : ApiController
    {
        private IContactRepository repository;

        public ContactsController(IContactRepository repo)
        {
            repository = new ContactRepository(new ContactDBEntities());
        }
        // GET: api/Contacts
        public List<Contact> GetContacts()
        {
            return repository.GetAllContacts();
        }

        // GET: api/Contacts/5
        [ResponseType(typeof(Contact))]
        public IHttpActionResult GetContact(int id)
        {
            Contact contact = repository.GetContactByID(id);
            if (contact == null)
            {
                return NotFound();
            }
            return Ok(contact);
        }

        // PUT: api/Contacts/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutContact(int id, Contact contact)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != contact.contactid)
            {
                return BadRequest();
            }
            try
            {
                repository.UpdateContact(contact);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!repository.ContactExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Contacts
        [ResponseType(typeof(Contact))]
        public IHttpActionResult PostContact(Contact contact)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            repository.InsertContact(contact);
            return CreatedAtRoute("DefaultApi", new { id = contact.contactid }, contact);
        }

        // DELETE: api/Contacts/5
        [ResponseType(typeof(Contact))]
        public IHttpActionResult DeleteContact(int id)
        {
            Contact contact = repository.DeleteContact(id);
            if (contact == null)
            {
                return NotFound();
            }
            return Ok(contact);
        }

    }
}
