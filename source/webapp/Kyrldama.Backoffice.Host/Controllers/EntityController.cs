using Kyrldama.Backoffice.Business.Interface;
using Kyrldama.Backoffice.DataAccess.OdataClient.Orchestrator.Entity;
using Kyrldama.Backoffice.Infrastructure;
using Microsoft.AspNet.OData;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Kyrldama.Backoffice.Host.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EntityController : ODataControllerBase
    {
        [HttpGet("Template")]
        public async Task<IActionResult> GetTemplate([FromServices] IEntityManager entityManager)
        {
            var (templates, result) = await entityManager.GetTemplates();
            return this.Result(templates, result, (s) => this.StatusCode(StatusCodes.Status200OK, s));
        }

        [HttpPost("Template")]
        public async Task<IActionResult> PostTemplate([FromServices] IEntityManager entityManager, [FromBody] EntityTemplate entityTemplate)
        {
            var (entityTemplates, result) = await entityManager.PostTemplate(entityTemplate);
            return this.Result(entityTemplates, result, (s) => this.StatusCode(StatusCodes.Status200OK, s));
        }
    }
}
