using System;
using System.Linq;
using System.Runtime.Serialization;

namespace Task.DB
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    //Uncommit DataContract and DataMember attributes for the first step.
    //[DataContract]
    [Serializable]
    public partial class Product : ISerializable
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Product()
        {
            Order_Details = new HashSet<Order_Detail>();
        }

        //[DataMember]
        public int ProductID { get; set; }

        [Required]
        [StringLength(40)]
        //[DataMember]
        public string ProductName { get; set; }

        //[DataMember]
        public int? SupplierID { get; set; }

        public int? CategoryID { get; set; }

        [StringLength(20)]
        public string QuantityPerUnit { get; set; }

        [Column(TypeName = "money")]
        //[DataMember]
        public decimal? UnitPrice { get; set; }

        //[DataMember]
        public short? UnitsInStock { get; set; }

        //[DataMember]
        public short? UnitsOnOrder { get; set; }

        //[DataMember]
        public short? ReorderLevel { get; set; }

        //[DataMember]
        public bool Discontinued { get; set; }

        public virtual Category Category { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Order_Detail> Order_Details { get; set; }

        public virtual Supplier Supplier { get; set; }

        public override string ToString()
        {
            return $"{ProductID} {ProductName} {UnitPrice} {UnitsInStock}";
        }

        #region Iserializable

        /// <summary>
        /// Parses serialized Product.
        /// </summary>
        /// <param name="info"></param>
        /// <param name="context"></param>
        private Product(SerializationInfo info, StreamingContext context)
        {
            ProductID = info.GetInt32("Id");
            ProductName = info.GetString("Name");
            UnitsInStock = (short?)info.GetValue("AvailableCount", typeof(short?));
            UnitPrice = (decimal?)info.GetValue("Price", typeof(decimal?));

            var orders = info.GetString("Orders").Split(Environment.NewLine.ToCharArray());

            Order_Details = new List<Order_Detail>();

            foreach (var order in orders)
            {
                if (!String.IsNullOrEmpty(order))
                {

                    var result = order.Split('|');
                    Order_Details.Add(
                        new Order_Detail
                        {
                            OrderID = Convert.ToInt32(result[0]),
                            UnitPrice = Convert.ToDecimal(result[1]),
                            Quantity = Convert.ToInt16(result[2]),
                            Discount = Convert.ToInt64(result[3])
                        }
                        );
                }
            }
        }

        /// <summary>
        /// Generates serialized Product.
        /// </summary>
        /// <param name="info"></param>
        /// <param name="context"></param>
        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("Id", ProductID);
            info.AddValue("Name", ProductName);
            info.AddValue("AvailableCount", UnitsInStock);
            info.AddValue("Price", UnitPrice);
            var orders = Order_Details.ToArray();
            string result = String.Empty;
            for (int i = 0; i < Order_Details.Count; i++)
            {
                result += $"{(orders[i].ToCustomString())}{Environment.NewLine}";
            }
            info.AddValue("Orders", result);

        }

        #endregion
    }
}
