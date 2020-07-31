using System.Collections.Generic;
using System.Threading.Tasks;
using GameShelf.Domain.Services.Game.DTO;
using Microsoft.EntityFrameworkCore;

namespace GameShelf.Domain.Services.Game
{
    public class GameService : IGameService
    {
        private readonly DataContext _db;
        public GameService(DataContext db)
        {
            _db = db;
        }
        
        public async Task CreateGameAsync(CreateGame dto)
        {
            var game = new Models.Game()
            {
                Title = dto.Title,
                Year = dto.Year
            };
            
            await _db.Games.AddAsync(game);
            await _db.SaveChangesAsync();
        }
        
        public async Task<List<Models.Game>> GetGamesAsync()
        {
            return await _db.Games.ToListAsync();
        }
        
        public async Task<(bool, string)> DeleteGameAsync(int id)
        {
            var game = await _db.Games.SingleOrDefaultAsync(_ => _.Id == id);
            if (game == null)
                return (false, "Game could not be found.");
            
            _db.Games.Remove(game);
            await _db.SaveChangesAsync();

            return (true, "");
        }
        
        public async Task<(bool, string)> UpdateGameAsync(UpdateGame dto)
        {
            var game = await _db.Games.SingleOrDefaultAsync(_ => _.Id == dto.Id);
            if (game == null)
                return (false, "Game could not be found.");
            
            game.Title = dto.Title;
            game.Year = dto.Year;
            await _db.SaveChangesAsync();
            
            return (true, "");
        }
        
    }
}