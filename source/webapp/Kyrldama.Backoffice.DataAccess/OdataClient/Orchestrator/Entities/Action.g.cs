using Kyrldama.Odata;

namespace Kyrldama.Backoffice.DataAccess.OdataClient.Orchestrator.Entity
{
    public class Action : OdataObject
    {
        private int? _Id;
        public int? Id
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
        private Enum.ActionType _IdActionType;
        public Enum.ActionType IdActionType
        { 
            get { return _IdActionType; }
            set
            {
                this.Set(nameof(IdActionType), value);
                _IdActionType = value;
            }
        }
        private DateTimeOffset? _CreationDate;
        public DateTimeOffset? CreationDate
        { 
            get { return _CreationDate; }
            set
            {
                this.Set(nameof(CreationDate), value);
                _CreationDate = value;
            }
        }
        private string _CreationApplication;
        public string CreationApplication
        { 
            get { return _CreationApplication; }
            set
            {
                this.Set(nameof(CreationApplication), value);
                _CreationApplication = value;
            }
        }
        private int? _CreationUser;
        public int? CreationUser
        { 
            get { return _CreationUser; }
            set
            {
                this.Set(nameof(CreationUser), value);
                _CreationUser = value;
            }
        }
        private DateTimeOffset? _UpdateDate;
        public DateTimeOffset? UpdateDate
        { 
            get { return _UpdateDate; }
            set
            {
                this.Set(nameof(UpdateDate), value);
                _UpdateDate = value;
            }
        }
        private string _UpdateApplication;
        public string UpdateApplication
        { 
            get { return _UpdateApplication; }
            set
            {
                this.Set(nameof(UpdateApplication), value);
                _UpdateApplication = value;
            }
        }
        private int? _UpdateUser;
        public int? UpdateUser
        { 
            get { return _UpdateUser; }
            set
            {
                this.Set(nameof(UpdateUser), value);
                _UpdateUser = value;
            }
        }
        public Kyrldama.Backoffice.DataAccess.OdataClient.Orchestrator.Entity.ActionType ActionType { get; set; }

    }
}
