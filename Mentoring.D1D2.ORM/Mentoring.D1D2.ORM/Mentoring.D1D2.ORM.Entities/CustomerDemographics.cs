using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LinqToDB.Mapping;

namespace Mentoring.D1D2.ORM.Entities
{
    /// <summary>
    /// The entity that describes a customer's demographics.
    /// </summary>
    [Table(Schema = "Northwind", Name = "CustomerDemographics")]
    public class CustomerDemographics
    {
        /// <summary>
        /// The identifiator of a customer's type.
        /// </summary>
        [Column("CustomerTypeID"), Identity, PrimaryKey]
        public int Id { get; set; }

        /// <summary>
        /// The description of a territory.
        /// </summary>
        [Column("CustomerDesc")]
        public string Description { get; set; }
    }
}
