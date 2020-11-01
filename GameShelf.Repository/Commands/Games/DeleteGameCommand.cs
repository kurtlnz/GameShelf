using System;
using System.Threading.Tasks;
using GameShelf.Domain;
using GameShelf.Domain.Models;
using Microsoft.Extensions.Logging;

namespace GameShelf.Repository.Commands.Games
{
    public interface IDeleteGameCommand
    {
        Task<Result> Execute(Guid id);
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

        public async Task<Result> Execute(Guid id)
        {
            Result result = new Result();
            var game = new Game { Id = id };
            
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