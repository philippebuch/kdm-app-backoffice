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
        Task<(List<EntityTemplate>, IResult)> GetTemplates();
        Task<(EntityTemplate, IResult)> PostTemplate(EntityTemplate entityTemplate);
    }
}
