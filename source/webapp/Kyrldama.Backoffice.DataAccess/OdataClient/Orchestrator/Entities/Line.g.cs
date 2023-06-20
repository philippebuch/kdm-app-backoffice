namespace Kyrldama.Backoffice.DataAccess.OdataClient.Orchestrator.Entity
{
    public class Line
    {
        public int Id { get; set; }
        public int IdSession { get; set; }
        public string Content { get; set; }
        public string Role { get; set; }
        public int Order { get; set; }
        public DateTimeOffset CreationDate { get; set; }
        public string CreationApplication { get; set; }
        public int CreationUser { get; set; }
        public DateTimeOffset UpdateDate { get; set; }
        public string UpdateApplication { get; set; }
        public int UpdateUser { get; set; }
        public Kyrldama.Backoffice.DataAccess.OdataClient.Orchestrator.Entity.Session Session { get; set; }

    }
}
