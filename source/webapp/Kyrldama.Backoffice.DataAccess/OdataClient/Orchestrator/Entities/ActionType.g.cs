using Kyrldama.Odata;

namespace Kyrldama.Backoffice.DataAccess.OdataClient.Orchestrator.Entity
{
    public class ActionType : OdataObject
    {
        private Enum.ActionType _Id;
        public Enum.ActionType Id
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
        public List<Kyrldama.Backoffice.DataAccess.OdataClient.Orchestrator.Entity.Action> Action { get; set; }

    }
}
