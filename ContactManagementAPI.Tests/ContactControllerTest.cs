using ContactManagementAPI.Controllers;
using ContactManagementAPI.Models;
using ContactManagementAPI.Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Net;
using System.Web.Http.Results;

namespace ContactManagementAPI.Tests
{
    [TestClass]
    class ContactControllerTest
    {
        Contact GetDemoContact()
        {
            return new Contact() { contactid = 1, firstname = "Pratibha", lastname = "Ghadage", email = "pratibha@gmail.com", phone = "1234567890" };
        }

        [TestMethod]
        public void PostProduct_ShouldReturnSameProduct()
        {
            IContactRepository repo = new ContactRepository(new TesContactAPIContext());
            var controller = new ContactsController(repo);
            var item = GetDemoContact();
            var result =
                controller.PostContact(item) as CreatedAtRouteNegotiatedContentResult<Contact>;

            Assert.IsNotNull(result);
            Assert.AreEqual(result.RouteName, "DefaultApi");
            Assert.AreEqual(result.RouteValues["id"], result.Content.contactid);
            Assert.AreEqual(result.Content.firstname, item.firstname);
        }

        [TestMethod]
        public void PutProduct_ShouldReturnStatusCode()
        {
            IContactRepository repo = new ContactRepository(new TesContactAPIContext());
            var controller = new ContactsController(repo);
            var item = GetDemoContact();
            var result = controller.PutContact(item.contactid, item) as StatusCodeResult;
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(StatusCodeResult));
            Assert.AreEqual(HttpStatusCode.NoContent, result.StatusCode);
        }

        [TestMethod]
        public void PutProduct_ShouldFail_WhenDifferentID()
        {
            IContactRepository repo = new ContactRepository(new TesContactAPIContext());
            var controller = new ContactsController(repo);
            var item = GetDemoContact();
            var result = controller.PutContact(item.contactid + 1, item) as StatusCodeResult;
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(StatusCodeResult));
            Assert.AreEqual(HttpStatusCode.NoContent, result.StatusCode);
            var badresult = controller.PutContact(999, item);
            Assert.IsInstanceOfType(badresult, typeof(BadRequestResult));
        }

        [TestMethod]
        public void GetProduct_ShouldReturnProductWithSameID()
        {
            IContactRepository repo = new ContactRepository(new TesContactAPIContext());
            var controller = new ContactsController(repo);
            var resultpost =
                 controller.PostContact(GetDemoContact()) as CreatedAtRouteNegotiatedContentResult<Contact>;

            var result = controller.GetContact(1) as OkNegotiatedContentResult<Contact>;

            Assert.IsNotNull(result);
            Assert.AreEqual(1, result.Content.contactid);
        }

        [TestMethod]
        public void GetProducts_ShouldReturnAllProducts()
        {
            IContactRepository repo = new ContactRepository(new TesContactAPIContext());
            var controller = new ContactsController(repo);
            controller.PostContact(new Contact { firstname = "Samaira", lastname = "Ghadage", email = "samaira@gmail.com", phone = "9012345678" });
            controller.PostContact(new Contact { firstname = "Sharayu", lastname = "Ghadage", email = "sharayu@gmail.com", phone = "7890123456" });
            ;

            var result = controller.GetContacts();

            Assert.IsNotNull(result);
            Assert.AreEqual(3, result.Count);
        }

        [TestMethod]
        public void DeleteProduct_ShouldReturnOK()
        {
            IContactRepository repo = new ContactRepository(new TesContactAPIContext());
            var controller = new ContactsController(repo);
            var item = GetDemoContact();

            var result = controller.DeleteContact(1) as OkNegotiatedContentResult<Contact>;

            Assert.IsNotNull(result);
            Assert.AreEqual(item.contactid + 1, result.Content.contactid);

        }

    }
}
