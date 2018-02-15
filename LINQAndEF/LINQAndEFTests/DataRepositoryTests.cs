using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using LINQAndEF;
using System.Linq;
using System.Collections.Generic;

namespace LINQAndEFTests
{
    [TestClass]
    public class DataRepositoryTests
    {
        [TestMethod]
        public void DataRepository_Can_Be_Constructed()
        {
            using (DataRepository<object> repository = new DataRepository<object>())
            {
                Assert.IsInstanceOfType(repository, typeof(DataRepository<object>));
            }
        }

        [TestMethod]
        public void DataRepository_Can_Query_Customers()
        {
            List<Customer> customers = null;

            using (DataRepository<Customer> repository = new DataRepository<Customer>())
            {
                customers = repository.Query(c => c.Country == "Italy").OrderByDescending(c => c.CompanyName).ToList();
            }

            Assert.IsNotNull(customers);
            Assert.AreEqual(3, customers.Count);

            Assert.AreEqual(customers[0].CompanyName, "Reggiani Caseifici");
            Assert.AreEqual(customers[1].CompanyName, "Magazzini Alimentari Riuniti");
            Assert.AreEqual(customers[2].CompanyName, "Franchi S.p.A.");
        }

        [TestMethod]
        public void DataRepository_Can_Add_Customer()
        {
            Customer customer = null;
            Customer queriedCustomer = null;

            string companyName = Guid.NewGuid().ToString();
            string customerId = companyName.Substring(0, 5);

            using (DataRepository<Customer> repository = new DataRepository<Customer>())
            {
                customer = repository.Add(new Customer
                {
                    CustomerID = customerId,
                    CompanyName = companyName,
                    ContactName = "George Smith",
                    ContactTitle = "CTO",
                    Address = "123 Main Street, Any Town, USA",
                    City = "Any Town",
                    Region = "Southern",
                    PostalCode = "55555",
                    Country = "USA",
                    Phone = "888-899-9932",
                    Fax = "223-447-2929"
                });

                repository.Save();

                queriedCustomer = repository.Query(c => c.CustomerID == customerId).FirstOrDefault();

                // Clean up added customer.
                repository.Delete(customer);
                repository.Save();
            }

            Assert.IsNotNull(customer);
            Assert.IsNotNull(queriedCustomer);
            Assert.AreEqual(customer.CustomerID, queriedCustomer.CustomerID);

            Assert.AreEqual(customer.CompanyName, queriedCustomer.CompanyName);
            Assert.AreEqual(customer.ContactName, queriedCustomer.ContactName);
            Assert.AreEqual(customer.ContactTitle, queriedCustomer.ContactTitle);
            Assert.AreEqual(customer.Address, queriedCustomer.Address);
            Assert.AreEqual(customer.City, queriedCustomer.City);
            Assert.AreEqual(customer.Region, queriedCustomer.Region);
            Assert.AreEqual(customer.PostalCode, queriedCustomer.PostalCode);
            Assert.AreEqual(customer.Country, queriedCustomer.Country);
            Assert.AreEqual(customer.Phone, queriedCustomer.Phone);
            Assert.AreEqual(customer.Fax, queriedCustomer.Fax);
        }

        [TestMethod]
        public void DataRepository_Can_Update_Customer()
        {
            //Assert.Fail("Write a test to confirm that a customer can be updated. Ensure you save and read from the repository to confirm the update.");
            Customer customer = null;
            Customer queriedCustomer = null;
            string companyName = Guid.NewGuid().ToString();
            string customerId = companyName.Substring(0,5);

            using (DataRepository<Customer> dataRepository = new DataRepository<Customer>())
            {
                customer = dataRepository.Add(new Customer
                {
                    CustomerID = customerId,
                    CompanyName = companyName,
                    ContactName = "Robert Parr",
                    ContactTitle = "Claims Handler",
                    Address = "123 Incredible St.",
                    City = "New York",
                    Region = "Suburbs",
                    PostalCode = "12345",
                    Country = "United States",
                    Phone = "1-800-555-1234",
                    Fax = "1-800-444-5432",
                });
                dataRepository.Save();
                customer.ContactName = "Syndrome";
                customer.ContactTitle = "Nemesis";
                customer.Address = "Secret Island Dr.";
                customer.City = "Volcanus";
                customer.Region = "Tropics";
                customer.PostalCode = "99999";
                customer.Country = "Not Found";
                customer.Phone = "1-800-EVI-LBOI";
                customer.Fax = "1-800-SAD-BOYO";
                dataRepository.Save();

                queriedCustomer = dataRepository.Query(c => c.CustomerID == customerId).FirstOrDefault();
                dataRepository.Delete(customer);
                dataRepository.Save();
            }
            Assert.AreEqual("Syndrome", queriedCustomer.ContactName);
            Assert.AreEqual("Nemesis", queriedCustomer.ContactTitle);
            Assert.AreEqual("Secret Island Dr.", queriedCustomer.Address);
            Assert.AreEqual("Volcanus", queriedCustomer.City);
            Assert.AreEqual("Tropics", queriedCustomer.Region);
            Assert.AreEqual("99999", queriedCustomer.PostalCode);
            Assert.AreEqual("Not Found", queriedCustomer.Country);
            Assert.AreEqual("1-800-EVI-LBOI", queriedCustomer.Phone);
            Assert.AreEqual("1-800-SAD-BOYO", queriedCustomer.Fax);
        }

        [TestMethod]
        public void DataRepository_Can_Delete_Customer()
        {
            Customer customer = null;
            Customer queriedCustomer = null;

            string companyName = Guid.NewGuid().ToString();
            string customerId = companyName.Substring(0, 5);

            using (DataRepository<Customer> repository = new DataRepository<Customer>())
            {
                var customerQuery = repository.Query(c => c.CustomerID == customerId);

                queriedCustomer = customerQuery.FirstOrDefault();
                Assert.IsNull(queriedCustomer, "Customer should not exist.");

                customer = repository.Add(new Customer
                {
                    CustomerID = customerId,
                    CompanyName = companyName,
                    ContactName = "George Smith",
                    ContactTitle = "CTO",
                    Address = "123 Main Street, Any Town, USA",
                    City = "Any Town",
                    Region = "Southern",
                    PostalCode = "55555",
                    Country = "USA",
                    Phone = "888-899-9932",
                    Fax = "223-447-2929"
                });

                repository.Save();

                queriedCustomer = customerQuery.FirstOrDefault();
                Assert.IsNotNull(queriedCustomer, "Customer should exist.");

                repository.Delete(customer);
                repository.Save();

                queriedCustomer = customerQuery.FirstOrDefault();
                Assert.IsNull(queriedCustomer, "Customer should not exist.");
            }
        }
    }
}
