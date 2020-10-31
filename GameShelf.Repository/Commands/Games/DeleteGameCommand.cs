using System;
using System.Threading.Tasks;
using GameShelf.Domain;
using GameShelf.Domain.Models;
using Microsoft.Extensions.Logging;

namespace GameShelf.Repository.Commands.Games
{
    public interface IDeleteGameCommand
    {
        Task<Result> Execute(Game game);
    }

    public class DeleteGameCommand : IDeleteGameCommand
    {
        private readonly GameShelfContext _context;
        private readonly ILogger<DeleteGameCommand> _logger;

        public DeleteGameCommand(GameShelfContext context, ILogger<DeleteGameCommand> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<Result> Execute(Game game)
        {
            Result result = new Result();
            try
            {
                _context.Games.Remove(game);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                result.AddError(ex.Message);
            }

            return result;
        }
    }
}