using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MentoringD1D2.Cashing.Interfaces
{
	public interface ICache<T> 
	{
		IEnumerable<T> Get(string key);
		void Set(string key, IEnumerable<T> value);
	}
}
