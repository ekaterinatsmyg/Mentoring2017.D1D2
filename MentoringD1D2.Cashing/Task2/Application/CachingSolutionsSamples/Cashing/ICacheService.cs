using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CachingSolutionsSamples.Cashing
{
    public interface ICacheService<T>
    {
        IEnumerable<T> Get(string key);
        void Set(string key, IEnumerable<T> value);
    }
}
