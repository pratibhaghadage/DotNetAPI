
using System.Collections.Generic;
using ContactManagementAPI.Models;

namespace ContactManagementAPI.Repository
{
    public interface IContactRepository
    {
        List<Contact> GetAllContacts();
        Contact GetContactByID(int contactId);
        void InsertContact(Contact contact);
        Contact DeleteContact(int contactId);
        void UpdateContact(Contact contact);
        bool ContactExists(int id);
    }
}
