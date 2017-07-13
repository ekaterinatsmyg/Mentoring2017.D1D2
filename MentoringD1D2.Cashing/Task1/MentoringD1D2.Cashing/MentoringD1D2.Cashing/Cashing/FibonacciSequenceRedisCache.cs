using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using MentoringD1D2.Cashing.Diagnostics;
using MentoringD1D2.Cashing.Interfaces;
using Newtonsoft.Json;
using StackExchange.Redis;

namespace MentoringD1D2.Cashing.Cashing
{
    public class FibonacciSequenceRedisCache : ICache<int>
    {
        #region Fields

        private const string CachePrefix = "Fibonacci_Sequence_Cache";

        private static readonly Lazy<ConnectionMultiplexer> LazyConnection = new Lazy<ConnectionMultiplexer>(() => ConnectionMultiplexer.Connect("localhost"));
        public static ConnectionMultiplexer Connection => LazyConnection.Value;

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
            
            var cache = Connection.GetDatabase();
            var sequence = cache.StringGet($"{CachePrefix}_{key}");
            if (sequence.IsNull)
            {
                ApplicationLogger.LogMessage(LogMessageType.Warn, $"The object with {CachePrefix}_{key} key doesn't exist in the cache.");
                return null;
            }

            return JsonConvert.DeserializeObject<IEnumerable<int>>(sequence.ToString());
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

            var cache = Connection.GetDatabase();

            if (value == null)
            {
                ApplicationLogger.LogMessage(LogMessageType.Warn, $"The value was not put into the cache | {nameof(value)} is null.");
            }
            else
            {
                cache.StringSet($"{CachePrefix}_{key}", JsonConvert.SerializeObject(value));
            }
        }

        #endregion
    }

}
