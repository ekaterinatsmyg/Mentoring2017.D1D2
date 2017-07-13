using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Caching;
using CachingSolutionsSamples.Cashing;
using CachingSolutionsSamples.Managers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NorthwindLibrary;

namespace CachingSolutionsSamples.Tests
{
    [TestClass]
    public class CustomerManagerTest
    {

        [TestMethod]
        public void GeneralTest()
        {
            var connection = System.Configuration.ConfigurationManager.ConnectionStrings["Northwind"].ConnectionString;
            IEnumerable<Customer> customers;
            var key = $"{nameof(Customer)}_Cache_{DateTime.UtcNow.Day}";
            MemoryCacheService<Customer> cache = new MemoryCacheService<Customer>();
            EntityManager<Customer> customerManager = new EntityManager<Customer>(cache, connection, "select * from dbo.[Customers]");
            customers = customerManager.GetAll();
            using (var dbContext = new Northwind())
            {
                var updatedCustomer = dbContext.Customers.FirstOrDefault();
                if (updatedCustomer != null)
                {
                    updatedCustomer.City = "updated city2";
                }

                dbContext.SaveChanges();
            }
            var result = cache.Get(key);
            Assert.AreEqual(null, result);
        }


    }
}
