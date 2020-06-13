using GameShelf.API.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace GameShelf.API
{
    public class DataContext : DbContext
    {
        public IConfiguration Configuration { get; }
        
        public DataContext(DbContextOptions<DataContext> options,IConfiguration configuration) 
            : base(options)
        {
            Configuration = configuration;
        }

        // protected override void OnModelCreating(ModelBuilder modelBuilder)
        // {
        //     modelBuilder.UseSerialColumns();
        //     modelBuilder.Entity<User>().ToTable("User");
        //     modelBuilder.Entity<Game>().ToTable("Game");
        // }
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder.UseNpgsql(Configuration.GetConnectionString("(default)"));
            
        public DbSet<User> Users { get; set; }
        public DbSet<Game> Games { get; set; }
    }
}