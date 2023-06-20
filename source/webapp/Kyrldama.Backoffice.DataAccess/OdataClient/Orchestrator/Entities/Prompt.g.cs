namespace Kyrldama.Backoffice.DataAccess.OdataClient.Orchestrator.Entity
{
    public class Prompt
    {
        public int Id { get; set; }
        public Enum.PromptType IdPromptType { get; set; }
        public string Label { get; set; }
        public string Content { get; set; }
        public DateTimeOffset CreationDate { get; set; }
        public string CreationApplication { get; set; }
        public int CreationUser { get; set; }
        public DateTimeOffset UpdateDate { get; set; }
        public string UpdateApplication { get; set; }
        public int UpdateUser { get; set; }
        public Kyrldama.Backoffice.DataAccess.OdataClient.Orchestrator.Entity.PromptType PromptType { get; set; }
        public List<Kyrldama.Backoffice.DataAccess.OdataClient.Orchestrator.Entity.EntityTemplate> EntityTemplate { get; set; }

    }
}
