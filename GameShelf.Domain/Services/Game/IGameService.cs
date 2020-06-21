using System.Collections.Generic;
using System.Threading.Tasks;
using GameShelf.Domain.Services.Game.DTO;

namespace GameShelf.Domain.Services.Game
{
    public interface IGameService
    {
        /// <summary>
        /// Add a new game entity to db
        /// </summary>
        /// <param name="game"></param>
        /// <returns></returns>
        Task CreateGame(CreateGame game);
        
        /// <summary>
        /// Get list of all game entities in db
        /// </summary>
        /// <returns></returns>
        Task<List<Models.Game>> GetGames();
        
        /// <summary>
        /// Delete game entity from db by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<(bool Success, string Message)> DeleteGame(int id);
        
        /// <summary>
        /// Update game entity data
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        Task<(bool Success, string Message)> UpdateGame(UpdateGame dto);
    }
}