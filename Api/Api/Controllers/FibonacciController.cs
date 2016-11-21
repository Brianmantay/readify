using Api.Services;
using System;
using System.Collections.Generic;
using System.Web.Http;

namespace Api.Controllers
{
    public class FibonacciController : ApiController
    {
        private readonly IFibonacciService _fibonacciService;

        public FibonacciController(IFibonacciService fibonacciService)
        {
            _fibonacciService = fibonacciService;
        }

        public IHttpActionResult Get(int n)
        {
            try
            {
                long result = _fibonacciService.GetNumberInSequenceFromIndex(n);
                return Ok(result);
            }
            catch (OverflowException ex)
            {
                return BadRequest();
            }
        }
    }
}
