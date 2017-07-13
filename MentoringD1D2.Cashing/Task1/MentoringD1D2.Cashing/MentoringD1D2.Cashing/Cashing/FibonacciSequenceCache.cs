using System;
using System.Collections.Generic;
using System.Runtime.Caching;
using MentoringD1D2.Cashing.Diagnostics;
using MentoringD1D2.Cashing.Extensions;
using MentoringD1D2.Cashing.Interfaces;

namespace MentoringD1D2.Cashing.Cashing
{
    public class FibonacciSequenceCache : ICache<int>
    {
        #region Fields
        
        private const string CachePrefix = "Fibonacci_Sequence_Cache";
        
        private readonly ObjectCache _memoryCache = MemoryCache.Default;

        #endregion

        #region Methods

        /// <summary>
        /// Get the object from cash by key.
        /// </summary>
        /// <param name="key">The key of the stored in the cache object.</param>
        /// <returns>The stored in the cache object.</returns>
        public IEnumerable<int> Get(string key)
        {
            if (string.IsNullOrEmpty(key))
            {
                ApplicationLogger.LogMessage(LogMessageType.Error, $"Invalid key: {key}");
                throw new ArgumentException(nameof(key));
            }

            var item = _memoryCache.Get($"{CachePrefix}_{key}") as IEnumerable<int>;
            if (item == null)
            {
                ApplicationLogger.LogMessage(LogMessageType.Warn, $"The object with {CachePrefix}_{key} key doesn't exist.");
            }
            return item;
        }

        /// <summary>
        /// Put into cahce a fibonacci value.
        /// </summary>
        /// <param name="key">The key that will store in the cache and connected with requested object.</param>
        /// <param name="value">The object that should be put into cache.</param>
        public void Set(string key, IEnumerable<int> value)
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

            _memoryCache.Set($"{CachePrefix}_{key}", value, ObjectCache.InfiniteAbsoluteExpiration);
            ApplicationLogger.LogMessage(LogMessageType.Info, $"The sequence: {value.ToCustomString()} was added to cache.");
        }

        #endregion 

    }
}
