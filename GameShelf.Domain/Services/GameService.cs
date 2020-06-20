using System.Collections.Generic;
using System.Threading.Tasks;
using GameShelf.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace GameShelf.Domain.Services
{
    public class GameService : IGameService
    {
        private readonly DataContext _db;
        public GameService(DataContext db)
        {
            _db = db;
        }
        
        public async Task<Game> AddGame(Game game)
        {
            _db.Games.Add(game);
            _db.SaveChangesAsync();
            return game;
        }
        
        public async Task<List<Game>> GetGames()
        {
            return await _db.Games.ToListAsync();
        }
    }
}