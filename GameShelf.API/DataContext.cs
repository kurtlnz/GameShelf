using GameShelf.API.Models;
using Microsoft.EntityFrameworkCore;

namespace GameShelf.API
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) 
            : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Game> Games { get; set; }
    }
}