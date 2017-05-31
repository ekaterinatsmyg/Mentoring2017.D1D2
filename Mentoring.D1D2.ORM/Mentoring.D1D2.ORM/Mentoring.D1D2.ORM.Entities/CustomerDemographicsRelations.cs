using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LinqToDB.Mapping;

namespace Mentoring.D1D2.ORM.Entities
{
    /// <summary>
    /// The entity that describes relations between a customer's demographics and a customer.
    /// </summary>
    [Table(Schema = "Northwind", Name = "CustomerCustomerDemo")]
    public class CustomerDemographicsRelations
    {
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
        /// The customer demographics entity.
        /// </summary>
        [Association(ThisKey = "CustomerTypeID", OtherKey = "Id")]
        public CustomerDemographics CustomerDemographics { get; set; }

        /// <summary>
        /// The identificator of a customer demographics entity.
        /// </summary>
        [Column("CustomerTypeID")]
        public int CustomerDemographicsId { get; set; }
    }
}
