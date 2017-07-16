using System;
using System.Runtime.Serialization;

namespace Task.DB
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Order Details")]
    //[Serializable]
    [DataContract]
    [KnownType(typeof(Order))]
    public class Order_Detail
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [DataMember]
        public int OrderID { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [DataMember]
        public int ProductID { get; set; }

        [Column(TypeName = "money")]
        [DataMember]
        public decimal UnitPrice { get; set; }

        [DataMember]
        public short Quantity { get; set; }

        [DataMember]
        public float Discount { get; set; }

        [IgnoreDataMember]
        public virtual Order Order { get; set; }

        [IgnoreDataMember]
        public virtual Product Product { get; set; }

        /// <summary>
        /// Provide the string representation of the Order_Detail instance.
        /// </summary>
        /// <returns>The string representation of the Order_Detail instance.</returns>
        public string ToCustomString()
        {
            return $"{OrderID}|{UnitPrice}|{Quantity}|{Discount}";
        }
    }
}
