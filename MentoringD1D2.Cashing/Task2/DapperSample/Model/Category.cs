using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using static Dapper.SqlMapper;

namespace LinqToDBSample.Model
{
	public class Categories
	{
		public int CategoryID { get; set; }
		public string CategoryName { get; set; }
		public  string Description { get; set; }
		public byte[] Picture { get; set; }
	}
}
