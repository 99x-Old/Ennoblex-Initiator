using Ennoble_xController.DataAccess.Models;
using Microsoft.EntityFrameworkCore;


namespace Ennoble_xController.DataAccess
{
   public class EnnoblexDbContext :DbContext
    {

        public EnnoblexDbContext(DbContextOptions<EnnoblexDbContext> options)
       : base(options)
        {
        }
        public virtual DbSet<Initiative> Initiative { get; set; }
        public virtual DbSet<InitiativeAction> InitiativeAction { get; set; }
        public virtual DbSet<Role> Role { get; set; }
        public virtual DbSet<User> User { get; set; }
        public virtual DbSet<UserAction> UserAction { get; set; }
        public virtual DbSet<UsersType> UsersType { get; set; }
    }
}
