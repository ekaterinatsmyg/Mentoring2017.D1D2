using System.Collections.Generic;
using System.Runtime.Caching;

namespace CachingSolutionsSamples.Cashing
{
    public interface IMemoryCacheService<T>
    {
        IEnumerable<T> Get(string key);
        void Set(string key, IEnumerable<T> value, CacheItemPolicy policy);
    }
}
