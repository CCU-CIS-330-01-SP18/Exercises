using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassHierarchyAndCollections;

namespace ClassHierarchyTests
{
    /// <summary>
    /// Tests the functionality of the Student class.
    /// </summary>
    [TestClass]
    public class StudentTest
    {
        /// <summary>
        /// Tests to see if you can create an instance of the class.
        /// </summary>
        [TestMethod]
        public void CanCreateStudent()
        {
            Student s = new Student();
            Assert.IsNotNull(s);
        }

        /// <summary>
        /// Tests if the class correctly inherets the first tier in the hierarchy.
        /// </summary>
        [TestMethod]
        public void ContentDerivesFromDirectContent()
        {
            Student s = new Student();
            Assert.IsInstanceOfType(s, typeof(Individual));
        }

        /// <summary>
        /// Tests if the class correctly inherets the second tier in the hierarchy.
        /// </summary>
        [TestMethod]
        public void ContentDerivesFromExtendedContent()
        {
            Student s = new Student();
            Assert.IsInstanceOfType(s, typeof(Contact));
        }

        /// <summary>
        /// Tests the read/write capability of the first property.
        /// </summary>
        [TestMethod]
        public void StudentCanReadWriteIsHardWorking()
        {
            Student s = new Student();
            s.IsHardWorking = true;
            Assert.AreEqual(true, s.IsHardWorking);
        }

        /// <summary>
        /// Tests the read/write capability of the second property.
        /// </summary>
        [TestMethod]
        public void StudentCanReadWriteGPA()
        {
            Student s = new Student();
            s.GPA = 3.7f;
            Assert.AreEqual(3.7f, s.GPA);
        }
    }
}
