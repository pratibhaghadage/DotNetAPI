using ContactManagementAPI.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
namespace ContactManagementAPI.Repository
{
    public class ContactRepository : IContactRepository, IDisposable
    {
        private ContactDBEntities db;

        public ContactRepository(ContactDBEntities context)
        {
            db = context;
        }
        public List<Contact> GetAllContacts()
        {
            return db.Contacts.ToList();
        }

        public Contact GetContactByID(int contactId)
        {
            return db.Contacts.Find(contactId);
        }

        public void InsertContact(Contact contact)
        {
            int? nextID = 0;
            contact.contactid = nextID.GetValueOrDefault() + 1;
            db.Contacts.Add(contact);
            db.SaveChanges();
        }

        public void UpdateContact(Contact contact)
        {
            db.Entry(contact).State = EntityState.Modified;
            db.SaveChanges();
        }

        public Contact DeleteContact(int contactId)
        {
            Contact contact = db.Contacts.Find(contactId);
            if (contact == null)
            {
                return contact;
            }
            db.Contacts.Remove(contact);
            db.SaveChanges();
            return contact;
        }

        public bool ContactExists(int id)
        {
            return db.Contacts.Count(e => e.contactid == id) > 0;
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    db.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

    }
}