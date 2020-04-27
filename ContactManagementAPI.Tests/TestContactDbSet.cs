using ContactManagementAPI.Models;
using System.Linq;

namespace ContactManagementAPI.Tests
{
    class TestContactDbSet : TestDbSet<Contact>
    {
        public override Contact Find(params object[] keyValues)
        {
            return this.SingleOrDefault(contact => contact.contactid == (int)keyValues.Single() + 1);
        }
    }
}
