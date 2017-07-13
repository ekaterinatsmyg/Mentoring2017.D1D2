using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MentoringD1D2.Cashing.Diagnostics;
using MentoringD1D2.Cashing.Interfaces;

namespace MentoringD1D2.Cashing
{
    public class FibonacciSequenceManager
    {
        /// <summary>
        /// The instance of the <typeparam name="FibonacciSequenceMemoryCache"></typeparam>
        /// </summary>
        private readonly ICache<int> _sequenceCache;

        public FibonacciSequenceManager(ICache<int> sequenceCache)
        {
            _sequenceCache = sequenceCache;
        }

        /// <summary>
        /// Get the fibonacii sequence that consits of <param name="sequenceLenght"></param>.
        /// </summary>
        /// <param name="sequenceLenght">The number of elements in a sequence.</param>
        /// <returns>The fibonacci sequence.</returns>
        public IEnumerable<int> GetFibonacciSequence(int sequenceLenght)
        {
            ApplicationLogger.LogMessage(LogMessageType.Info, $"Starting genration of the fibonacii sequence, lenght: {sequenceLenght}");

            var date = DateTime.Now;
            var key = $"{date.Day}-{date.Month}-{date.Year}";

            var fibonacciSequence = _sequenceCache.Get(key);

            if (fibonacciSequence == null || fibonacciSequence.Count() != sequenceLenght)
            {
                fibonacciSequence = FibonacciSequenceGenerator.GenerateSequence(sequenceLenght).ToList();
                _sequenceCache.Set(key, fibonacciSequence);
            }

            return fibonacciSequence;
        } 
    }
}
