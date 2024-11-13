using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Http.Controllers;

namespace App.WebApi.Models
{
    public class JwtAuthenticationAttribute : AuthorizeAttribute
    {
        private readonly JwtTokenService _jwtTokenService = new JwtTokenService();
        protected override bool IsAuthorized(HttpActionContext actionContext)
        {
            // Extract token from the Authorization header
            var authHeader = actionContext.Request.Headers.Authorization;

            if (authHeader != null && authHeader.Scheme == "Bearer")
            {
                var token = authHeader.Parameter;

                // Verify token (you need to use your _jwtTokenService or JWT library for this)
                var isValid = _jwtTokenService.ValidateToken(token); // Implement this method

                if (isValid)
                {
                    return true;
                }
            }

            return false;
        }
    }
}