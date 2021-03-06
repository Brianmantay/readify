﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Api.Controllers
{
    public class TokenController : ApiController
    {
        public IHttpActionResult Get()
        {
            // MySecretToken replaced by token stored in Azure application settings
            var token = ConfigurationManager.AppSettings["MySecretToken"];
            return  Ok(token);
        }
    }
}
