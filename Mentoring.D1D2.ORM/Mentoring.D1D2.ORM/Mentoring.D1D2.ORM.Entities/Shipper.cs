using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LinqToDB.Mapping;

namespace Mentoring.D1D2.ORM.Entities
{
    /// <summary>
    /// The entity that describes a shipper.
    /// </summary>
    [Table(Schema = "Northwind", Name = "Shippers")]
    public class Shipper
    {
        /// <summary>
        /// The identifiator of a shipper.
        /// </summary>
        [PrimaryKey]
        [Identity]
        [Column("ShipperID")]
        public int Id { get; set; }

        /// <summary>
        /// The company's name of a shipper.
        /// </summary>
        [Column("CompanyName")]
        public string Name { get; set; }

        /// <summary>
        /// The phone of a shipper.
        /// </summary>
        [Column]
        public string Phone { get; set; }
    }
}
