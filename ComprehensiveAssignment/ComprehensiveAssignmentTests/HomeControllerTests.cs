using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ComprehensiveAssignment;
using ComprehensiveAssignment.Controllers;
using System.Web.Mvc;

namespace ComprehensiveAssignmentTests
{
    [TestClass]
    public class HomeControllerTests
    {
        [TestMethod]
        public void HomeIndex()
        {
            HomeController controller = new HomeController();

            ViewResult result = controller.Index() as ViewResult;

            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void About()
        {
            HomeController controller = new HomeController();

            ViewResult result = controller.About() as ViewResult;

            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void Contact()
        {
            HomeController controller = new HomeController();

            ViewResult result = controller.Contact() as ViewResult;

            Assert.IsNotNull(result);
        }
    }
}
