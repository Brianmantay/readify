using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using Api.Controllers;
using Api.Services;
using Moq;
using System.Web.Http.Results;

namespace Api.Tests.Controllers
{
    [TestClass]
    public class FibonacciControllerTest
    {
        private FibonacciController _subject;
        private Mock<IFibonacciService> _service;

        [TestInitialize]
        public void Initialize()
        {
            _service = new Mock<IFibonacciService>();
            _subject = new FibonacciController(_service.Object);
        }

        [TestMethod]
        public void TestGetReturnsOk()
        {
            int index = 2;
            long expected = 1;

            _service.Setup(s => s.GetNumberInSequenceFromIndex(index))
                .Returns(expected);

            var result = _subject.Get(index);

            Assert.IsInstanceOfType(result, typeof(OkNegotiatedContentResult<long>), "Expected status code 200");
        
            var resultContent = result as OkNegotiatedContentResult<long>;
            Assert.AreEqual(expected, resultContent.Content);
        }

        [TestMethod]
        public void TestGetReturnsBadRequest()
        {
            int index = 93;
           
            _service.Setup(s => s.GetNumberInSequenceFromIndex(index))
                .Throws(new OverflowException());

            var result = _subject.Get(index);

            Assert.IsInstanceOfType(result, typeof(BadRequestResult), "Expected status code 400");
        }
    }
}
