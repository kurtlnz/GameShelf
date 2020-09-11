using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using GameShelf.Domain.Dtos;

namespace GameShelf.Domain.Services.Game
{
    public interface IGameService
    {
        /// <summary>
        /// Get list of all games
        /// </summary>
        /// <returns></returns>
        Task<List<Models.Game>> GetGamesAsync();
        
        /// <summary>
        /// Retrieve game from database
        /// </summary>
        /// <returns></returns>
        Task<Models.Game> GetGameAsync(Guid id);
        
        /// <summary>
        /// Add a new game to the database
        /// </summary>
        /// <param name="game"></param>
        /// <returns></returns>
        Task CreateGameAsync(CreateGame dto);
        
        /// <summary>
        /// Update game data
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        Task UpdateGameAsync(UpdateGame dto);
        
        /// <summary>
        /// Delete game from database
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task DeleteGameAsync(Guid id);
        
    }
}