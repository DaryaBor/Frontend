using Microsoft.EntityFrameworkCore;
using TodoAPI.Models;
using TodoAPI.Infrastructure.Data.FilmModel.EntityConfigurations;
using TodoAPI.Infrastructure.Data.SeanceModel.EntityConfigurations;
using TodoAPI.Infrastructure.Data.TicketsModel.EntityConfigurations;

namespace TodoAPI.Infrastructure
{
    public class MovieDbContext : DbContext
    {
        
        public DbSet<Film> Film { get; set; }
        public DbSet<Seance> Seance { get; set; }
        public DbSet<Tickets> Tickets { get; set; }

        public MovieDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new FilmMap());
            modelBuilder.ApplyConfiguration(new SeanceMap());
            modelBuilder.ApplyConfiguration(new TicketsMap());
        }
    }
    
}
