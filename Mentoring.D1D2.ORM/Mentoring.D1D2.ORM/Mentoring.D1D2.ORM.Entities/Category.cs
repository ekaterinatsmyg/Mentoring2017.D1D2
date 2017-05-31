using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LinqToDB.Mapping;

namespace Mentoring.D1D2.ORM.Entities
{
    /// <summary>
    /// The entity that describes category of products.
    /// </summary>
    [Table(Schema = "Northwind", Name = "Categories")]
    public class Category
    {
        /// <summary>
        /// The identifiator of a category.
        /// </summary>
        [PrimaryKey]
        [Identity]
        [Column("CategoryID")]
        public int Id { get; set; }

        /// <summary>
        /// The name of a category.
        /// </summary>
        [Column("CategoryName")]
        public string Name { get; set; }

        /// <summary>
        /// The description of a category.
        /// </summary>
        [Column]
        public string Description { get; set; }

        /// <summary>
        /// The picture related to a category.
        /// </summary>
        [Column]
        public byte[] Picture { get; set; }
    }
}
