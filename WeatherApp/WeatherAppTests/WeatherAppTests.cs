using Microsoft.VisualStudio.TestTools.UnitTesting;
using WeatherApp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherApp
{
    [TestClass()]
    public  class ProgramTests
    {
        [TestMethod()]
        public void AccountCreationTest()
        {
            string newUsername = "testName";
            string newPassword = "testPass" ;
            byte[] hashedPassword;
            bool isVerified = false;
            var entry = new Dictionary<string, byte[]>();

            hashedPassword = WeatherApp.HashPassword(newPassword);

            entry[newUsername] = hashedPassword;

            WeatherApp.WriteAccountData(entry);

            isVerified = WeatherApp.VerifyLogin(newUsername, hashedPassword);
            Assert.IsTrue(isVerified);
        }

        [TestMethod()]
        public void APICallReturnsObject()
        {
            var data = GetWeather.APIcall("Denver").Result;
            Assert.IsNotNull(data);
            Assert.IsInstanceOfType(data, typeof(RootObject));
        }

        [TestMethod]
        public void DataGenerationFailureException()
        {
            var data = new RootObject();
            var result = data.GenerateReport();

            //GenerateReport() returns false in it's catch block if NullReferenceExcpetion is caught.
            Assert.IsFalse(result);
        }
    }
}