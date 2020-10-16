using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Ennoble_xController.DataAccess.Models
{
  public  class User
    {
        public User (){
            Initiative = new HashSet<Initiative>();
            UserAction = new HashSet<UserAction>();

        }

        [Key] 
        public long UserId { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
        public long RoleId { get; set; }
        public string TypeId { get; set; }

        public Role Role { get; set; }
        public UsersType Usertype { get; set; }
        public ICollection<Initiative> Initiative { get; set; }
        public ICollection<UserAction> UserAction { get; set; }

    }
}
