using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cashing.Task2.Diagnostics;
using Newtonsoft.Json;
using StackExchange.Redis;

namespace CachingSolutionsSamples.Cashing
{
    public class RedisCacheService<T> : ICacheService<T>
    {
        #region Fields
        
        private static readonly Lazy<ConnectionMultiplexer> LazyConnection = new Lazy<ConnectionMultiplexer>(() => ConnectionMultiplexer.Connect("localhost"));
        public static ConnectionMultiplexer Connection => LazyConnection.Value;

        #endregion

        #region Methods

        /// <summary>
        /// Get an object from cash by key.
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

            var cache = Connection.GetDatabase();
            var sequence = cache.StringGet(key);
            if (sequence.IsNull)
            {
                ApplicationLogger.LogMessage(LogMessageType.Warn, $"The object with {key} key doesn't exist in the cache.");
                return null;
            }

            return JsonConvert.DeserializeObject<IEnumerable<T>>(sequence.ToString());
        }

        /// <summary>
        /// Put into cahce a value.
        /// </summary>
        /// <param name="key">The key that will store in the cache and connected with requested object.</param>
        /// <param name="value">The object that should be put into cache.</param>
        public void Set(string key, IEnumerable<T> value)
        {
            if (string.IsNullOrEmpty(key))
            {
                ApplicationLogger.LogMessage(LogMessageType.Error, $"Invalid key: {key}");
                throw new ArgumentException(nameof(key));
            }

            var cache = Connection.GetDatabase();

            if (value == null)
            {
                ApplicationLogger.LogMessage(LogMessageType.Warn, $"The value was not put into the cache by key {key} | {nameof(value)} is null.");
            }
            else
            {
                cache.StringSet(key, JsonConvert.SerializeObject(value));
            }
        }

        #endregion
    }
}
