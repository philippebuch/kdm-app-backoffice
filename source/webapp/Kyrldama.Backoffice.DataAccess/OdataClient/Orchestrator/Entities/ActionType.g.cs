namespace Kyrldama.Backoffice.DataAccess.OdataClient.Orchestrator.Entity
{
    public class ActionType
    {
        public Enum.ActionType Id { get; set; }
        public string Label { get; set; }
        public List<Kyrldama.Backoffice.DataAccess.OdataClient.Orchestrator.Entity.Action> Action { get; set; }

    }
}
