using System.Collections.Generic;
using System.Threading.Tasks;
using GameShelf.Domain.Services.Game.DTO;

namespace GameShelf.Domain.Services.Game
{
    public interface IGameService
    {
        /// <summary>
        /// Add a new game
        /// </summary>
        /// <param name="game"></param>
        /// <returns></returns>
        Task CreateGame(CreateGame game);
        
        /// <summary>
        /// Get list of all games
        /// </summary>
        /// <returns></returns>
        Task<List<Models.Game>> GetGames();
        
        /// <summary>
        /// Delete game
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<(bool Success, string Message)> DeleteGame(int id);
        
        /// <summary>
        /// Update game data
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        Task<(bool Success, string Message)> UpdateGame(UpdateGame dto);
    }
}