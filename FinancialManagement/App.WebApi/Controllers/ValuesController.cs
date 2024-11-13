using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace App.WebApi.Controllers
{
    public class ValuesController : ApiController
    {
        private readonly JwtTokenService _jwtTokenService;

        public ValuesController()
        {
            _jwtTokenService = new JwtTokenService();
        }

        // GET api/values
        public IHttpActionResult Get()
        {
            var authCookie = HttpContext.Current.Request.Cookies["AuthToken"];
            if (authCookie != null)
            {
                var token = authCookie.Value;
                bool isValid = _jwtTokenService.ValidateToken(token);

                if (isValid)
                {
                    return Ok(new { Message = "This is secured data." });
                }
            }

            return Unauthorized();
        }

        // GET api/values/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}
