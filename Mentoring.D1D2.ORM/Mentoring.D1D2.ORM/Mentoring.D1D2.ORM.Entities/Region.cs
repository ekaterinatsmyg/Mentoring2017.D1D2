using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LinqToDB.Mapping;

namespace Mentoring.D1D2.ORM.Entities
{
    /// <summary>
    /// The entity that describes a region.
    /// </summary>
    [Table(Schema = "Northwind", Name = "Region")]
    public class Region
    {
        /// <summary>
        /// The identifiator of a region.
        /// </summary>
        [Column("RegionID"), Identity, PrimaryKey]
        public int Id { get; set; }

        /// <summary>
        /// The description of a region.
        /// </summary>
        [Column("RegionDescription")]
        public string Description { get; set; }
    }
}
