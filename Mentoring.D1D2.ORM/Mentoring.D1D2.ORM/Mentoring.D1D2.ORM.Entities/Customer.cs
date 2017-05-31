using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LinqToDB.Mapping;

namespace Mentoring.D1D2.ORM.Entities
{
    /// <summary>
    /// The entity that describes a customer.
    /// </summary>
    [Table(Schema = "Northwind", Name = "Customers")]
    public class Customer
    {
        /// <summary>
        /// The identifiator of a customer.
        /// </summary>
        [Column("CustomerID"), Identity, PrimaryKey]
        public string Id { get; set; }

        /// <summary>
        /// The company's name of a customer.
        /// </summary>
        [Column("CompanyName")]
        public string Name { get; set; }


        /// <summary>
        /// The contact name of a customer.
        /// </summary>
        [Column]
        public string ContactName { get; set; }

        /// <summary>
        /// The contact title of a customer.
        /// </summary>
        [Column]
        public string ContactTitle { get; set; }

        /// <summary>
        /// The address of a customer.
        /// </summary>
        [Column]
        public string Address { get; set; }

        /// <summary>
        /// The city where the customer is situated.
        /// </summary>
        [Column]
        public string City { get; set; }

        /// <summary>
        /// The region where the customer is situated.
        /// </summary>
        [Column]
        public string Region { get; set; }

        /// <summary>
        /// The postal code of a country where the customer is situated.
        /// </summary>
        [Column]
        public string PostalCode { get; set; }

        /// <summary>
        /// The country where the customer is situated.
        /// </summary>
        [Column]
        public string Country { get; set; }

        /// <summary>
        /// The phone of a customer.
        /// </summary>
        [Column]
        public string Phone { get; set; }

        /// <summary>
        /// The fax of the customer.
        /// </summary>
        [Column]
        public string Fax { get; set; }

    }
}
