using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ComprehensiveAssignment;
using System.Text;
using System.Security.Cryptography;
using ComprehensiveAssignment.Controllers;
using System.Linq;
using System.Web.Mvc;
using ComprehensiveAssignment.Models;

namespace ComprehensiveAssignmentTests
{
    [TestClass]
    public class LoginControllerTests
    {
        [TestMethod]
        public void HashPasswordCorrectlyHashesPasswords()
        {
            string myPassword = "P@ssw0rd!";
            byte[] data = Encoding.UTF8.GetBytes(myPassword);
            byte[] hash = SHA256.Create().ComputeHash(data);

            var hashedPassword = LoginController.HashPassword(myPassword);

            Assert.IsTrue(hash.SequenceEqual(hashedPassword));     
        }

        [TestMethod]
        public void TestIndexView()
        {
            var controller = new LoginController();
            var result = controller.Index() as ViewResult;
            Assert.AreEqual("Index", result.ViewName);
        }
        

        [TestMethod]
        public void GetUserLogicRetrievesUserFromTheDatabase()
        {
            AdoTickrModel db = new AdoTickrModel();

            var user = new User()
            {
                Email = "bob@gmail.com",
                Password = "bobby"
            };

            string password = user.Password;

            var hashedPassword = LoginController.HashPassword(password);

            //Turn password into a string to match type that password is stored in the database.
            var retrievedPassword = Encoding.UTF8.GetString(hashedPassword);

            // Find the user from the database where their email and password matched.
            var retrievedUser = db.Users.Where(i => i.Email == user.Email && i.Password == retrievedPassword).FirstOrDefault();

            Assert.AreEqual("Bob", retrievedUser.FirstName);

            Assert.AreEqual("Thornton", retrievedUser.LastName);
        }
    }
}
