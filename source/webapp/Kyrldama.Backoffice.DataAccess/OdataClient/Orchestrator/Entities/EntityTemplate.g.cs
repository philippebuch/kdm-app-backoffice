namespace Kyrldama.Backoffice.DataAccess.OdataClient.Orchestrator.Entity
{
    public class EntityTemplate
    {
        public int Id { get; set; }
        public string Label { get; set; }
        public int IdPrompt { get; set; }
        public DateTimeOffset CreationDate { get; set; }
        public string CreationApplication { get; set; }
        public int CreationUser { get; set; }
        public DateTimeOffset UpdateDate { get; set; }
        public string UpdateApplication { get; set; }
        public int UpdateUser { get; set; }
        public Kyrldama.Backoffice.DataAccess.OdataClient.Orchestrator.Entity.Prompt Prompt { get; set; }
        public List<Kyrldama.Backoffice.DataAccess.OdataClient.Orchestrator.Entity.EntityInstance> EntityInstance { get; set; }

    }
}
