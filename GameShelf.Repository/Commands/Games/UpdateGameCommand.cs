using System;
using System.Threading.Tasks;
using GameShelf.Domain;
using GameShelf.Domain.Models;
using Microsoft.Extensions.Logging;

namespace GameShelf.Repository.Commands.Games
{
    public interface IUpdateGameCommand
    {
        Task<Result> Execute(Game game);
    }

    public class UpdateGameCommand : IUpdateGameCommand
    {
        private readonly GameShelfContext _context;
        private readonly ILogger<UpdateGameCommand> _logger;

        public UpdateGameCommand(GameShelfContext context, ILogger<UpdateGameCommand> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<Result> Execute(Game game)
        {
            Result result = new Result();
            try
            {
                _context.Games.Update(game);
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