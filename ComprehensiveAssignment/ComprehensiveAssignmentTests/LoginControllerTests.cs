using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ComprehensiveAssignment;
using System.Text;
using System.Security.Cryptography;
using ComprehensiveAssignment.Controllers;

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

            //var hashedPassword = LoginController.HashPassword(myPassword);
        }
    }
}
