using System;
using System.Collections.Generic;
using ASN;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ASNTests
{
    [TestClass]
    public class DataSerializerTests
    {
        [TestMethod]
        public void CanSerializeCollections()
        {
            var u = new User("FirstName", "LastName", "email@email.com", 0, "password");
            var p = new Post(0, "Message", 0);

            var list1 = new List<User>();
            list1.Add(u);
            var list2 = new List<Post>();
            list2.Add(p);

            DataSerializer.SerializeUsers(list1);
            DataSerializer.SerializePosts(list2);

            Assert.IsTrue(DataSerializer.DeserializeUsers().Count > 0);
            Assert.IsTrue(DataSerializer.DeserializePosts().Count > 0);
        }
    }
}
