using ContactManagementAPI.Models;
using System.Data.Entity;

namespace ContactManagementAPI.Tests
{
    public class TesContactAPIContext : ContactDBEntities
    {
        public TesContactAPIContext()
        {
            this.Contacts = new TestContactDbSet();
        }

        public DbSet<Contact> dbContacts { get; set; }

        public int SaveChanges()
        {
            return 0;
        }

        public void MarkAsModified(Contact item) { }
        public void Dispose() { }

    }
}
