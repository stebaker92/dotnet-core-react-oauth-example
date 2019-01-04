using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using System.IdentityModel.Tokens.Jwt;
using backend_test.Helpers;
using backend_test.Models;
using System;

namespace backend_test.Controllers
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [Route("api/v1/[controller]")]
    public class DataController : Controller
    {
        [HttpGet("secure-data")]
        public IActionResult Get()
        {
            // TODO - abstract this out
            var token = Request.Headers["Authorization"]
                .First()
                .ToString()
                .Replace("bearer ", "", StringComparison.InvariantCultureIgnoreCase);

            var jwtToken = new JwtSecurityToken(token);

            var subject = jwtToken.Subject;
            var s = jwtToken.Payload.Sub;
            var level = jwtToken.Payload["and_level"];

            var subDecoded = Security.Decrypt(AppSettings.appSettings.JwtEmailEncryption, s);

            return Ok($"Your email is: {subDecoded}, your level is: {level}");

        }
    }
}
