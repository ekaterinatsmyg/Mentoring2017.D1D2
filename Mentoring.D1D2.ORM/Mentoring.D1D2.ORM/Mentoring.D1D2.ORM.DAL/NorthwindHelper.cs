using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LinqToDB;
using Mentoring.D1D2.ORM.DAL.Models;
using Mentoring.D1D2.ORM.Entities;

namespace Mentoring.D1D2.ORM.DAL
{
    public static class NorthwindHelper
    {
        #region Getters
        /// <summary>
        /// Get product information and inormation about suppliersant categories related to a product.
        /// </summary>
        /// <returns>The list of products with its suppliers and categories.</returns>
        public static List<ProductModel> GetProductInfo()
        {
            using (var dbConnection = new NorthwindDataConnection())
            {
                return (from p in dbConnection.Products
                                  join c in dbConnection.Categories on p.CategoryId equals c.Id
                                  join s in dbConnection.Suppliers on p.SupplierId equals s.Id
                                  select new ProductModel()
                                  {
                                      Id = p.Id,
                                      Name = p.Name,
                                      UnitPrice = p.UnitPrice,
                                      CategoryName = c.Name,
                                      SupplierCompanyName = s.Name
                                  }).ToList();
                
            }
        }


        /// <summary>
        /// Get employess information and inormation about their region.
        /// </summary>
        /// <returns>The list of employees with theirs region.</returns>
        public static List<EmployeeModel> GetEmployeeRegionInfo()
        {
            using (var dbConnection = new NorthwindDataConnection())
            {
                return (from e in dbConnection.Employees
                        join et in dbConnection.EmployeeTerritoriesRelationses on e.Id equals et.EmployeeId
                        join t in dbConnection.Territories on et.TerritoryId equals t.Id
                        join r in dbConnection.Regions on t.RegionId equals r.Id
                        select new EmployeeModel()
                        {
                            Id = e.Id,
                            FirstName = e.FirstName,
                            LastName = e.LastName,
                            Title = e.Title,
                            RegionDescription = r.Description
                        }).ToList();

            }
        }


        /// <summary>
        /// Get count of the employees grouped by theirs region.
        /// </summary>
        /// <returns>The dictionary where the key - a description of a region, values - count of the employees related to the region.</returns>
        public static Dictionary<string, int> GetEmployeesByRegionInfo()
        {
            using (var dbConnection = new NorthwindDataConnection())
            {
                return (from e in dbConnection.Employees
                        join et in dbConnection.EmployeeTerritoriesRelationses on e.Id equals et.EmployeeId
                        join t in dbConnection.Territories on et.TerritoryId equals t.Id
                        join r in dbConnection.Regions on t.RegionId equals r.Id
                        group e by r.Description).ToDictionary(r => r.Key, r => r.Count());

            }
        }


        /// <summary>
        /// Get employess information and inormation about their region.
        /// </summary>
        /// <returns>The list of employees with theirs region.</returns>
        public static List<EmployeeModel> GetEmployeeShipperInfo()
        {
            using (var dbConnection = new NorthwindDataConnection())
            {
                return (from e in dbConnection.Employees
                        join o in dbConnection.Orders on e.Id equals o.EmployeeId
                        join sh in dbConnection.Shippers on o.ShipperId equals sh.Id
                        select new EmployeeModel()
                        {
                            Id = e.Id,
                            FirstName = e.FirstName,
                            LastName = e.LastName,
                            Title = e.Title,
                            ShipperName = sh.Name
                        }).ToList();

            }
        }

        /// <summary>
        /// Get territories by region id.
        /// </summary>
        /// <returns>The region with specified id.</returns>
        private static List<Territory> GetTerritoriesByRegion(int id)
        {
            using (var dbConnection = new NorthwindDataConnection())
            {
                return (from r in dbConnection.Territories
                        where r.RegionId == id
                        select r).ToList();

            }
        }

        /// <summary>
        /// Get category by its name.
        /// </summary>
        /// <returns>The category with specified id.</returns>
        private static Category GetCategoryIdByName(string categoryName)
        {
            using (var dbConnection = new NorthwindDataConnection())
            {
                return (from c in dbConnection.Categories
                        where c.Name == categoryName
                        select c).FirstOrDefault();

            }
        }

        /// <summary>
        /// Get supplier by its name.
        /// </summary>
        /// <returns>The supplier with specified id.</returns>
        private static Supplier GetSupplierByName(string supplierName)
        {
            using (var dbConnection = new NorthwindDataConnection())
            {
                return (from s in dbConnection.Suppliers
                        where s.Name == supplierName
                        select s).FirstOrDefault();

            }
        }
        #endregion

        #region Insert Methods

        /// <summary>
        /// Create new product with assigned territories.
        /// </summary>
        /// <param name="employee">The product entity.</param>
        /// <param name="regionId">The region identificator.</param>
        /// <returns>The identificator of the created em</returns>
        public static int CreateEmployee(Employee employee, int regionId)
        {
            using (var dbConnection = new NorthwindDataConnection())
            {
                var employeeId = Convert.ToInt32(dbConnection.InsertWithIdentity(employee));
                var territories = GetTerritoriesByRegion(regionId);
                if (territories.Any())
                {
                    var emplyeeTerritoryRelations = territories.Select(territory => new EmployeeTerritoryRelations
                    {
                       EmployeeId = employeeId, TerritoryId = territory.Id,

                    }).ToList();
                    foreach (var employeeTerritory in emplyeeTerritoryRelations)
                    {
                        dbConnection.Insert(employeeTerritory);
                    }
                }

               return employeeId;
            }
        }

        #endregion

        /// <summary>
        /// Update products category from one to anothe.
        /// </summary>
        /// <param name="categoryNameFrom">The initial category.</param>
        /// <param name="categoryNameTo">The final category of products.</param>
        /// <returns>The list of products with final category.</returns>
        public static List<Product> UpdateProductCategory(string categoryNameFrom, string categoryNameTo)
        {
            using (var dbConnection = new NorthwindDataConnection())
            {
                int? categoryIdFrom = GetCategoryIdByName(categoryNameFrom)?.Id;
                int? categoryIdTo = GetCategoryIdByName(categoryNameTo)?.Id;
                dbConnection.Products
                  .Where(p => p.CategoryId == categoryIdFrom)
                  .Set(p => p.CategoryId, categoryIdTo)
                  .Update();

                return dbConnection.Products.Where(p => p.CategoryId == categoryIdTo).ToList();


            }
        }


        /// <summary>
        /// Create new product.
        /// </summary>
        /// <param name="product">The product entity.</param>
        /// <param name="categoryName">The name of a category</param>
        /// <param name="supplierName">The name of a supplier</param>
        /// <returns>The identificator of the created em</returns>
        public static int CreateProduct(Product product, string categoryName, string supplierName)
        {
            using (var dbConnection = new NorthwindDataConnection())
            {

                var productId = Convert.ToInt32(dbConnection.InsertWithIdentity(product));
                int? categoryId = GetCategoryIdByName(categoryName)?.Id;
                int? supplierId = GetSupplierByName(supplierName)?.Id;
                if (!categoryId.HasValue)
                {
                    var category = new Category()
                    {
                        Name = categoryName
                    };
                    categoryId = Convert.ToInt32(dbConnection.InsertWithIdentity(category));
                }
                if (!supplierId.HasValue)
                {
                    var supplier = new Supplier()
                    {
                        Name = supplierName
                    };
                   supplierId = Convert.ToInt32(dbConnection.InsertWithIdentity(supplier));
                }

                dbConnection.Products
                 .Where(p => p.Id == productId)
                 .Set(p => p.CategoryId,categoryId.Value)
                 .Set(p => p.SupplierId, supplierId.Value)
                 .Update();

                return productId;
            }
        }
    }
}
