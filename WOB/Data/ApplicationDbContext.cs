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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasOne(u => u.Coach)
                .WithMany()
                .HasForeignKey(u => u.CoachId)
                .IsRequired(false);

            modelBuilder.Entity<User>()
                .HasOne(u => u.Staff)
                .WithMany()
                .HasForeignKey(u => u.StaffId)
                .IsRequired(false);
        }

        public DbSet<Coach> coaches { get; set; }
        public DbSet<Player> players { get; set; }
        public DbSet<Staff> staffs { get; set; }
        public DbSet<Status> statuses { get; set; }
        public DbSet<User> users { get; set;  }
        public DbSet<UserCode> userCodes { get; set; }
    }
}
