using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using MentoringD1D2.LINQ.Task1.Data.Models;

namespace MentoringD1D2.LINQ.Task1.Data.Data
{
    /// <summary>
    /// The test set of data of models (Client, Product, Provider, Order).
    /// </summary>
    public class DataSet
    {
        #region Fields

        /// <summary>
        /// The list of test products.
        /// </summary>
        private List<ProductModel> products;

        /// <summary>
        /// The list of test clients.
        /// </summary>
        private List<ClientModel> clients;

        /// <summary>
        /// The list of test providers.
        /// </summary>
        private List<ProviderModel> providers;

        #endregion

        #region Properties

        /// <summary>
        /// The list of test products.
        /// </summary>
        public List<ProductModel> Products
        {
            get
            {
                if (products == null)
                    InitilizeProducts();

                return products;
            }
        }

        /// <summary>
        /// The list of test clients.
        /// </summary>
        public List<ClientModel> Clients
        {
            get
            {
                if (clients == null)
                    InitializeClients();

                return clients;
            }
        }


        /// <summary>
        /// The list of test providers.
        /// </summary>
        public List<ProviderModel> Providers
        {
            get
            {
                if (providers == null)
                    InitializeProviders();

                return providers;
            }
        }
        #endregion

        #region Methods

        /// <summary>
        /// Intialize the field products.
        /// </summary>
        private void InitilizeProducts()
        {
            products = new List<ProductModel>
            {
                new ProductModel
                {
                    ProductId = 1,
                    ProductName = "Chai",
                    Category = "Beverages",
                    UnitPrice = 18.0000M,
                    TotalInStock = 39
                },
                new ProductModel
                {
                    ProductId = 2,
                    ProductName = "Chang",
                    Category = "Beverages",
                    UnitPrice = 19.0000M,
                    TotalInStock = 17
                },
                new ProductModel
                {
                    ProductId = 3,
                    ProductName = "Aniseed Syrup",
                    Category = "Condiments",
                    UnitPrice = 10.0000M,
                    TotalInStock = 13
                },
                new ProductModel
                {
                    ProductId = 4,
                    ProductName = "Chef Anton's Cajun Seasoning",
                    Category = "Condiments",
                    UnitPrice = 22.0000M,
                    TotalInStock = 53
                },
                new ProductModel
                {
                    ProductId = 5,
                    ProductName = "Chef Anton's Gumbo Mix",
                    Category = "Condiments",
                    UnitPrice = 21.3500M,
                    TotalInStock = 0
                },
                new ProductModel
                {
                    ProductId = 6,
                    ProductName = "Grandma's Boysenberry Spread",
                    Category = "Condiments",
                    UnitPrice = 25.0000M,
                    TotalInStock = 120
                },
                new ProductModel
                {
                    ProductId = 7,
                    ProductName = "Uncle Bob's Organic Dried Pears",
                    Category = "Produce",
                    UnitPrice = 30.0000M,
                    TotalInStock = 15
                },
                new ProductModel
                {
                    ProductId = 8,
                    ProductName = "Northwoods Cranberry Sauce",
                    Category = "Condiments",
                    UnitPrice = 40.0000M,
                    TotalInStock = 6
                },
                new ProductModel
                {
                    ProductId = 9,
                    ProductName = "Mishi Kobe Niku",
                    Category = "Meat/Poultry",
                    UnitPrice = 97.0000M,
                    TotalInStock = 29
                },
                new ProductModel
                {
                    ProductId = 10,
                    ProductName = "Ikura",
                    Category = "Seafood",
                    UnitPrice = 31.0000M,
                    TotalInStock = 31
                },
                new ProductModel
                {
                    ProductId = 11,
                    ProductName = "Queso Cabrales",
                    Category = "Dairy ProductModels",
                    UnitPrice = 21.0000M,
                    TotalInStock = 22
                },
                new ProductModel
                {
                    ProductId = 12,
                    ProductName = "Queso Manchego La Pastora",
                    Category = "Dairy ProductModels",
                    UnitPrice = 38.0000M,
                    TotalInStock = 86
                },
                new ProductModel
                {
                    ProductId = 13,
                    ProductName = "Konbu",
                    Category = "Seafood",
                    UnitPrice = 6.0000M,
                    TotalInStock = 24
                },
                new ProductModel
                {
                    ProductId = 14,
                    ProductName = "Tofu",
                    Category = "Produce",
                    UnitPrice = 23.2500M,
                    TotalInStock = 35
                },
                new ProductModel
                {
                    ProductId = 15,
                    ProductName = "Genen Shouyu",
                    Category = "Condiments",
                    UnitPrice = 15.5000M,
                    TotalInStock = 39
                },
                new ProductModel
                {
                    ProductId = 16,
                    ProductName = "Pavlova",
                    Category = "Confections",
                    UnitPrice = 17.4500M,
                    TotalInStock = 29
                },
                new ProductModel
                {
                    ProductId = 17,
                    ProductName = "Alice Mutton",
                    Category = "Meat/Poultry",
                    UnitPrice = 39.0000M,
                    TotalInStock = 0
                },
                new ProductModel
                {
                    ProductId = 18,
                    ProductName = "Carnarvon Tigers",
                    Category = "Seafood",
                    UnitPrice = 62.5000M,
                    TotalInStock = 42
                },
                new ProductModel
                {
                    ProductId = 19,
                    ProductName = "Teatime Chocolate Biscuits",
                    Category = "Confections",
                    UnitPrice = 9.2000M,
                    TotalInStock = 25
                },
                new ProductModel
                {
                    ProductId = 20,
                    ProductName = "Sir Rodney's Marmalade",
                    Category = "Confections",
                    UnitPrice = 81.0000M,
                    TotalInStock = 40
                },
                new ProductModel
                {
                    ProductId = 21,
                    ProductName = "Sir Rodney's Scones",
                    Category = "Confections",
                    UnitPrice = 10.0000M,
                    TotalInStock = 3
                },
                new ProductModel
                {
                    ProductId = 22,
                    ProductName = "Gustaf's Knäckebröd",
                    Category = "Grains/Cereals",
                    UnitPrice = 21.0000M,
                    TotalInStock = 104
                },
                new ProductModel
                {
                    ProductId = 23,
                    ProductName = "Tunnbröd",
                    Category = "Grains/Cereals",
                    UnitPrice = 9.0000M,
                    TotalInStock = 61
                },
                new ProductModel
                {
                    ProductId = 24,
                    ProductName = "Guaraná Fantástica",
                    Category = "Beverages",
                    UnitPrice = 4.5000M,
                    TotalInStock = 20
                },
                new ProductModel
                {
                    ProductId = 25,
                    ProductName = "NuNuCa Nuß-Nougat-Creme",
                    Category = "Confections",
                    UnitPrice = 14.0000M,
                    TotalInStock = 76
                },
                new ProductModel
                {
                    ProductId = 26,
                    ProductName = "Gumbär Gummibärchen",
                    Category = "Confections",
                    UnitPrice = 31.2300M,
                    TotalInStock = 15
                },
                new ProductModel
                {
                    ProductId = 27,
                    ProductName = "Schoggi Schokolade",
                    Category = "Confections",
                    UnitPrice = 43.9000M,
                    TotalInStock = 49
                },
                new ProductModel
                {
                    ProductId = 28,
                    ProductName = "Rössle Sauerkraut",
                    Category = "Produce",
                    UnitPrice = 45.6000M,
                    TotalInStock = 26
                },
                new ProductModel
                {
                    ProductId = 29,
                    ProductName = "Thüringer Rostbratwurst",
                    Category = "Meat/Poultry",
                    UnitPrice = 123.7900M,
                    TotalInStock = 0
                },
                new ProductModel
                {
                    ProductId = 30,
                    ProductName = "Nord-Ost Matjeshering",
                    Category = "Seafood",
                    UnitPrice = 25.8900M,
                    TotalInStock = 10
                },
                new ProductModel
                {
                    ProductId = 31,
                    ProductName = "Gorgonzola Telino",
                    Category = "Dairy ProductModels",
                    UnitPrice = 12.5000M,
                    TotalInStock = 0
                },
                new ProductModel
                {
                    ProductId = 32,
                    ProductName = "Mascarpone Fabioli",
                    Category = "Dairy ProductModels",
                    UnitPrice = 32.0000M,
                    TotalInStock = 9
                },
                new ProductModel
                {
                    ProductId = 33,
                    ProductName = "Geitost",
                    Category = "Dairy ProductModels",
                    UnitPrice = 2.5000M,
                    TotalInStock = 112
                },
                new ProductModel
                {
                    ProductId = 34,
                    ProductName = "Sasquatch Ale",
                    Category = "Beverages",
                    UnitPrice = 14.0000M,
                    TotalInStock = 111
                },
                new ProductModel
                {
                    ProductId = 35,
                    ProductName = "Steeleye Stout",
                    Category = "Beverages",
                    UnitPrice = 18.0000M,
                    TotalInStock = 20
                },
                new ProductModel
                {
                    ProductId = 36,
                    ProductName = "Inlagd Sill",
                    Category = "Seafood",
                    UnitPrice = 19.0000M,
                    TotalInStock = 112
                },
                new ProductModel
                {
                    ProductId = 37,
                    ProductName = "Gravad lax",
                    Category = "Seafood",
                    UnitPrice = 26.0000M,
                    TotalInStock = 11
                },
                new ProductModel
                {
                    ProductId = 38,
                    ProductName = "Côte de Blaye",
                    Category = "Beverages",
                    UnitPrice = 263.5000M,
                    TotalInStock = 17
                },
                new ProductModel
                {
                    ProductId = 39,
                    ProductName = "Chartreuse verte",
                    Category = "Beverages",
                    UnitPrice = 18.0000M,
                    TotalInStock = 69
                },
                new ProductModel
                {
                    ProductId = 40,
                    ProductName = "Boston Crab Meat",
                    Category = "Seafood",
                    UnitPrice = 18.4000M,
                    TotalInStock = 123
                },
                new ProductModel
                {
                    ProductId = 41,
                    ProductName = "Jack's New England Clam Chowder",
                    Category = "Seafood",
                    UnitPrice = 9.6500M,
                    TotalInStock = 85
                },
                new ProductModel
                {
                    ProductId = 42,
                    ProductName = "Singaporean Hokkien Fried Mee",
                    Category = "Grains/Cereals",
                    UnitPrice = 14.0000M,
                    TotalInStock = 26
                },
                new ProductModel
                {
                    ProductId = 43,
                    ProductName = "Ipoh Coffee",
                    Category = "Beverages",
                    UnitPrice = 46.0000M,
                    TotalInStock = 17
                },
                new ProductModel
                {
                    ProductId = 44,
                    ProductName = "Gula Malacca",
                    Category = "Condiments",
                    UnitPrice = 19.4500M,
                    TotalInStock = 27
                },
                new ProductModel
                {
                    ProductId = 45,
                    ProductName = "Rogede sild",
                    Category = "Seafood",
                    UnitPrice = 9.5000M,
                    TotalInStock = 5
                },
                new ProductModel
                {
                    ProductId = 46,
                    ProductName = "Spegesild",
                    Category = "Seafood",
                    UnitPrice = 12.0000M,
                    TotalInStock = 95
                },
                new ProductModel
                {
                    ProductId = 47,
                    ProductName = "Zaanse koeken",
                    Category = "Confections",
                    UnitPrice = 9.5000M,
                    TotalInStock = 36
                },
                new ProductModel
                {
                    ProductId = 48,
                    ProductName = "Chocolade",
                    Category = "Confections",
                    UnitPrice = 12.7500M,
                    TotalInStock = 15
                },
                new ProductModel
                {
                    ProductId = 49,
                    ProductName = "Maxilaku",
                    Category = "Confections",
                    UnitPrice = 20.0000M,
                    TotalInStock = 10
                },
                new ProductModel
                {
                    ProductId = 50,
                    ProductName = "Valkoinen suklaa",
                    Category = "Confections",
                    UnitPrice = 16.2500M,
                    TotalInStock = 65
                },
                new ProductModel
                {
                    ProductId = 51,
                    ProductName = "Manjimup Dried Apples",
                    Category = "Produce",
                    UnitPrice = 53.0000M,
                    TotalInStock = 20
                },
                new ProductModel
                {
                    ProductId = 52,
                    ProductName = "Filo Mix",
                    Category = "Grains/Cereals",
                    UnitPrice = 7.0000M,
                    TotalInStock = 38
                },
                new ProductModel
                {
                    ProductId = 53,
                    ProductName = "Perth Pasties",
                    Category = "Meat/Poultry",
                    UnitPrice = 32.8000M,
                    TotalInStock = 0
                },
                new ProductModel
                {
                    ProductId = 54,
                    ProductName = "Tourtière",
                    Category = "Meat/Poultry",
                    UnitPrice = 7.4500M,
                    TotalInStock = 21
                },
                new ProductModel
                {
                    ProductId = 55,
                    ProductName = "Pâté chinois",
                    Category = "Meat/Poultry",
                    UnitPrice = 24.0000M,
                    TotalInStock = 115
                },
                new ProductModel
                {
                    ProductId = 56,
                    ProductName = "Gnocchi di nonna Alice",
                    Category = "Grains/Cereals",
                    UnitPrice = 38.0000M,
                    TotalInStock = 21
                },
                new ProductModel
                {
                    ProductId = 57,
                    ProductName = "Ravioli Angelo",
                    Category = "Grains/Cereals",
                    UnitPrice = 19.5000M,
                    TotalInStock = 36
                },
                new ProductModel
                {
                    ProductId = 58,
                    ProductName = "Escargots de Bourgogne",
                    Category = "Seafood",
                    UnitPrice = 13.2500M,
                    TotalInStock = 62
                },
                new ProductModel
                {
                    ProductId = 59,
                    ProductName = "Raclette Courdavault",
                    Category = "Dairy ProductModels",
                    UnitPrice = 55.0000M,
                    TotalInStock = 79
                },
                new ProductModel
                {
                    ProductId = 60,
                    ProductName = "Camembert Pierrot",
                    Category = "Dairy ProductModels",
                    UnitPrice = 34.0000M,
                    TotalInStock = 19
                },
                new ProductModel
                {
                    ProductId = 61,
                    ProductName = "Sirop d'érable",
                    Category = "Condiments",
                    UnitPrice = 28.5000M,
                    TotalInStock = 113
                },
                new ProductModel
                {
                    ProductId = 62,
                    ProductName = "Tarte au sucre",
                    Category = "Confections",
                    UnitPrice = 49.3000M,
                    TotalInStock = 17
                },
                new ProductModel
                {
                    ProductId = 63,
                    ProductName = "Vegie-spread",
                    Category = "Condiments",
                    UnitPrice = 43.9000M,
                    TotalInStock = 24
                },
                new ProductModel
                {
                    ProductId = 64,
                    ProductName = "Wimmers gute Semmelknödel",
                    Category = "Grains/Cereals",
                    UnitPrice = 33.2500M,
                    TotalInStock = 22
                },
                new ProductModel
                {
                    ProductId = 65,
                    ProductName = "Louisiana Fiery Hot Pepper Sauce",
                    Category = "Condiments",
                    UnitPrice = 21.0500M,
                    TotalInStock = 76
                },
                new ProductModel
                {
                    ProductId = 66,
                    ProductName = "Louisiana Hot Spiced Okra",
                    Category = "Condiments",
                    UnitPrice = 17.0000M,
                    TotalInStock = 4
                },
                new ProductModel
                {
                    ProductId = 67,
                    ProductName = "Laughing Lumberjack Lager",
                    Category = "Beverages",
                    UnitPrice = 14.0000M,
                    TotalInStock = 52
                },
                new ProductModel
                {
                    ProductId = 68,
                    ProductName = "Scottish Longbreads",
                    Category = "Confections",
                    UnitPrice = 12.5000M,
                    TotalInStock = 6
                },
                new ProductModel
                {
                    ProductId = 69,
                    ProductName = "Gudbrandsdalsost",
                    Category = "Dairy ProductModels",
                    UnitPrice = 36.0000M,
                    TotalInStock = 26
                },
                new ProductModel
                {
                    ProductId = 70,
                    ProductName = "Outback Lager",
                    Category = "Beverages",
                    UnitPrice = 15.0000M,
                    TotalInStock = 15
                },
                new ProductModel
                {
                    ProductId = 71,
                    ProductName = "Flotemysost",
                    Category = "Dairy ProductModels",
                    UnitPrice = 21.5000M,
                    TotalInStock = 26
                },
                new ProductModel
                {
                    ProductId = 72,
                    ProductName = "Mozzarella di Giovanni",
                    Category = "Dairy ProductModels",
                    UnitPrice = 34.8000M,
                    TotalInStock = 14
                },
                new ProductModel
                {
                    ProductId = 73,
                    ProductName = "Röd Kaviar",
                    Category = "Seafood",
                    UnitPrice = 15.0000M,
                    TotalInStock = 101
                },
                new ProductModel
                {
                    ProductId = 74,
                    ProductName = "Longlife Tofu",
                    Category = "Produce",
                    UnitPrice = 10.0000M,
                    TotalInStock = 4
                },
                new ProductModel
                {
                    ProductId = 75,
                    ProductName = "Rhönbräu Klosterbier",
                    Category = "Beverages",
                    UnitPrice = 7.7500M,
                    TotalInStock = 125
                },
                new ProductModel
                {
                    ProductId = 76,
                    ProductName = "Lakkalikööri",
                    Category = "Beverages",
                    UnitPrice = 18.0000M,
                    TotalInStock = 57
                },
                new ProductModel
                {
                    ProductId = 77,
                    ProductName = "Original Frankfurter grüne Soße",
                    Category = "Condiments",
                    UnitPrice = 13.0000M,
                    TotalInStock = 32
                }
            };
        }

        /// <summary>
        /// Intialize the field clients.
        /// </summary>
        private void InitializeClients()
        {
            XDocument document = XDocument.Load("Customers.xml");
            var xmlElement = document.Root?.Elements("customer");
            if (xmlElement != null)
               clients = (from e in xmlElement
                          select new ClientModel()
                {
                    ClientId = (string)e.Element("id"),
                    CompanyName = (string)e.Element("name"),
                    Address = (string)e.Element("address"),
                    City = (string)e.Element("city"),
                    Region = (string)e.Element("region"),
                    PostalCode = (string)e.Element("postalcode"),
                    Country = (string)e.Element("country"),
                    PhoneNumber = (string)e.Element("phone"),
                    Fax = (string)e.Element("fax"),
                    Orders = (
                        from o in e.Elements("orders").Elements("order")
                        select new OrderModel()
                        {
                            OrderId = Convert.ToInt32((string)o.Element("id")),
                            OrderDate = DateTime.ParseExact((string)o.Element("orderdate"), "yyyy'-'MM'-'dd'T'HH':'mm':'ss", CultureInfo.InvariantCulture),
                            TotalPrice = Convert.ToDecimal((string)o.Element("total"))
                        })
                        .ToArray()
                }).ToList();
            else
            {
                clients = new List<ClientModel>();
            }
        }

        /// <summary>
        /// Intialize the field providers.
        /// </summary>
        private void InitializeProviders()
        {
            providers = new List<ProviderModel>(){
                    new ProviderModel {ProviderName = "Exotic Liquids", Address = "49 Gilbert St.", City = "London", Country = "UK"},
                    new ProviderModel {ProviderName = "Sherlock Holmes", Address = "12 Baker Street 221b", City = "London", Country = "UK"},
                    new ProviderModel {ProviderName = "New Orleans Cajun Delights", Address = "P.O. Box 78934", City = "New Orleans", Country = "USA"},
                    new ProviderModel {ProviderName = "Grandma Kelly's Homestead", Address = "707 Oxford Rd.", City = "Ann Arbor", Country = "USA"},
                    new ProviderModel {ProviderName = "Tokyo Traders", Address = "9-8 Sekimai Musashino-shi", City = "Tokyo", Country = "Japan"},
                    new ProviderModel {ProviderName = "Cooperativa de Quesos 'Las Cabras'", Address = "Calle del Rosal 4", City = "Oviedo", Country = "Spain"},
                    new ProviderModel {ProviderName = "Mayumi's", Address = "92 Setsuko Chuo-ku", City = "Osaka", Country = "Japan"},
                    new ProviderModel {ProviderName = "Pavlova, Ltd.", Address = "74 Rose St. Moonie Ponds", City = "Melbourne", Country = "Australia"},
                    new ProviderModel {ProviderName = "Specialty Biscuits, Ltd.", Address = "29 King's Way", City = "Manchester", Country = "UK"},
                    new ProviderModel {ProviderName = "PB Knäckebröd AB", Address = "Kaloadagatan 13", City = "Göteborg", Country = "Sweden"},
                    new ProviderModel {ProviderName = "Refrescos Americanas LTDA", Address = "Av. das Americanas 12.890", City = "Sao Paulo", Country = "Brazil"},
                    new ProviderModel {ProviderName = "Heli Süßwaren GmbH & Co. KG", Address = "Tiergartenstraße 5", City = "Berlin", Country = "Germany"},
                    new ProviderModel {ProviderName = "Plutzer Lebensmittelgroßmärkte AG", Address = "Bogenallee 51", City = "Frankfurt", Country = "Germany"},
                    new ProviderModel {ProviderName = "Nord-Ost-Fisch Handelsgesellschaft mbH", Address = "Frahmredder 112a", City = "Cuxhaven", Country = "Germany"},
                    new ProviderModel {ProviderName = "Formaggi Fortini s.r.l.", Address = "Viale Dante, 75", City = "Ravenna", Country = "Italy"},
                    new ProviderModel {ProviderName = "Norske Meierier", Address = "Hatlevegen 5", City = "Sandvika", Country = "Norway"},
                    new ProviderModel {ProviderName = "Bigfoot Breweries", Address = "3400 - 8th Avenue Suite 210", City = "Bend", Country = "USA"},
                    new ProviderModel {ProviderName = "Svensk Sjöföda AB", Address = "Brovallavägen 231", City = "Stockholm", Country = "Sweden"},
                    new ProviderModel {ProviderName = "Aux joyeux ecclésiastiques", Address = "203, Rue des Francs-Bourgeois", City = "Paris", Country = "France"},
                    new ProviderModel {ProviderName = "New England Seafood Cannery", Address = "Order Processing Dept. 2100 Paul Revere Blvd.", City = "Boston", Country = "USA"},
                    new ProviderModel {ProviderName = "Leka Trading", Address = "471 Serangoon Loop, Suite #402", City = "Singapore", Country = "Singapore"},
                    new ProviderModel {ProviderName = "Lyngbysild", Address = "Lyngbysild Fiskebakken 10", City = "Lyngby", Country = "Denmark"},
                    new ProviderModel {ProviderName = "Zaanse Snoepfabriek", Address = "Verkoop Rijnweg 22", City = "Zaandam", Country = "Netherlands"},
                    new ProviderModel {ProviderName = "Karkki Oy", Address = "Valtakatu 12", City = "Lappeenranta", Country = "Finland"},
                    new ProviderModel {ProviderName = "G'day, Mate", Address = "170 Prince Edward Parade Hunter's Hill", City = "Sydney", Country = "Australia"},
                    new ProviderModel {ProviderName = "Ma Maison", Address = "2960 Rue St. Laurent", City = "Montréal", Country = "Canada"},
                    new ProviderModel {ProviderName = "Pasta Buttini s.r.l.", Address = "Via dei Gelsomini, 153", City = "Salerno", Country = "Italy"},
                    new ProviderModel {ProviderName = "Escargots Nouveaux", Address = "22, rue H. Voiron", City = "Montceau", Country = "France"},
                    new ProviderModel {ProviderName = "Gai pâturage", Address = "Bat. B 3, rue des Alpes", City = "Annecy", Country = "France"},
                    new ProviderModel {ProviderName = "Forêts d'érables", Address = "148 rue Chasseur", City = "Ste-Hyacinthe", Country = "Canada"},
                };
        }

        #endregion
    }
}
