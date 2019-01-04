using Microsoft.AspNetCore.Mvc;

namespace backend_test.Controllers
{
    [Route("")]
    [Route("api")]
    public class AliveController : Controller
    {
        public string Get()
        {
            return "API is alive!";
        }
    }
}
