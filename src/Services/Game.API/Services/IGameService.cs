using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Game.API.Services
{
    public interface IGameService
    {
        Task<IList<string>> GetAllGamesAsync();
        Task<string> GetGameByIdAsync(Guid id);
        Task<string> CreateGameAsync();
        Task<string> UpdateGameAsync();
        Task DeleteGameAsync(Guid id);
    }
}