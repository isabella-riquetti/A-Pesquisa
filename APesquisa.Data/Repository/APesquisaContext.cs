using APesquisa.Data.Service.ChangeTrackerService;
using System;
using System.Linq;
using System.Threading;
using System.Web;

namespace APesquisa.Data.Repository
{
    public class APesquisaContext : APesquisaContextLog
    {
        public const string ContextName = "APesquisaContext";
        private readonly IChangeTrackerService _changeTrackerService;

        public APesquisaContext() : base(ContextName)
        {
            _changeTrackerService = new ChangeTrackerService();
        }
    }
}



