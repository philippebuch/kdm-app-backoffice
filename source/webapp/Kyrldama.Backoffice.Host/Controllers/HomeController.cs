using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Kyrldama.Backoffice.Host.Controllers
{
    public class HomeController : Controller
    {
        // GET: HomeController
        public ActionResult Index()
        {
            return Ok("42");
        }
    }
}
