using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Runtime.Caching;
using CachingSolutionsSamples.Cashing;
using Cashing.Task2.Diagnostics;
using NorthwindLibrary;

namespace CachingSolutionsSamples.Managers
{
    public class EntityManager<T> where T : IReadable<T>, new()
    {

        private readonly IMemoryCacheService<T> _cacheService;

        private SqlChangeMonitor _monitor;

        private SqlDependency _dependency;

        private readonly string _connectionString;

        private readonly string _commandText;

        private bool _hasDataChanged;

        private readonly string _key;

        public EntityManager(IMemoryCacheService<T> cacheService, string connectionString, string commandText)
        {
            _cacheService = cacheService;
            _commandText = commandText;
            _connectionString = connectionString;
            _key = $"{typeof(T).Name}_Cache_{DateTime.UtcNow.Day}";
        }

        /// <summary>
        /// Get entities from cache, if cache is empty get from database.
        /// </summary>
        /// <returns>The requested entities.</returns>
        public IEnumerable<T> GetAll()
        {
            var entities = _cacheService.Get(_key);

            if (entities == null)
            {
                CacheItemPolicy policy;
                entities = LoadEntities(out policy);
                _cacheService.Set(_key, entities, policy);
            }

            return entities;
        }

        /// <summary>
        /// Get entities from database and initialize custom cache policy for monitoring cache.
        /// </summary>
        /// <param name="policy">The cache policy.</param>
        /// <returns>The requested entities.</returns>
        private IEnumerable<T> LoadEntities(out CacheItemPolicy policy)
        {
            ApplicationLogger.LogMessage(LogMessageType.Info, $"Connection string = {_connectionString}. Command = {_commandText}. Getting entities...");
            
            policy = new CacheItemPolicy();
            IList<T> entities;

            SqlDependency.Start(_connectionString);

            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (var sqlCommand = new SqlCommand(_commandText, connection))
                {
                    _dependency = new SqlDependency(sqlCommand);
                    _dependency.OnChange += DependencyOnOnChange;

                    using (IDataReader reader = sqlCommand.ExecuteReader())
                    {
                        entities = new List<T>();
                        while (reader.Read())
                        {
                            T entity = new T();
                            entity.ReadSingleRow(reader, entity);
                            entities.Add(entity);
                        }
                    }
                }
            }

            _monitor = new SqlChangeMonitor(_dependency);
            policy.ChangeMonitors.Add(_monitor);
            policy.UpdateCallback = UpdateCallback;

            _hasDataChanged = false;

            return entities;
        }


        /// <summary>
        /// Calls when data in the cache was updated.
        /// </summary>
        /// <param name="arguments">The entity that responsible for displaying updated cache entry.</param>
        private void UpdateCallback(CacheEntryUpdateArguments arguments)
        {
            if (_monitor != null)
                _monitor.Dispose();

            _dependency.OnChange -= DependencyOnOnChange;

            if (_hasDataChanged)
            {
                CacheItemPolicy policy;
                
                arguments.UpdatedCacheItem = new CacheItem(arguments.Key, LoadEntities(out policy));
                arguments.UpdatedCacheItemPolicy = policy;
                _hasDataChanged = false;

                ApplicationLogger.LogMessage(LogMessageType.Info, $"Data related to the {arguments.Key} ithe cache was updated and reloaded.");
            }
        }

        /// <summary>
        /// Calls when the connected with the dependency command execute.
        /// </summary>
        /// <param name="sender">The sender of the event.</param>
        /// <param name="sqlNotificationEventArgs">The arguments of the event.</param>
        private void DependencyOnOnChange(object sender, SqlNotificationEventArgs sqlNotificationEventArgs)
        {
            _hasDataChanged = true;
            ApplicationLogger.LogMessage(LogMessageType.Info, "Data in the cache was changed.");
        }
        

    }
}
