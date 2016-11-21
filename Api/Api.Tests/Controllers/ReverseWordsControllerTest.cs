using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Api.Controllers;
using Api.Services;
using Moq;
using System.Web.Http.Results;

namespace Api.Tests.Controllers
{
    [TestClass]
    public class ReverseWordsControllerTest
    {
        private ReverseWordsController _subject;
        private Mock<IReverseWordsService> _service;

        [TestInitialize]
        public void Initialize()
        {
            _service = new Mock<IReverseWordsService>();
            _subject = new ReverseWordsController(_service.Object);
        }

        [TestMethod]
        public void TestGetReturnsOkWithReversedString()
        {
            string input = "blah";
            string output = "halb";
            _service.Setup(s => s.ReverseWordsInSentence(input))
                .Returns(output);

            var result = _subject.Get(input);

            Assert.IsInstanceOfType(result, typeof(OkNegotiatedContentResult<string>), "Expected status code 200");
            var resultContent = result as OkNegotiatedContentResult<string>;
            Assert.AreEqual(output, resultContent.Content);
        }
    }
}
