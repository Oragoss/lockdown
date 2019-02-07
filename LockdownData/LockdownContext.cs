using LockdownBusinessLogic.Models;
using Microsoft.EntityFrameworkCore;

namespace LockdownData
{
    public class LockdownContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=Lockdown.db");
        }
    }
}
