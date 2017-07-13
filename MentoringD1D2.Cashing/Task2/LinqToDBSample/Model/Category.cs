using LinqToDB.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqToDBSample.Model
{
	[Table("Northwind.Categories")]
	public class Category
	{
		[PrimaryKey]
		[Identity]
		[Column("CategoryID")]
		public int Id { get; set; }
		[Column("CategoryName")]
		public string Name { get; set; }
		[Column]
		public  string Description { get; set; }
		[Column]
		public byte[] Picture { get; set; }
	}
}
