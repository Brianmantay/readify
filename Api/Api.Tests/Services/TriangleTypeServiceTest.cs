using System;
using System.Collections.Generic;
using Api.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Api.Tests.Services
{
    [TestClass]
    public class TriangleTypeServiceTest
    {
        private ITriangleTypeService _subject;

        [TestInitialize]
        public void Initialize()
        {
            _subject = new TriangleTypeService();
        }

        [TestMethod]
        public void TestCheckTriangleTypeReturnsEquilateral()
        {
            // All sides the same
            AssertType(TriangleTypeService.TrianlgeType.Equilateral, 1, 1, 1);
        }

        [TestMethod]
        public void TestCheckTriangleTypeReturnsIsoscieles()
        {
            // 2 sides the same
            AssertType(TriangleTypeService.TrianlgeType.Isoscieles, 2, 1, 2);
            AssertType(TriangleTypeService.TrianlgeType.Isoscieles, 2, 2, 1);
            AssertType(TriangleTypeService.TrianlgeType.Isoscieles, 1, 2, 2);
        }

        [TestMethod]
        public void TestCheckTriangleTypeReturnsScalene()
        {
            // All sides the different
            AssertType(TriangleTypeService.TrianlgeType.Scalene, 2, 3, 4);
        }

        [TestMethod]
        public void TestCheckTriangleTypeReturnsErrorArgumentsMakeAnInvalidTriangle()
        {
            var testData = new List<List<int>>
            {
                new List<int> {5, -1, 0},
                new List<int> {1, 2, 1},
                new List<int> {10, 2, 3}
            };

            testData.ForEach(t =>
            {
                try
                {
                    _subject.CheckTriangleType(t[0], t[1], t[2]);
                    Assert.IsTrue(false, "Not a valid triangle, should have failed validation");
                }
                catch (ArgumentException)
                {
                    Assert.IsTrue(true);
                }
            });
        }

        private void AssertType(TriangleTypeService.TrianlgeType @type, int a, int b, int c)
        {
            Assert.AreEqual(@type, _subject.CheckTriangleType(a, b, c));
        }
    }
}
