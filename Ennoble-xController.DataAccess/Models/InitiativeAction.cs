using System;
using System.Collections.Generic;
using System.Text;

namespace Ennoble_xController.DataAccess.Models
{
    public class InitiativeAction
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public long InitiativeId {get;set;}
    }
}
