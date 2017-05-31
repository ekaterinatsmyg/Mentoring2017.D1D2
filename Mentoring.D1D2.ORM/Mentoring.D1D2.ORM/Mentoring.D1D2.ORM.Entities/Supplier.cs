using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LinqToDB.Mapping;

namespace Mentoring.D1D2.ORM.Entities
{
    /// <summary>
    /// The entity that describes a supplier.
    /// </summary>
    [Table(Schema = "Northwind", Name = "Suppliers")]
    public class Supplier
    {

        /// <summary>
        /// The identifiator of a supplier.
        /// </summary>
        [Column("SupplierID"), Identity, PrimaryKey]
        public int Id { get; set; }

        /// <summary>
        /// The company's name of a supplier.
        /// </summary>
        [Column("CompanyName")]
        public string Name { get; set; }


        /// <summary>
        /// The contact name of a supplier.
        /// </summary>
        [Column]
        public string ContactName { get; set; }

        /// <summary>
        /// The contact title of a supplier.
        /// </summary>
        [Column]
        public string ContactTitle { get; set; }

        /// <summary>
        /// The address of a supplier.
        /// </summary>
        [Column]
        public string Address { get; set; }

        /// <summary>
        /// The city where supplier is situated.
        /// </summary>
        [Column]
        public string City { get; set; }

        /// <summary>
        /// The region where supplier is situated.
        /// </summary>
        [Column]
        public string Region { get; set; }

        /// <summary>
        /// The postal code of a country where supplier is situated.
        /// </summary>
        [Column]
        public string PostalCode { get; set; }

        /// <summary>
        /// The country where supplier is situated.
        /// </summary>
        [Column]
        public string Country { get; set; }

        /// <summary>
        /// The phone of a supplier.
        /// </summary>
        [Column]
        public string Phone { get; set; }

        /// <summary>
        /// The fax of a supplier.
        /// </summary>
        [Column]
        public string Fax { get; set; }

        /// <summary>
        /// The home page of a supplier.
        /// </summary>
        [Column]
        public string HomePage { get; set; }
        
    }
}
