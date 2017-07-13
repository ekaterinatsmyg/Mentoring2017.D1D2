using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using MentoringD1D2.Cashing.Cashing;
using MentoringD1D2.Cashing.Extensions;
using MentoringD1D2.Cashing.Interfaces;
using MentoringD1D2.Cashing.Resolver;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MentoringD1D2.Cashing.Tests
{
    [TestClass]
    public class FibonacciSequenceTest
    {
        [TestMethod]
        public void MemoryCacheTest()
        {
            var cache = new FibonacciSequenceCache();
            var sequence = FibonacciSequenceGenerator.GenerateSequence(15).ToList();
            cache.Set("key1", sequence);
            var cachedSequence = cache.Get("key1").ToList();
            CollectionAssert.AreEqual(sequence, cachedSequence);
        }

        [TestMethod]
        public void RedisCacheTest()
        {
            var cache = new FibonacciSequenceRedisCache();
            var sequence = FibonacciSequenceGenerator.GenerateSequence(15).ToList();
            cache.Set("key1", sequence);
            var cachedSequence = cache.Get("key1").ToList();
            CollectionAssert.AreEqual(sequence, cachedSequence);
        }


        [TestMethod]
        public void FiboncciGeneratorTest()
        {
            var sequence = FibonacciSequenceGenerator.GenerateSequence(12).ToList();
            var cachedSequence = new List<int> {0, 1, 1, 2, 3, 5, 8, 13, 21, 34, 55, 89};
            CollectionAssert.AreEqual(sequence, cachedSequence);
        }


        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void FiboncciGeneratorInvalidArgumentsTest()
        {
            foreach (var i in FibonacciSequenceGenerator.GenerateSequence(-1))
            {
                Debug.WriteLine(i);
            }
        }
    }
}
