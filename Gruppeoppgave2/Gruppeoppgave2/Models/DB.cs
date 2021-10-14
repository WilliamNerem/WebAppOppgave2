using Microsoft.EntityFrameworkCore;


namespace EF_2.Models
{
    public class DB : DbContext
    {       
        public DB(DbContextOptions<DB> options) : base(options)
        {
            Database.EnsureCreated();
        }
        public virtual DbSet<Strekning> Strekning { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLazyLoadingProxies();
        }
    }
}
