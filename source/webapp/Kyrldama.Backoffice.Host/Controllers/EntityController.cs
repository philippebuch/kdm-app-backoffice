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

        [HttpGet("Prompt")]
        public async Task<IActionResult> GetPrompt([FromServices] IEntityManager entityManager)
        {
            var (prompts, result) = await entityManager.GetPrompts();
            return this.Result(prompts, result, (s) => this.StatusCode(StatusCodes.Status200OK, s));
        }

        [HttpGet("Entity")]
        public async Task<IActionResult> GetEntity([FromServices] IEntityManager entityManager)
        {
            var (entities, result) = await entityManager.GetEntities();
            return this.Result(entities, result, (s) => this.StatusCode(StatusCodes.Status200OK, s));
        }

        [HttpPost("Entity")]
        public async Task<IActionResult> PostEntity(EntityTemplate template, [FromServices] IEntityManager entityManager)
        {
            var (entity, result) = await entityManager.CreateEntityFromTemplate(template);
            return this.Result(entity, result, (s) => this.StatusCode(StatusCodes.Status200OK, s));
        }

        [HttpPost("Template")]
        public async Task<IActionResult> PostTemplate([FromServices] IEntityManager entityManager, [FromBody] EntityTemplate entityTemplate)
        {
            var (entityTemplates, result) = await entityManager.PostTemplate(entityTemplate);
            return this.Result(entityTemplates, result, (s) => this.StatusCode(StatusCodes.Status200OK, s));
        }
    }
}
