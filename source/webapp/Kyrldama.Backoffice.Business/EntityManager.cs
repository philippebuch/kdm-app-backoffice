using Kyrldama.Backoffice.Business.Interface;
using Kyrldama.Backoffice.DataAccess.OdataClient.Orchestrator;
using Kyrldama.Backoffice.DataAccess.OdataClient.Orchestrator.Entity;
using Kyrldama.Backoffice.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kyrldama.Backoffice.Business
{
    public class EntityManager : IEntityManager
    {
        private readonly OrchestratorClient orchestratorClient;

        public EntityManager(OrchestratorClient orchestratorClient)
        {
            this.orchestratorClient = orchestratorClient;
        }

        public async Task<(List<EntityTemplate>, IResult)> GetTemplates()
        {
            return await this.orchestratorClient.GetAsync<List<EntityTemplate>>($"{nameof(EntityTemplate)}");
        }
    }
}
