using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Caching;
using System.Text;
using System.Threading.Tasks;
using Cashing.Task2.Diagnostics;

//using Cashing.Task2.Diagnostics;


namespace CachingSolutionsSamples.Cashing
{
    public class MemoryCacheService<T> : IMemoryCacheService<T>
    {
        #region Fields
        
        private ObjectCache _memoryCache = MemoryCache.Default;

        #endregion

        #region Methods

        /// <summary>
        /// Get the object from cash by key.
        /// </summary>
        /// <param name="key">The key of the stored in the cache object.</param>
        /// <returns>The stored in the cache object.</returns>
        public IEnumerable<T> Get(string key)
        {
            if (string.IsNullOrEmpty(key))
            {
                ApplicationLogger.LogMessage(LogMessageType.Error, $"Invalid key: {key}");
                throw new ArgumentException(nameof(key));
            }

            var item = _memoryCache.Get(key)  as IEnumerable<T>;
            if (item == null)
            {
                ApplicationLogger.LogMessage(LogMessageType.Warn, $"The object with {key} key doesn't exist.");
            }
            return item;
        }

        /// <summary>
        /// Put into cahce a fibonacci value.
        /// </summary>
        /// <param name="key">The key that will store in the cache and connected with requested object.</param>
        /// <param name="value">The object that should be put into cache.</param>
        /// <param name="policy"></param>
        public void Set(string key, IEnumerable<T> value, CacheItemPolicy policy)
        {
            if (string.IsNullOrEmpty(key))
            {
                ApplicationLogger.LogMessage(LogMessageType.Error, $"Invalid key: {key}");
                throw new ArgumentException(nameof(key));
            }

            if (value == null)
            {
                ApplicationLogger.LogMessage(LogMessageType.Warn, "Trying to put into cahce null");
                return;
            }

            _memoryCache.Set(key, value, policy);
            ApplicationLogger.LogMessage(LogMessageType.Info, $"The value: {value} was added to cache with the {key}.");
        }

        #endregion 
    }
}
