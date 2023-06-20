using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Kyrldama.Backoffice.Host.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HomeController : Controller
    {
        // GET: HomeController
        public ActionResult Index()
        {
            return Ok("42");
        }
    }
}
