using Microsoft.EntityFrameworkCore;
using TestDbCRUD.Models.Domain;

namespace TestDbCRUD.Data
{
    public class MoveItDbContext : DbContext
    {
        public MoveItDbContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Orders> Orders { get; set; }
        public DbSet<Vehicles> Vehicle { get; set; }
        public DbSet<UserAccount>  UserAccount{ get; set; }
        public DbSet<RoleType> RoleType { get; set; }

    }
}
