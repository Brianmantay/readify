using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Api.Services;

namespace Api.Tests.Services
{
    [TestClass]
    public class ReverseWordsServiceTest
    {
        private IReverseWordsService _subject;

        [TestInitialize]
        public void Initialize()
        {
            _subject = new ReverseWordsService();
        }

        [TestMethod]
        public void TestReverseWordsInSentence()
        {
            var result = _subject.ReverseWordsInSentence("this is a test sentence");
            Assert.AreEqual("siht si a tset ecnetnes", result);
        }

        [TestMethod]
        public void TestReverseWordsInSentenceMaintainWhitespace()
        {
            var result = _subject.ReverseWordsInSentence("  this is  a test sentence ");
            Assert.AreEqual("  siht si  a tset ecnetnes ", result);
        }

        [TestMethod]
        public void TestReverseWordsInSentenceEmptyDoesntBreak()
        {
            var result = _subject.ReverseWordsInSentence(" ");
            Assert.AreEqual(" ", result);
        }
    }
}
