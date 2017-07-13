using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NHibernate;
using NHibernateSample.Model;
using System.Configuration;
using NHibernate.Linq;
using NHibernate.Criterion;
using System.Linq;

namespace NHibernateSample
{
	[TestClass]
	public class SelectSamples
	{	  
		ISessionFactory sessionFactory;

		[TestInitialize]
		public void Init()
		{
			var t = ConfigurationManager.ConnectionStrings["Northwind"];
			var config = new NHibernate.Cfg.Configuration().Configure();
			sessionFactory = config.BuildSessionFactory();
		}
					

		[TestMethod]
		public void TextQuery()
		{
			var categoryName = "Beverages";

			using (var session = sessionFactory.OpenSession())
			{
				var query = session.CreateQuery("from Product p where p.Category.Name = :categoryName");
				query.SetString("categoryName", categoryName);

				foreach (var c in query.List<Product>()) 
					Console.WriteLine(c.Name + " | " + c.Category.Name);
			}
		}

		[TestMethod]
		public void CriteriaAPIQuery()
		{
			var categoryName = "Beverages";

			using (var session = sessionFactory.OpenSession())
			{
				var query = session.CreateCriteria<Product>();
				query.CreateAlias("Category", "c").Add(Restrictions.Eq("c.Name", categoryName));
													
				foreach (var c in query.List<Product>())
					Console.WriteLine(c.Name + " | " + c.Category.Name);
			}
		}


		[TestMethod]
		public void StructuredCriteriaAPIQuery()
		{
			var categoryName = "Beverages";

			using (var session = sessionFactory.OpenSession())
			{
				var query = session.QueryOver<Product>();
				query.JoinQueryOver(p => p.Category).Where(c => c.Name == categoryName);
				
				foreach (var c in query.List())
					Console.WriteLine(c.Name + " | " + c.Category.Name);
			}
		}

		[TestMethod]
		public void SQLQuery()
		{
			var categoryName = "Beverages";
			var queryString = "select p.* " +
						"from Northwind.Products p " +
						"join Northwind.Categories c on c.CategoryID = p.CategoryID " +
						"where c.CategoryName = :categoryName";

			using (var session = sessionFactory.OpenSession())
			{
				var query = session.CreateSQLQuery(queryString);
				query.SetString("categoryName", categoryName);
				query.AddEntity("p", typeof(Product));

				foreach (var c in query.List<Product>())
					Console.WriteLine(c.Name + " | " + c.Category.Name);
			}
		}

		[TestMethod]
		public void LINQQuery()
		{
			var categoryName = "Beverages";

			using (var session = sessionFactory.OpenSession())
			{
				var query = session.Query<Product>()
					.Where(p => p.Category.Name == categoryName);
				
				foreach (var c in query)
					Console.WriteLine(c.Name + " | " + c.Category.Name);
			}
		}
	}
}
