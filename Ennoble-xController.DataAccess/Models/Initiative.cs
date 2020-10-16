using System;
using System.Collections.Generic;
using System.Text;

namespace Ennoble_xController.DataAccess.Models
{
    public class Initiative
    {
        public long InitiativeId { get; set; }
        public string Name { get; set; }
        public DateTime CreatedDateTime { get; set; }
        public long CreatedBy { get; set; }
        public long LeaderId { get; set; }
    }
}
