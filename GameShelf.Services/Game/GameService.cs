using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using GameShelf.Repository;
using GameShelf.Repository.Commands.Games;
using GameShelf.Repository.Queries.Games;

namespace GameShelf.Services.Game
{
    public class GameService : IGameService
    {
        private readonly IAddGameCommand _addGameCommand;
        private readonly IDeleteGameCommand _deleteGameCommand;
        private readonly IUpdateGameCommand _updateGameCommand;
        private readonly IGetGameQuery _getGameQuery;
        private readonly IGetAllGamesQuery _getAllGamesQuery;
        
        public GameService(
            IAddGameCommand addGameCommand,
            IDeleteGameCommand deleteGameCommand,
            IUpdateGameCommand updateGameCommand,
            IGetGameQuery getGameQuery,
            IGetAllGamesQuery getAllGamesQuery
            )
        {
            _addGameCommand = addGameCommand;
            _deleteGameCommand = deleteGameCommand;
            _updateGameCommand = updateGameCommand;
            _getGameQuery = getGameQuery;
            _getAllGamesQuery = getAllGamesQuery;
        }
        
        public async Task<Result<IList<Domain.Models.Game>>> GetGamesAsync()
        {
            return await _getAllGamesQuery.Execute();
        }
        
        public async Task<Result<Domain.Models.Game>> GetGameAsync(Guid id)
        {
            return await _getGameQuery.Execute(id);
        }
        
        public async Task<Result> CreateGameAsync(Domain.Models.Game game)
        {
            return await _addGameCommand.Execute(game);
        }
        
        public async Task<Result> UpdateGameAsync(Domain.Models.Game game)
        {
            return await _updateGameCommand.Execute(game);
        }
        
        public async Task<Result> DeleteGameAsync(Guid id)
        {
            return await _deleteGameCommand.Execute(id);
        }
        
    }
}