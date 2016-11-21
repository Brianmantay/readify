using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using Api.Services;

namespace Api.Tests.Services
{
    [TestClass]
    public class FibonacciServiceTest
    {
        private FibonacciService _subject;

        [TestInitialize]
        public void Initialize()
        {
            _subject = new FibonacciService();
        }

        [TestMethod]
        public void TestGetNumberInSequenceFromIndexReturnsAFibonacciNumber()
        {
            var expected = new Dictionary<int, Int64>()
            {
                {0, 0},
                {1, 1},
                {2, 1},
                {3, 2},
                {4, 3},
                {5, 5},
                {6, 8}
            };
          
            expected.ToList().ForEach(pair =>
            {
                var expectedFib = pair.Value;
                var index = pair.Key;
                Assert.AreEqual(expectedFib, _subject.GetNumberInSequenceFromIndex(index), "Unexpected fibonacci number");
            });
        }

        [TestMethod]
        public void TestGetNumberInSequenceFromNegativeIndexReturnsAFibonacciNumber()
        {
            var expected = new Dictionary<int, long>()
            {
                {-4, -3},
                {-3, 2},
                {-2, -1},
                {-1, 1},
                {0, 0}
            };

            expected.ToList().ForEach(pair =>
            {
                var expectedFib = pair.Value;
                var index = pair.Key;
                Assert.AreEqual(expectedFib, _subject.GetNumberInSequenceFromIndex(index), "Unexpected fibonacci number");
            });
        }

        [TestMethod]
        [ExpectedException(typeof(OverflowException))]
        public void TestGetNumberInSequenceThrowsOverflowExceptionForPositiveNumbers()
        {
            _subject.GetNumberInSequenceFromIndex(93);
        }

        [TestMethod]
        [ExpectedException(typeof(OverflowException))]
        public void TestGetNumberInSequenceThrowsOverflowExceptionForNegativeNumbers()
        {
            _subject.GetNumberInSequenceFromIndex(-93);
        }
    }
}
