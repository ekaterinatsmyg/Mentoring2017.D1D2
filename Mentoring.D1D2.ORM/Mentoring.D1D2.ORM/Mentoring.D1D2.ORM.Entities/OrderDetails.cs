using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LinqToDB.Mapping;

namespace Mentoring.D1D2.ORM.Entities
{
    /// <summary>
    /// The entity that describes details of an order.
    /// </summary>
    [Table(Schema = "Northwind", Name = "Order Details")]
    public class OrderDetails
    {
        /// <summary>
        /// The order entity.
        /// </summary>
        [Association(ThisKey = "OrderID", OtherKey = "Id")]
        public Order Order { get; set; }

        /// <summary>
        /// The identificator of an order entity.
        /// </summary>
        [Column("OrderID")]
        public int OrderId { get; set; }


        /// <summary>
        /// The product entity.
        /// </summary>
        [Association(ThisKey = "ProductID", OtherKey = "Id")]
        public Product Product { get; set; }

        /// <summary>
        /// The identificator of a product.
        /// </summary>
        [Column("ProductID")]
        public int ProductId { get; set; }

        /// <summary>
        /// The price of an order.
        /// </summary>
        [Column]
        public decimal UnitPrice { get; set; }

        /// <summary>
        /// The quantity items per order.
        /// </summary>
        [Column]
        public int Quantity { get; set; }

        /// <summary>
        /// The discount for order.
        /// </summary>
        [Column]
        public decimal Discount { get; set; }
    }
}
