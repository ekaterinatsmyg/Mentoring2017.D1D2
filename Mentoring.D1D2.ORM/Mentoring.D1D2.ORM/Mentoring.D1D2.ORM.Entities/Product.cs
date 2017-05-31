using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LinqToDB.Mapping;

namespace Mentoring.D1D2.ORM.Entities
{
    /// <summary>
    /// The entity that describes a product.
    /// </summary>
    [Table(Schema = "Northwind", Name = "Products")]
    public class Product
    {
        /// <summary>
        /// The identifiator of a product.
        /// </summary>
        [Column("ProductID"), Identity, PrimaryKey]
        public int Id { get; set; }

        /// <summary>
        /// The name of a product.
        /// </summary>
        [Column("ProductName")]
        public string Name { get; set; }

        /// <summary>
        /// The category of a product.
        /// </summary>
        [Association(ThisKey = "CategoryID", OtherKey = "Id")]
        public Category Category { get; set; }

        /// <summary>
        /// The category's identificator of a product.
        /// </summary>
        [Column("CategoryID")]
        public int? CategoryId { get; set; }


        /// <summary>
        /// The category of a product.
        /// </summary>
        [Association(ThisKey = "SupplierID", OtherKey = "Id")]
        public Supplier Supplier { get; set; }

        /// <summary>
        /// The category's identificator of a product.
        /// </summary>
        [Column("SupplierID")]
        public int? SupplierId { get; set; }

        /// <summary>
        /// The quantity of a product.
        /// </summary>
        [Column]
        public string QuantityPerUnit { get; set; }

        /// <summary>
        /// The price of product.
        /// </summary>
        [Column]
        public decimal? UnitPrice { get; set; }

        /// <summary>
        /// The quantity of a product in stock.
        /// </summary>
        [Column]
        public int? UnitsInStock { get; set; }

        /// <summary>
        /// The quantity of a product on order.
        /// </summary>
        [Column]
        public int? UnitsOnOrder { get; set; }
        
        /// <summary>
        /// 
        /// </summary>
        [Column]
        public int? ReorderLevel { get; set; }

        /// <summary>
        /// The value if the product was withdrawn from sale or not.
        /// </summary>
        [Column]
        public bool Discontinued { get; set; }
    }
}
