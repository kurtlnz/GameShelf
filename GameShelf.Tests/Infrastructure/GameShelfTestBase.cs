using System;
using GameShelf.Domain;
using Microsoft.EntityFrameworkCore;

namespace GameShelf.Tests.Infrastructure
{
    public class GameShelfTestBase : IDisposable
    {
        protected readonly DataContext _context;

        public GameShelfTestBase()
        {
            var options = new DbContextOptionsBuilder<DataContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;
            
            _context = new DataContext(options, null);

            _context.Database.EnsureCreated();
            
            GameShelfInitializer.Initialize(_context);
        }
        
        public void Dispose()
        {
            _context.Database.EnsureDeleted();

            _context.Dispose();
        }
    }
}