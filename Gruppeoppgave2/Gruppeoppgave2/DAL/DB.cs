using Microsoft.EntityFrameworkCore;


namespace Gruppeoppgave2.Models
{

    public class Adminer
    {
        public int Id { get; set; }
        public string Brukernavn { get; set; }
        public byte[] Passord { get; set; }
        public byte[] Salt { get; set; }
    }
    public class DB:DbContext
    {       
        public DB(DbContextOptions<DB> options) : base(options)
        {
            Database.EnsureCreated();
        }
        public DbSet<Strekning> Strekning { get; set; }

        public DbSet<Adminer> Adminer { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLazyLoadingProxies();
        }
    }
}
