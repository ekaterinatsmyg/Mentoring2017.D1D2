


namespace Mentoring.D1D2.ORM.DAL.Models
{
    /// <summary>
    /// Describes model that contains information about products with its categories an suppliers.
    /// </summary>
    public class ProductModel
    {
        /// <summary>
        /// The identifiator of a product.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// The name of a product.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The price of product.
        /// </summary>
        public decimal? UnitPrice { get; set; }

        /// <summary>
        /// The name of a category.
        /// </summary>
        public string CategoryName { get; set; }


        /// <summary>
        /// The company's name of a supplier.
        /// </summary>
        public string SupplierCompanyName { get; set; }

    }
}
