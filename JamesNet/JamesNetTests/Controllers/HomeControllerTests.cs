using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using JamesNet;
using JamesNet.Controllers;

namespace JamesNetTests.Controllers
{
    [TestClass]
    public class HomeControllerTests
    {
        [TestMethod]
        public void DisplaysIndex()
        {
            // Arrange
            HomeController controller = new HomeController();

            // Act
            ViewResult result = controller.Index() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }
    }
}
