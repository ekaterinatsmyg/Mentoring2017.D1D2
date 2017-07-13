using LinqToDB.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqToDBSample.Model
{
	[Table("Northwind.Products")]
	public class Product
	{
		[Column("ProductID"), Identity, PrimaryKey]
		public int Id { get; set; }
		[Column("ProductName")]
		public string Name { get; set; }
		[Association(ThisKey = "CategoryID", OtherKey = "Id")]
		public Category Category { get; set; }
		[Column]
		public int CategoryID { get; set; }
		[Column]
		public string QuantityPerUnit { get; set; }
		[Column]
		public decimal? UnitPrice { get; set; }
		[Column]
		public int? UnitsInStock { get; set; }
		[Column]
		public int? UnitsOnOrder { get; set; }
		[Column]
		public int? ReorderLevel { get; set; }
		[Column]
		public bool Discontinued { get; set; }
	}
}
