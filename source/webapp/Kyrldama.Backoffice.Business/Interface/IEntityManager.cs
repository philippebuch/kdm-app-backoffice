using Kyrldama.Backoffice.DataAccess.OdataClient.Orchestrator.Entity;
using Kyrldama.Backoffice.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kyrldama.Backoffice.Business.Interface
{
    public interface IEntityManager
    {
        Task<(EntityInstance, IResult)> CreateEntityFromTemplate(EntityTemplate template);
        Task<(List<EntityInstance>, IResult)> GetEntities();
        Task<(List<Prompt>, IResult)> GetPrompts();
        Task<(List<EntityTemplate>, IResult)> GetTemplates();
        Task<(EntityTemplate, IResult)> PostTemplate(EntityTemplate entityTemplate);
    }
}
