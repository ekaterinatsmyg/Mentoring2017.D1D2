using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using MentoringD1D2.LINQ.Task1.Data.Data;
using MentoringD1D2.LINQ.Task1.Data.Models;
using MentoringD1D2.LINQ.Task1.Diagnostics;
using MentoringD1D2.LINQ.Task1.Diagnostics.Enums;

namespace MentoringD1D2.LINQ.Task1.Helpers
{
    /// <summary>
    /// The helper for entities managment
    /// </summary>
    public static class LinqHelper
    {
        /// <summary>
        /// Get the list of products that have sum of total price of their orders is grater than <paramref name="totalOrderPrice"/>.
        /// </summary>
        /// <param name="clients">The initial list of products.</param>
        /// <param name="totalOrderPrice">The value of total order's price of the client.</param>
        /// <returns>The list of products that have sum of total price of their orders is grater than <paramref name="totalOrderPrice"/>.</returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static List<ClientModel> TakeIfTotalOrderPriceGraterThen(this IList<ClientModel> clients, decimal totalOrderPrice)
        {
            if (clients == null)
            {
                throw new ArgumentNullException(nameof(clients));
            }
            var result = clients.Where(c => c.Orders.Sum(o => o.TotalPrice) > totalOrderPrice).ToList();
            return result;
        }

        /// <summary>
        /// Find providers that are in the same city and country as clients.
        /// </summary>
        /// <param name="clients">The list of clients.</param>
        /// <param name="providers">The list of providers.</param>
        /// <returns>The dictionsry, where the keys are clients and values are providers in the samecity andcontry.</returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static Dictionary<ClientModel, List<ProviderModel>> FindProvidersInTheSameCity(this IList<ClientModel> clients, IList<ProviderModel> providers)
        {
            if (clients == null)
            {
                throw new ArgumentNullException(nameof(clients));
            }
            return clients.Join(providers, c => new { c.City, c.Country },
                     p => new { p.City, p.Country }, (c, p) => new { Clients = c, Providers = p }).GroupBy(r => r.Clients)
                                                                                                .ToDictionary(k => k.Key, k => k.Select(p => p.Providers).ToList());
        }


        /// <summary>
        /// Find providers that are in the same city and country as clients.
        /// </summary>
        /// <param name="clients">The list of clients.</param>
        /// <param name="providers">The list of providers.</param>
        /// <returns>The dictionsry, where the keys are clients and values are providers in the samecity andcontry.</returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static ILookup<ClientModel, ProviderModel> FindProvidersInTheSameCityWihoutGrouping(this IList<ClientModel> clients, IList<ProviderModel> providers)
        {
            if (clients == null)
            {
                throw new ArgumentNullException(nameof(clients));
            }
            if (providers == null)
            {
                throw new ArgumentNullException(nameof(providers));
            }
            return clients.Join(providers, c => new { c.City, c.Country },
                     p => new { p.City, p.Country }, (c, p) => new { Clients = c, Providers = p }).ToLookup(r => r.Clients, r => r.Providers);
        }


        /// <summary>
        /// Get the list of products that have any orders where  total price is grater than <paramref name="orderPrice"/>.
        /// </summary>
        /// <param name="clients">The initial list of products.</param>
        /// <param name="orderPrice">The value of total order's price of the client.</param>
        /// <returns>The list of products that have any orders where  total price is grater than <paramref name="orderPrice"/>.</returns>
        public static List<ClientModel> TakeIfOrderPriceGraterThen(this IList<ClientModel> clients, decimal orderPrice)
        {
            if (clients == null)
            {
                throw new ArgumentNullException(nameof(clients));
            }
            var result = clients.Where(c => c.Orders.Any(o => o.TotalPrice > orderPrice)).ToList();
            return result;
        }


        /// <summary>
        /// Find first day of a client and ordering by <paramref name="ordering"/>.
        /// </summary>
        /// <param name="clients">The list of clients.</param>
        /// <param name="ordering">The way ofordering results.</param>
        /// <returns>The dictionary, where the keys are first day of client and values are clients ordered by <paramref name="ordering"/>.</returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static ILookup<DateTime, ClientModel> FindFirstDayOfClients(this IList<ClientModel> clients, ClientOrdering ordering = ClientOrdering.ByFirstOrderDate)
        {
            if (clients == null)
            {
                throw new ArgumentNullException(nameof(clients));
            }
            var result =
                clients.Where(c => c.Orders.Any())
                    .Select(x => new { FirstDay = x.Orders.Min(o => o.OrderDate), Client = x });

            switch (ordering)
            {
                
                case ClientOrdering.ByFirstOrderDate:
                    result = result.OrderBy(x => x.FirstDay);
                    break;

                case ClientOrdering.ByMonthOfFirstOrderDate:
                    result = result.OrderBy(x => x.FirstDay.Month);
                    break;

                case ClientOrdering.ByYearOfFirstOrderDate:
                    result = result.OrderBy(x => x.FirstDay.Year);
                    break;

                case ClientOrdering.ByNameOfClient:
                    result = result.OrderBy(x => x.Client.CompanyName);
                    break;

                case ClientOrdering.ByTurnoverOfClient:
                    result = result.OrderBy(x => x.Client.Orders.Sum(o => o.TotalPrice));
                    break;

            }
            return result.ToLookup(e => e.FirstDay, e => e.Client);
        }

        /// <summary>
        /// Get the list of cients that don't have numeric postal code or region isn't defined or phone number without code.
        /// </summary>
        /// <param name="clients">The initial list of products.</param>
        /// <returns>The list of products with incorrect contact info.</returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static List<ClientModel> GetClientsWithIncorrectContactInfo(this IList<ClientModel> clients)
        {
            if (clients == null)
            {
                throw new ArgumentNullException(nameof(clients));
            }
            return clients.Where(c => (String.IsNullOrEmpty(c.Region) || String.IsNullOrEmpty(c.PostalCode) || !c.PostalCode.IsNumeric() || String.IsNullOrEmpty(c.PhoneNumber) || !c.PhoneNumber.IsPhoneNumber())).ToList();
        }

        /// <summary>
        /// Group by Category of the product then by total number of units that are in stock and sort by price.
        /// </summary>
        /// <param name="products">The initial list of products.</param>
        /// <returns>The list of products that is grouped by Category than by total number of units that are in stock and sorted by price.</returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static ILookup<string, Dictionary<int,List<ProductModel>>> GetGroupedProducts(this IList<ProductModel> products)
        {
            if (products == null)
            {
                throw new ArgumentNullException(nameof(products));
            }
            return products.ToLookup(p => p.Category)
                            .ToLookup(p1 => p1.Key, p1 => p1.GroupBy(x => x.TotalInStock).ToDictionary(k => k.Key, k => k.OrderBy(p => p.UnitPrice).ToList()));
        }

        /// <summary>
        /// Get productes groupedby price. 
        /// </summary>
        /// <param name="products">The initial list of products.</param>
        /// <returns>The dictionary where keys are the price range of products, and values are prodects.</returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static Dictionary<PriceRange, List<ProductModel>> GroupByPriceCategory(this IList<ProductModel> products)
        {
            if (products == null)
            {
                throw new ArgumentNullException(nameof(products));
            }
            return
                products.Select(p =>
                {
                    if (p.UnitPrice < 70000M)
                        return new KeyValuePair<PriceRange, ProductModel>(PriceRange.Low, p);
                    if (p.UnitPrice < 150000M)
                        return new KeyValuePair<PriceRange, ProductModel>(PriceRange.Middle, p);
                    return new KeyValuePair<PriceRange, ProductModel>(PriceRange.High, p);
                }).GroupBy(res => res.Key).ToDictionary(x => x.Key, x => x.Select(res=> res.Value).ToList());
        }

        /// <summary>
        /// Calculate the profitability of the city.
        /// </summary>
        /// <param name="clients">The initial list of clients.</param>
        /// <returns>The dictionary, where the keys are the city where <paramref name="clients"/> are placed and values average total orders' price.</returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static Dictionary<string, decimal> GetProfitabilityOfTheCity(this IList<ClientModel> clients)
        {
            if (clients == null)
            {
                throw new ArgumentNullException(nameof(clients));
            }
            return clients.GroupBy(c => c.City).OrderBy(c => c.Key).ToDictionary(res => res.Key, res => res.SelectMany(r => r.Orders).Select(o => o.TotalPrice).Average());

        }


        /// <summary>
        /// Calculate the intensit of the city within the client.
        /// </summary>
        /// <param name="clients">The initial list of clients.</param>
        /// <returns>The dictionary, where the keys are the city where <paramref name="clients"/> are placed and values average total orders' count of the client.</returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static Dictionary<string, double> GetIntensityOfOrdersByCity(this IList<ClientModel> clients)
        {
            if (clients == null)
            {
                throw new ArgumentNullException(nameof(clients));
            }
            return clients.GroupBy(c => c.City).OrderBy(c => c.Key).ToDictionary(res => res.Key, res => res.Select(r => r.Orders.Count()).Average());
        }

        public static ILookup<int, KeyValuePair<ClientModel, int>> GetClientStatisticsByMonth(this IList<ClientModel> clients)
        {
            if (clients == null)
            {
                throw new ArgumentNullException(nameof(clients));
            }
            return clients.GroupBy(c => c.Orders.SelectMany(o => o.OrderDate.Month));

        }


        /// <summary>
        /// Verify if the string is numeric.
        /// </summary>
        /// <param name="value">The input string.</param>
        /// <returns>Returns true if the string is numeric, if no - false.</returns>
        /// <exception cref="ArgumentNullException"></exception>
        private static bool IsNumeric(this string value)
        {
            if (value == null)
            {
                throw new ArgumentNullException(nameof(value));
            }
            const string pattern = @"^\d+[\.,-]*\d+$";
            const RegexOptions options = RegexOptions.Compiled | RegexOptions.IgnoreCase | RegexOptions.ExplicitCapture;
            Regex isNumericRegex = new Regex(pattern, options);
            return isNumericRegex.IsMatch(value);
        }

        /// <summary>
        /// Verify if the string is phone number.
        /// </summary>
        /// <param name="value">The input string.</param>
        /// <returns>Returns true if the string is phone number, if no - false.</returns>
        /// <exception cref="ArgumentNullException"></exception>
        private static bool IsPhoneNumber(this string value)
        {
            if (value == null)
            {
                throw new ArgumentNullException(nameof(value));
            }
            const string pattern = @"^\(\d{1,3}\)[ \d]+[\.,-]*\d$";
            const RegexOptions options = RegexOptions.Compiled | RegexOptions.IgnoreCase | RegexOptions.ExplicitCapture;
            Regex isPhoneNumberRegex = new Regex(pattern, options);
            return isPhoneNumberRegex.IsMatch(value);
        }

        
    }
}
