using Microsoft.EntityFrameworkCore;
using WOB.Models;

namespace WOB.Data
{
    public class ApplicationDbContext : DbContext
    {
        // コンストラクタ
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<Coach> coaches { get; set; }
        public DbSet<Player> players { get; set; }
        public DbSet<Staff> staffs { get; set; }
        public DbSet<Status> statuses { get; set; }
        public DbSet<User> users { get; set;  }
        public DbSet<UserCode> userCodes { get; set; }
    }
}
