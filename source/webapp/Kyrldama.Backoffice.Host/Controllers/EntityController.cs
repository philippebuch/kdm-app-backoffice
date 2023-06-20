using Kyrldama.Backoffice.Business.Interface;
using Kyrldama.Backoffice.Infrastructure;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Kyrldama.Backoffice.Host.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EntityController : ODataControllerBase
    {
        [HttpGet("Template")]
        public async Task<IActionResult> Template([FromServices] IEntityManager entityManager)
        {
            var (templates, result) = await entityManager.GetTemplates();
            return this.Result(templates, result, (s) => this.StatusCode(StatusCodes.Status200OK, s));
        }
    }
}
