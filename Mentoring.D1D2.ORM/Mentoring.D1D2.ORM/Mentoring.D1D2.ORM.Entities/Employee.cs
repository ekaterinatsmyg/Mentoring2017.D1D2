using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LinqToDB.Mapping;

namespace Mentoring.D1D2.ORM.Entities
{
    /// <summary>
    /// The entity that describes an employee.
    /// </summary>
    [Table(Schema = "Northwind", Name = "Employees")]
    public class Employee
    {
        /// <summary>
        /// The identifiator of an employee.
        /// </summary>
        [Column("EmployeeID"), Identity, PrimaryKey]
        public int Id { get; set; }

        /// <summary>
        /// The category of a product.
        /// </summary>
        [Association(ThisKey = "ReportsTo", OtherKey = "Id")]
        public Employee ReportsToEmployee { get; set; }

        /// <summary>
        /// The category's identificator of a product.
        /// </summary>
        [Column("ReportsTo")]
        public int? ReportsToEmployeeId { get; set; }


        /// <summary>
        /// The last name of an employee.
        /// </summary>
        [Column]
        public string LastName { get; set; }


        /// <summary>
        /// The first name of an employee.
        /// </summary>
        [Column]
        public string FirstName { get; set; }

        /// <summary>
        /// The title of an employee.
        /// </summary>
        [Column]
        public string Title { get; set; }

        /// <summary>
        /// The title of courtesy of an employee.
        /// </summary>
        [Column]
        public string TitleOfCourtesy { get; set; }

        /// <summary>
        /// The birth date of an employee.
        /// </summary>
        [Column]
        public DateTime? BirthDate { get; set; }

        /// <summary>
        /// The birth hire of an employee.
        /// </summary>
        [Column]
        public DateTime? HireDate { get; set; }

        /// <summary>
        /// The address of an employee.
        /// </summary>
        [Column]
        public string Address { get; set; }

        /// <summary>
        /// The city where an employee is situated.
        /// </summary>
        [Column]
        public string City { get; set; }

        /// <summary>
        /// The region where an employee is situated.
        /// </summary>
        [Column]
        public string Region { get; set; }

        /// <summary>
        /// The postal code of a country where an employee is situated.
        /// </summary>
        [Column]
        public string PostalCode { get; set; }

        /// <summary>
        /// The country where an employee is situated.
        /// </summary>
        [Column]
        public string Country { get; set; }

        /// <summary>
        /// The home phone of an employe.
        /// </summary>
        [Column]
        public string HomePhone { get; set; }


        /// <summary>
        /// The home phone of an employe.
        /// </summary>
        [Column]
        public string Extension { get; set; }

        /// <summary>
        /// The notes of a supplier.
        /// </summary>
        [Column]
        public string Notes { get; set; }

        /// <summary>
        /// The photo path of an employee
        /// </summary>
        [Column]
        public string PhotoPath { get; set; }

        /// <summary>
        /// The photo  of an employee
        /// </summary>
        [Column]
        public byte[] Photo { get; set; }
    }
}
