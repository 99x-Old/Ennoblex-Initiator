using System;
using System.Collections.Generic;
using System.Text;

namespace Ennoble_xController.DataAccess.Models
{
  public  class UserAction
    {
        public long UserActionId { get; set; }
        public long ActionId { get; set; }
        public long UserId { get; set; }
        public DateTime DeadlineDateTime { get; set; }
        public DateTime StartedDateTime { get; set; }
        

    }
}
