using System;
using GameShelf.Domain;
using Microsoft.EntityFrameworkCore;

namespace GameShelf.Tests.Infrastructure
{
    public class GameShelfTestBase : IDisposable
    {
        protected readonly GameShelfContext _context;

        protected GameShelfTestBase()
        {
            var options = new DbContextOptionsBuilder<GameShelfContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;
            
            _context = new GameShelfContext(options, null);

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