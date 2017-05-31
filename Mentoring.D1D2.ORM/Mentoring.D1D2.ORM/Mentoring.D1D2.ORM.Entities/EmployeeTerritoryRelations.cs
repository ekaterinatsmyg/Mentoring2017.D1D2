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
    [Table(Schema = "Northwind", Name = "EmployeeTerritories")]
    public class EmployeeTerritoryRelations
    {
        /// <summary>
        /// The territory of an employee.
        /// </summary>
        [Association(ThisKey = "TerritoryID", OtherKey = "Id")]
        public Territory Territory { get; set; }

        /// <summary>
        /// The  identificator of a territory.
        /// </summary>
        [Column("TerritoryID")]
        public string TerritoryId { get; set; }

        /// <summary>
        /// The employee entity.
        /// </summary>
        [Association(ThisKey = "EmployeeID", OtherKey = "Id")]
        public Employee Employee { get; set; }

        /// <summary>
        /// The identificator of an employee entity.
        /// </summary>
        [Column("EmployeeID")]
        public int EmployeeId { get; set; }
    }
}
