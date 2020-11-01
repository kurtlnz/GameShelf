using System;
using System.Threading.Tasks;
using GameShelf.Domain;
using GameShelf.Domain.Models;
using GameShelf.Repository.Commands.Games;
using Microsoft.Extensions.Logging;

namespace GameShelf.Repository.Queries.Games
{
    public interface IGetGameQuery
    {
        Task<Result<Game>> Execute(Guid id);
    }

    public class GetGameQuery : IGetGameQuery
    {
        private readonly GameShelfContext _context;
        private readonly ILogger<GetGameQuery> _logger;

        public GetGameQuery(GameShelfContext context, ILogger<GetGameQuery> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<Result<Game>> Execute(Guid id)
        {
            var result = new Result<Game>();
            try
            {
                result.Value = await _context.Games.FindAsync(id);
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