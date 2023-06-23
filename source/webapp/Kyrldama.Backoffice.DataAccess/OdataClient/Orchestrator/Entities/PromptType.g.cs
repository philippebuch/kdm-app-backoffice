using Kyrldama.Odata;

namespace Kyrldama.Backoffice.DataAccess.OdataClient.Orchestrator.Entity
{
    public class PromptType : OdataObject
    {
        private Enum.PromptType _Id;
        public Enum.PromptType Id
        { 
            get { return _Id; }
            set
            {
                this.Set(nameof(Id), value);
                _Id = value;
            }
        }
        private string _Label;
        public string Label
        { 
            get { return _Label; }
            set
            {
                this.Set(nameof(Label), value);
                _Label = value;
            }
        }
        public List<Kyrldama.Backoffice.DataAccess.OdataClient.Orchestrator.Entity.Session> Session { get; set; }
        public List<Kyrldama.Backoffice.DataAccess.OdataClient.Orchestrator.Entity.Prompt> Prompt { get; set; }

    }
}
