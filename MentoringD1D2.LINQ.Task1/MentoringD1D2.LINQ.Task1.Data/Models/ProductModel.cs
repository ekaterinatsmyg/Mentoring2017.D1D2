using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MentoringD1D2.LINQ.Task1.Data.Models
{
    /// <summary>
    /// Model that represents product entity.
    /// </summary>
    public class ProductModel
    {
        /// <summary>
        /// The product identifer.
        /// </summary>
        public int ProductId { get; set; }

        /// <summary>
        /// The name of a produtc.
        /// </summary>
        public string ProductName { get; set; }

        /// <summary>
        /// The category of a product.
        /// </summary>
        public string Category { get; set; }

        /// <summary>
        /// The price of a product unit.
        /// </summary>
        public decimal UnitPrice { get; set; }

        /// <summary>
        /// The total number of units that are avaliable in stock.
        /// </summary>
        public int TotalInStock { get; set; }

        public override string ToString()
        {
            return $"ID: {ProductId} {Environment.NewLine} Product: {ProductName} | Category: {Category} {Environment.NewLine}  Price: {UnitPrice} | InStock: {TotalInStock} {Environment.NewLine}";
        }
    }
}
