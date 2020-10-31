using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using GameShelf.Domain;
using GameShelf.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace GameShelf.Repository.Queries.Games
{
    public interface IGetAllGamesQuery
    {
        Task<Result<IList<Game>>> Execute();
    }

    public class GetAllGamesQuery : IGetAllGamesQuery
    {
        private readonly GameShelfContext _context;
        private readonly ILogger<GetAllGamesQuery> _logger;

        public GetAllGamesQuery(GameShelfContext context, ILogger<GetAllGamesQuery> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<Result<IList<Game>>> Execute()
        {
            var result = new Result<IList<Game>>();
            try
            {
                var query = _context.Games.AsQueryable();

                result.Value = await query.ToListAsync();
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