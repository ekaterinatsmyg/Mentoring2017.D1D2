using System;
using System.Data.Entity.Core.Objects;
using System.Data.Entity.Infrastructure;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;
using System.Threading;
using System.Xml.Serialization;

namespace Task.DB
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    
    [DataContract]
    public partial class Category
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Category()
        {
            Products = new HashSet<Product>();
        }

        [DataMember]
        public int CategoryID { get; set; }

        [Required]
        [StringLength(15)]
        [DataMember]
        public string CategoryName { get; set; }

        [Column(TypeName = "ntext")]
        [DataMember]
        public string Description { get; set; }

        [Column(TypeName = "image")]
        public byte[] Picture { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        [XmlArray("products")]
        [DataMember]
        public virtual ICollection<Product> Products { get; set; }


        #region Serializing

        /// <summary>
        /// Calls before serialization. Initializes products related to the category.
        /// </summary>
        /// <param name="streamingContext"></param>
        [OnSerializing()]
        void OnSerializing(StreamingContext streamingContext)
        {
            using (var dbContext = new Northwind())
            {
                dbContext.Configuration.ProxyCreationEnabled = false;
                dbContext.Configuration.LazyLoadingEnabled = false;
                Products = dbContext.Products.Where(p => p.CategoryID == CategoryID).ToList();
            }
        }

        #endregion

        public override string ToString()
        {
            return $"{CategoryID} {CategoryName} {Description} {Products}";
        }
    }
}
