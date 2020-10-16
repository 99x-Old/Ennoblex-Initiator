using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Ennoble_xController.DataAccess.Models
{
  public  class Role
    {
        [Key]
        public long RoleId { get; set; }
        public string Type { get; set; }
    }
}
