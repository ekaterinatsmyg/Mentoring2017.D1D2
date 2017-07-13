using LinqToDB;
using LinqToDB.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqToDBSample.Model
{
	public class Northwind	: DataConnection
	{
		public Northwind() : base("Northwind") { }

		public ITable<Category> Categories { get { return GetTable<Category>(); } }
		public ITable<Product> Products { get { return GetTable<Product>(); } }
	}
}
