using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LinqToDB;
using LinqToDB.Data;
using Mentoring.D1D2.ORM.Entities;

namespace Mentoring.D1D2.ORM.DAL
{
    /// <summary>
    /// The type that represents an open connection to a database.
    /// </summary>
    public class NorthwindDataConnection : DataConnection
    {
        /// <summary>
        /// Initializes a new instance of the NorthwindDataConnection class.
        /// </summary>
        public NorthwindDataConnection() : base("Northwind") { }

        /// <summary>
        /// Represents Categories table with data in memory.
        /// </summary>
        public ITable<Category> Categories => GetTable<Category>();

        /// <summary>
        /// Represents Products table with data in memory.
        /// </summary>
        public ITable<Product> Products => GetTable<Product>();

        /// <summary>
        /// Represents Suppliers table with data in memory.
        /// </summary>
        public ITable<Supplier> Suppliers => GetTable<Supplier>();

        /// <summary>
        /// Represents Employees table with data in memory.
        /// </summary>
        public ITable<Employee> Employees => GetTable<Employee>();

        /// <summary>
        /// Represents EmployeeTerritories table with data in memory.
        /// </summary>
        public ITable<EmployeeTerritoryRelations> EmployeeTerritoriesRelationses => GetTable<EmployeeTerritoryRelations>();

        /// <summary>
        /// Represents Territories table with data in memory.
        /// </summary>
        public ITable<Territory> Territories => GetTable<Territory>();

        /// <summary>
        /// Represents Regions table with data in memory.
        /// </summary>
        public ITable<Region> Regions => GetTable<Region>();

        /// <summary>
        /// Represents Orders table with data in memory.
        /// </summary>
        public ITable<Order> Orders => GetTable<Order>();

        /// <summary>
        /// Represents Order Details table with data in memory.
        /// </summary>
        public ITable<OrderDetails> OrderDetails => GetTable<OrderDetails>();

        /// <summary>
        /// Represents Shippers table with data in memory.
        /// </summary>
        public ITable<Shipper> Shippers => GetTable<Shipper>();

        /// <summary>
        /// Represents Customers table with data in memory.
        /// </summary>
        public ITable<Customer> Customers => GetTable<Customer>();

        /// <summary>
        /// Represents Customer Demographics table with data in memory.
        /// </summary>
        public ITable<CustomerDemographics> CustomerDemographics => GetTable<CustomerDemographics>();

        /// <summary>
        /// Represents CustomerCustomerDemo table with data in memory.
        /// </summary>
        public ITable<CustomerDemographicsRelations> CustomerDemographicsRelationses => GetTable<CustomerDemographicsRelations>();
    }
}
