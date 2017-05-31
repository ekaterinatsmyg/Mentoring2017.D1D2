using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LinqToDB.Mapping;

namespace Mentoring.D1D2.ORM.Entities
{
    /// <summary>
    /// The entity that describes an order.
    /// </summary>
    [Table(Schema = "Northwind", Name = "Orders")]
    public class Order
    {
        /// <summary>
        /// The identifiator of an order.
        /// </summary>
        [PrimaryKey]
        [Identity]
        [Column("OrderID")]
        public int Id { get; set; }

        /// <summary>
        /// The employee entity.
        /// </summary>
        [Association(ThisKey = "ShipVia", OtherKey = "Id")]
        public Shipper Shipper { get; set; }


        /// <summary>
        /// The identificator of an employee entity.
        /// </summary>
        [Column("ShipVia")]
        public int ShipperId { get; set; }

        /// <summary>
        /// The entity of a customer.
        /// </summary>
        [Association(ThisKey = "CustomerID", OtherKey = "Id")]
        public Customer Customer { get; set; }

        /// <summary>
        /// The  identificator of a customer.
        /// </summary>
        [Column("CustomerID")]
        public string CustomerId { get; set; }

        /// <summary>
        /// The employee entity.
        /// </summary>
        [Association(ThisKey = "EmployeeID", OtherKey = "Id")]
        public Employee Employee { get; set; }

        /// <summary>
        /// The identificator of an employee entity.
        /// </summary>
        [Column("EmployeeID")]
        public int EmployeeId { get; set; }

        /// <summary>
        /// The date when an order was made.
        /// </summary>
        [Column]
        public DateTime? OrderDate { get; set; }

        /// <summary>
        /// The date when an order should be delivered.
        /// </summary>
        [Column]
        public DateTime? RequiredDate { get; set; }

        /// <summary>
        /// The date when an order was shipped.
        /// </summary>
        [Column]
        public DateTime? ShippedDate { get; set; }

        /// <summary>
        /// The freight of an order.
        /// </summary>
        [Column]
        public decimal? Freight { get; set; }

        /// <summary>
        /// The name of a ship.
        /// </summary>
        [Column]
        public string ShipName { get; set; }

        /// <summary>
        /// The address of a ship.
        /// </summary>
        [Column]
        public string ShipAddress { get; set; }

        /// <summary>
        /// The city of a ship.
        /// </summary>
        [Column]
        public string ShipCity { get; set; }

        /// <summary>
        /// The region of a ship.
        /// </summary>
        [Column]
        public string ShipRegion { get; set; }

        /// <summary>
        /// The postal code of a ship.
        /// </summary>
        [Column]
        public string ShipPostalCode { get; set; }

        /// <summary>
        /// The country code of a ship.
        /// </summary>
        [Column]
        public string ShipCountry { get; set; }
    }
}
