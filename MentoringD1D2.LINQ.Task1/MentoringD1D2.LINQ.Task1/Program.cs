using System;
using System.CodeDom;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MentoringD1D2.LINQ.Task1.Data.Data;
using MentoringD1D2.LINQ.Task1.Data.Models;
using MentoringD1D2.LINQ.Task1.Diagnostics;
using MentoringD1D2.LINQ.Task1.Diagnostics.Enums;
using MentoringD1D2.LINQ.Task1.Helpers;

namespace MentoringD1D2.LINQ.Task1
{
    class Program
    {
        static void Main(string[] args)
        {
            DataSet dataSet = new DataSet();
            var clients = dataSet.Clients;
            var providers = dataSet.Providers;
            var products = dataSet.Products;

            List<ClientModel> filteredClients = new List<ClientModel>();

            //1.The first point
            //try
            //{

            //    filteredClients = clients.TakeIfTotalOrderPriceGraterThen(15);
            //    List<ClientModel> clients1 = null;
            //    var r1 = clients1.TakeIfTotalOrderPriceGraterThen(12);
            //}
            //catch (ArgumentNullException exception)
            //{
            //    ApplicationLogger.LogMessage(LogMessageType.Error, $"Error: {exception.Message} | StackTrace: {exception.StackTrace}");
            //}
            //filteredClients?.ForEach(r => Console.WriteLine(r.ToString()));

            //2. The second point 
            //var resultSet = clients.FindProvidersInTheSameCity(providers);
            //foreach (var res in resultSet)
            //{
            //    Console.WriteLine($"----{res.Key.ClientId}---- {Environment.NewLine} Country : {res.Key.Country} | City : {res.Key.City}");
            //    for (int i = 0; i < res.Value.Count(); i++)
            //    {
            //        Console.WriteLine($"{i + 1}. {res.Value[i].ToString()}");
            //    }
            //}

            //2.a The second point
            //var resultSet1 = clients.FindProvidersInTheSameCityWihoutGrouping(providers);
            //foreach (var res in resultSet1)
            //{
            //    Console.WriteLine($"----{res.Key.ClientId}---- {Environment.NewLine} Country : {res.Key.Country} | City : {res.Key.City}");
            //    foreach (var r in res)
            //    {
            //        Console.WriteLine(r.ToString());
            //    }
            //}

            //3. The third point
            //try
            //{

            //    filteredClients = clients.TakeIfOrderPriceGraterThen(1500);
            //    List<ClientModel> clients1 = null;
            //    var r1 = clients1.TakeIfOrderPriceGraterThen(1200);
            //}
            //catch (ArgumentNullException exception)
            //{
            //    ApplicationLogger.LogMessage(LogMessageType.Error, $"Error: {exception.Message} | StackTrace: {exception.StackTrace}");
            //}
            //filteredClients?.ForEach(r => Console.WriteLine(r.ToString()));
            //if (filteredClients != null)
            //    foreach (var res in filteredClients)
            //    {
            //        Console.WriteLine(res.ToString());
            //        foreach (var order in res.Orders)
            //        {
            //            Console.WriteLine(order.ToString());
            //        }
            //    }

            ////4&5.The forth & fifth point
            //Console.WriteLine("---------ByDate-----------");
            //var firstDay = clients.FindFirstDayOfClients();
            //if (firstDay != null)
            //    foreach (var res in firstDay)
            //    {
            //        Console.WriteLine(res.Key.ToString("yyyy'-'MM'-'dd'T'HH':'mm':'ss"));
            //        foreach (var r in res)
            //        {
            //            Console.WriteLine(r.ToString());
            //        }
            //    }
            //Console.WriteLine("---------ByYear-----------");
            //firstDay = clients.FindFirstDayOfClients(ClientOrdering.ByYearOfFirstOrderDate);
            //if (firstDay != null)
            //    foreach (var res in firstDay)
            //    {
            //        Console.WriteLine(res.Key.ToString("yyyy'-'MM'-'dd'T'HH':'mm':'ss"));
            //        foreach (var r in res)
            //        {
            //            Console.WriteLine(r.ToString());
            //        }
            //    }
            //Console.WriteLine("---------ByMonth----------");
            //firstDay = clients.FindFirstDayOfClients(ClientOrdering.ByMonthOfFirstOrderDate);
            //if (firstDay != null)
            //    foreach (var res in firstDay)
            //    {
            //        Console.WriteLine(res.Key.ToString("yyyy'-'MM'-'dd'T'HH':'mm':'ss"));
            //        foreach (var r in res)
            //        {
            //            Console.WriteLine(r.ToString());
            //        }
            //    }
            //Console.WriteLine("---------ByCompanyName----");
            //firstDay = clients.FindFirstDayOfClients(ClientOrdering.ByNameOfClient);
            //if (firstDay != null)
            //    foreach (var res in firstDay)
            //    {
            //        Console.WriteLine(res.Key.ToString("yyyy'-'MM'-'dd'T'HH':'mm':'ss"));
            //        foreach (var r in res)
            //        {
            //            Console.WriteLine(r.ToString());
            //        }
            //    }
            //Console.WriteLine("---------ByTurnover-------");
            //firstDay = clients.FindFirstDayOfClients(ClientOrdering.ByTurnoverOfClient);
            //if (firstDay != null)
            //    foreach (var res in firstDay)
            //    {
            //        Console.WriteLine(res.Key.ToString("yyyy'-'MM'-'dd'T'HH':'mm':'ss"));
            //        foreach (var r in res)
            //        {
            //            Console.WriteLine(r.ToString());
            //        }
            //    }


            ////6.The sixth point.
            //var result = clients.GetClientsWithIncorrectContactInfo();
            //result.ForEach(r => Console.WriteLine(r.ToString()));

            //7.The seventh point.
            //var groupedProducts = products.GetGroupedProducts();
            //foreach (var groupedproduct in groupedProducts)
            //{
            //    Console.WriteLine($"-------------{groupedproduct.Key}-----------------");
            //    foreach (var product  in groupedproduct)
            //    {
            //        foreach (var p in product)
            //        {
            //            Console.WriteLine(p.Key);
            //            p.Value.ForEach(x => Console.WriteLine(x.ToString()));
            //        }


            //    }
            //}

            //8.The eighth point.
            //var groupedByPriceProducts = products.GroupByPriceCategory();
            //foreach (var product in groupedByPriceProducts)
            //{
            //    Console.WriteLine(product.Key);
            //    product.Value.ForEach(res => Console.WriteLine(res.ToString()));
            //}

            //9 a,b.The ninth point.
            //var profitOfCity = clients.GetProfitabilityOfTheCity();
            //foreach (var profitabilit in profitOfCity)
            //{
            //    Console.WriteLine(profitabilit.Key);

            //    Console.WriteLine(profitabilit.Value);
            //}

            //var intensityOfCity = clients.GetIntensityOfOrdersByCity();
            //foreach (var intensity in intensityOfCity)
            //{
            //    Console.WriteLine(intensity.Key);

            //    Console.WriteLine(intensity.Value);
            //}


            //10. The tenth point.
            var result = clients.GetClientStatisticsByMonth();
            foreach (var res in result)
            {
                foreach (var key in res.Key)
                {
                    Console.WriteLine(key);
                    foreach (var k in res.Select(x =>x).ToList())
                    {
                        Console.WriteLine(k.Value);
                    }
                }
            }

            Console.ReadKey();
        }
    }
}
