using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using GameShelf.Domain.Dtos;
using GameShelf.Repository;

namespace GameShelf.Services.Game
{
    public interface IGameService
    {
        /// <summary>
        /// Get list of all games
        /// </summary>
        /// <returns></returns>
        Task<Result<IList<Domain.Models.Game>>> GetGamesAsync();
        
        /// <summary>
        /// Retrieve game from database
        /// </summary>
        /// <returns></returns>
        Task<Result<Domain.Models.Game>> GetGameAsync(Guid id);
        
        /// <summary>
        /// Add a new game to the database
        /// </summary>
        /// <param name="game"></param>
        /// <returns></returns>
        Task<Result> CreateGameAsync(Domain.Models.Game game);
        
        /// <summary>
        /// Update game data
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        Task<Result> UpdateGameAsync(Domain.Models.Game game);
        
        /// <summary>
        /// Delete game from database
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<Result> DeleteGameAsync(Guid id);
        
    }
}