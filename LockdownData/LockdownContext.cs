using LockdownBusinessLogic.Models;
using LockdownData.Models;
using Microsoft.EntityFrameworkCore;

namespace LockdownData
{
    public class LockdownContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<GeneratedPassword> Passwords { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=Lockdown.db");
        }
    }
}
