using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Game.API.Services
{
    public class GameService : IGameService
    {
        public async Task<IList<string>> GetAllGamesAsync()
        {
            await Task.CompletedTask;
            
            return new List<string>()
            {
                "Terra Mystica",
                "Barrage",
                "Caylus 1303",
            };
        }

        public Task<string> GetGameByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<string> CreateGameAsync()
        {
            throw new NotImplementedException();
        }

        public Task<string> UpdateGameAsync()
        {
            throw new NotImplementedException();
        }

        public Task DeleteGameAsync(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}