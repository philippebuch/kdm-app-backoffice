namespace Kyrldama.Backoffice.DataAccess.OdataClient.Orchestrator.Entity
{
    public class Sequence
    {
        public int Id { get; set; }
        public string Label { get; set; }
        public DateTimeOffset CreationDate { get; set; }
        public string CreationApplication { get; set; }
        public int CreationUser { get; set; }
        public DateTimeOffset UpdateDate { get; set; }
        public string UpdateApplication { get; set; }
        public int UpdateUser { get; set; }

    }
}
