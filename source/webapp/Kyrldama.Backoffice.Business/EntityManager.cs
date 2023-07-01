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
            return await this.orchestratorClient.GetAsync<List<EntityTemplate>>($"{nameof(EntityTemplate)}?$expand=Prompt&$orderby=Id desc");
        }

        public async Task<(List<Prompt>, IResult)> GetPrompts()
        {
            return await this.orchestratorClient.GetAsync<List<Prompt>>($"{nameof(Prompt)}");
        }

        public async Task<(EntityTemplate, IResult)> PostTemplate(EntityTemplate entityTemplate)
        {
            return await this.orchestratorClient.PostAsync<EntityTemplate>($"{nameof(EntityTemplate)}", entityTemplate);
        }

        public async Task<(List<EntityInstance>, IResult)> GetEntities()
        {
            return await this.orchestratorClient.GetAsync<List<EntityInstance>>($"{nameof(EntityInstance)}");
        }

        public async Task<(EntityInstance, IResult)> CreateEntityFromTemplate(EntityTemplate template)
        {
            return await this.orchestratorClient.PostAsync<EntityInstance>($"{nameof(EntityInstance)}/Action.New()", template);
        }
    }
}
