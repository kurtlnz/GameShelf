using GameShelf.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace GameShelf.Domain
{
    public class DataContext : DbContext
    {
        public IConfiguration Configuration { get; }
        
        public DataContext(DbContextOptions<DataContext> options,IConfiguration configuration) 
            : base(options)
        {
            Configuration = configuration;
        }
        
        public DbSet<User> Users { get; set; }
        public DbSet<Game> Games { get; set; }
        public DbSet<UserGame> UserGames { get; set; }
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder.UseNpgsql(Configuration.GetConnectionString("(default)"));

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserGame>()
                .HasKey(ug => new {ug.GameId, ug.UserId});
            modelBuilder.Entity<UserGame>()
                .HasOne(ug => ug.Game)
                .WithMany(ug => ug.UserGames)
                .HasForeignKey(ug => ug.GameId);
            modelBuilder.Entity<UserGame>()
                .HasOne(ug => ug.User)
                .WithMany(ug => ug.UserGames)
                .HasForeignKey(ug => ug.UserId);
        }
    }
}