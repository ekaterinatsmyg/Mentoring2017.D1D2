using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Task.DB;
using Task.TestHelpers;
using System.Runtime.Serialization;
using System.Linq;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using System.Data.Entity.Infrastructure;
using Task.Serializers;
using Task.Surragates;

namespace Task
{
    [TestClass]
    public class SerializationSolutions
    {
        Northwind dbContext;

        [TestInitialize]
        public void Initialize()
        {
            dbContext = new Northwind();
        }

        [TestMethod]
        public void SerializationCallbacks()
        {
            dbContext.Configuration.ProxyCreationEnabled = false;

            var categories = dbContext.Categories.ToList();

            var category = categories.First();

            var dataContractSerializer = new GenericDataContractSerializer<Category>();

            dataContractSerializer.WriteObject("D:/result_1.xml", category);
            var result = dataContractSerializer.ReadObject("D:/result_1.xml");

            Assert.AreEqual(category.GetType(), result.GetType());
            Assert.AreEqual(category.Products.Count(), result.Products.Count());

        }

        [TestMethod]
        public void ISerializable()
        {
            var product = dbContext.Products.First();

            var t = (dbContext as IObjectContextAdapter).ObjectContext;
            t.LoadProperty(product, f => f.Order_Details);

            var dataContractSerializer = new GenericDataContractSerializer<Product>();

            dataContractSerializer.WriteObject("D:/result_2.xml", product);
            var result = dataContractSerializer.ReadObject("D:/result_2.xml");

            Assert.AreEqual(product.GetType(), result.GetType());
            Assert.AreEqual(product.Order_Details.Count(), result.Order_Details.Count());
        }


        [TestMethod]
        public void ISerializationSurrogate()
        {
            var selector = new SurrogateSelector();

            selector.AddSurrogate(typeof(Order_Detail), new StreamingContext(StreamingContextStates.Persistence, null), new OrderDetailsSerrializationSurrogates());

            var serializer = new GenericSoapFormatter<Order_Detail>();

            var orderDetails = dbContext.Order_Details.ToList().First();

            serializer.Serialize("D:/result_3.xml", orderDetails, selector);
            var result = serializer.Deserialize("D:/result_3.xml", selector);

            Assert.AreEqual(orderDetails.GetType(), result.GetType());
            Assert.AreEqual(orderDetails.OrderID, result.OrderID);
        }

        [TestMethod]
        public void IDataContractSurrogate()
        {
            dbContext.Configuration.ProxyCreationEnabled = true;
            dbContext.Configuration.LazyLoadingEnabled = true;

            
            var order = dbContext.Orders.First();
            var surrogate = new OrderDataContractSurrogate();
            var serializer = new GenericDataContractSerializer<Order>(surrogate);

            serializer.WriteObject("D:/result_4.xml", order);

            var deserializer = new GenericDataContractSerializer<Order>(surrogate);
            var result = deserializer.ReadObject("D:/result_4.xml");

            Assert.AreNotEqual(order.GetType(), result.GetType());
            Assert.AreEqual(order.OrderID, result.OrderID);

        }
    }
}
