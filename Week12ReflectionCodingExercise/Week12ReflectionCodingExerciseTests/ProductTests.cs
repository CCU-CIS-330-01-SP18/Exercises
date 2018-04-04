using System;
using System.Reflection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Week12ReflectionCodingExercise;

namespace Week12ReflectionCodingExerciseTests
{
    [TestClass]
    public class ProductTests
    {
        [TestMethod]
        public void CanConstructAProduct()
        {
            var product = typeof(Product).GetConstructor(new Type[] { }).Invoke(null) as Product;

            Assert.IsInstanceOfType(product, typeof(Product));
        }

        [TestMethod]
        public void CanInvokeProductMethod()
        {
            var product = new Product();

            var productMethod = product.GetType().GetMethod("ProfitMargin", BindingFlags.NonPublic | BindingFlags.Instance, null, new Type[] { typeof(int), typeof(int) }, null);
            double result = (double)productMethod.Invoke(product, new object[] { 100000, 500000 });

            Assert.AreEqual(20, result);
        }

        [TestMethod]
        public void CanReadProductProperties()
        {
            var p = typeof(Product);

            var product = new Product() { SalesRevenue = 1000, CostOfGoodsSold = 5000 };

            Assert.AreEqual(1000, p.GetProperty("SalesRevenue", BindingFlags.Public | BindingFlags.Instance).GetValue(product));
            Assert.AreEqual(5000, p.GetProperty("CostOfGoodsSold", BindingFlags.Public | BindingFlags.Instance).GetValue(product));
        }

        [TestMethod]
        public void CanSetProductProperties()
        {
            var product = new Product();
            int salesRevenue = 1000;
            int costOfGoodsSold = 5000;
            var nameInfo = product.GetType().GetProperty("SalesRevenue", BindingFlags.Public | BindingFlags.Instance);
            nameInfo.SetValue(product, salesRevenue, null);

            var ageInfo = product.GetType().GetProperty("CostOfGoodsSold", BindingFlags.Public | BindingFlags.Instance);
            ageInfo.SetValue(product, costOfGoodsSold, null);

            Assert.AreEqual(1000, product.SalesRevenue);
            Assert.AreEqual(5000, product.CostOfGoodsSold);
        }
    }
}
