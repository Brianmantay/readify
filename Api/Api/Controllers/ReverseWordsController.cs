using Api.Services;
using System;
using System.Collections.Generic;
using System.Web.Http;

namespace Api.Controllers
{
    public class ReverseWordsController : ApiController
    {
        private readonly IReverseWordsService _wordsService;

        public ReverseWordsController(IReverseWordsService wordsService)
        {
            _wordsService = wordsService;
        }

        public IHttpActionResult Get(string sentence)
        {
            var result = _wordsService.ReverseWordsInSentence(sentence);
            return Ok(result);
        }
    }
}
