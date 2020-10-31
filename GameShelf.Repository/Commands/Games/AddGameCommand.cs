using System;
using System.Threading.Tasks;
using GameShelf.Domain;
using GameShelf.Domain.Models;
using Microsoft.Extensions.Logging;

namespace GameShelf.Repository.Commands.Games
{
    public interface IAddGameCommand
    {
        Task<Result> Execute(Game game);
    }

    public class AddGameCommand : IAddGameCommand
    {
        private readonly DataContext _context;
        private readonly ILogger<AddGameCommand> _logger;

        public AddGameCommand(DataContext context, ILogger<AddGameCommand> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<Result> Execute(Game game)
        {
            Result result = new Result();
            try
            {
                await _context.Games.AddAsync(game);
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