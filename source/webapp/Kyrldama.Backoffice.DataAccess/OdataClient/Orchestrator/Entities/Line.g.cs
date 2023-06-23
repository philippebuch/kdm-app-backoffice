using Kyrldama.Odata;

namespace Kyrldama.Backoffice.DataAccess.OdataClient.Orchestrator.Entity
{
    public class Line : OdataObject
    {
        private int _Id;
        public int Id
        { 
            get { return _Id; }
            set
            {
                this.Set(nameof(Id), value);
                _Id = value;
            }
        }
        private int _IdSession;
        public int IdSession
        { 
            get { return _IdSession; }
            set
            {
                this.Set(nameof(IdSession), value);
                _IdSession = value;
            }
        }
        private string _Content;
        public string Content
        { 
            get { return _Content; }
            set
            {
                this.Set(nameof(Content), value);
                _Content = value;
            }
        }
        private string _Role;
        public string Role
        { 
            get { return _Role; }
            set
            {
                this.Set(nameof(Role), value);
                _Role = value;
            }
        }
        private int _Order;
        public int Order
        { 
            get { return _Order; }
            set
            {
                this.Set(nameof(Order), value);
                _Order = value;
            }
        }
        private DateTimeOffset _CreationDate;
        public DateTimeOffset CreationDate
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
        private int _CreationUser;
        public int CreationUser
        { 
            get { return _CreationUser; }
            set
            {
                this.Set(nameof(CreationUser), value);
                _CreationUser = value;
            }
        }
        private DateTimeOffset _UpdateDate;
        public DateTimeOffset UpdateDate
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
        private int _UpdateUser;
        public int UpdateUser
        { 
            get { return _UpdateUser; }
            set
            {
                this.Set(nameof(UpdateUser), value);
                _UpdateUser = value;
            }
        }
        public Kyrldama.Backoffice.DataAccess.OdataClient.Orchestrator.Entity.Session Session { get; set; }

    }
}
