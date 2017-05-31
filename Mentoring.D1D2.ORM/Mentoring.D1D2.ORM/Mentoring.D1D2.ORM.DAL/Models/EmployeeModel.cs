using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mentoring.D1D2.ORM.DAL.Models
{
    /// <summary>
    /// Describes a model that contains information about employees and theirs region.
    /// </summary>
    public class EmployeeModel
    {
        /// <summary>
        /// The identifiator of an employee.
        /// </summary>
        public int Id { get; set; }
        
        /// <summary>
        /// The last name of an employee.
        /// </summary>
        public string LastName { get; set; }


        /// <summary>
        /// The first name of an employee.
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// The title of an employee.
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// The description of a region.
        /// </summary>
        public string RegionDescription { get; set; }

        /// <summary>
        /// The shipper name which the employee works with. 
        /// </summary>
        public string ShipperName { get; set; }
    }
}
