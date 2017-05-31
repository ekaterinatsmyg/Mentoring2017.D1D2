using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mentoring.D1D2.ORM.DAL;
using Mentoring.D1D2.ORM.Entities;

namespace Mentoring.D1D2.ORM
{
    class Program
    {
        static void Main()
        {
            NorthwindHelper.GetProductInfo();
            NorthwindHelper.GetEmployeeRegionInfo();
            NorthwindHelper.GetEmployeesByRegionInfo();
            NorthwindHelper.GetEmployeeShipperInfo();
            var employee = new Employee()
            {
                LastName = "LastName",
                FirstName = "FirstName"
            };
           // NorthwindHelper.CreateEmployee(employee, 1);
            //NorthwindHelper.UpdateProductCategory("Beverages", "Condiments");
            var product = new Product()
            {
                Name = "Test"
            };
            NorthwindHelper.CreateProduct(product, "test", "test");
        }
    }
}
