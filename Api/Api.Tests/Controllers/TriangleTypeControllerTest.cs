using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using Api.Controllers;
using Api.Services;
using Moq;
using System.Web.Http.Results;

namespace Api.Tests.Controllers
{
    [TestClass]
    public class TriangleTypeControllerTest
    {
        private TriangleTypeController _subject;
        private Mock<ITriangleTypeService> _service;

        [TestInitialize]
        public void Initialize()
        {
            _service = new Mock<ITriangleTypeService>();
            _subject = new TriangleTypeController(_service.Object);
        }

        [TestMethod]
        public void TestGetReturnsOkWithEquilateralAsString()
        {
            int a = 1, b = 1, c = 1;
            _service.Setup(s => s.CheckTriangleType(a, b, c))
                .Returns(TriangleTypeService.TrianlgeType.Equilateral);

            var result = _subject.Get(a, b, c);

            Assert.IsInstanceOfType(result, typeof(OkNegotiatedContentResult<string>), "Expected status code 200");
            var resultContent = result as OkNegotiatedContentResult<string>;
            Assert.AreEqual("Equilateral", resultContent.Content);
        }

        [TestMethod]
        public void TestGetReturnsError()
        {
            int a = -1, b = 1, c = 1;
            _service.Setup(s => s.CheckTriangleType(a, b, c))
                .Throws(new ArgumentException());

            var result = _subject.Get(a, b, c);

            Assert.IsInstanceOfType(result, typeof(OkNegotiatedContentResult<string>), "Expected status code 200");
            var resultContent = result as OkNegotiatedContentResult<string>;
            Assert.AreEqual("Error", resultContent.Content);
        }
    }
}
