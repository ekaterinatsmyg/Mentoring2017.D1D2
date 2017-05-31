using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LinqToDB.Mapping;

namespace Mentoring.D1D2.ORM.Entities
{
    /// <summary>
    /// The entity that describes an employee's territory.
    /// </summary>
    [Table(Schema = "Northwind", Name = "Territories")]
    public class Territory
    {
        /// <summary>
        /// The identifiator of a territory.
        /// </summary>
        [Column("TerritoryID"), Identity, PrimaryKey]
        public string Id { get; set; }

        /// <summary>
        /// The description of a territory.
        /// </summary>
        [Column("TerritoryDescription")]
        public string Description { get; set; }

        /// <summary>
        /// The region entity.
        /// </summary>
        [Association(ThisKey = "RegionID", OtherKey = "Id")]
        public Region Region { get; set; }

        /// <summary>
        /// The region's identificator.
        /// </summary>
        [Column("RegionID")]
        public int RegionId { get; set; }


    }
}
