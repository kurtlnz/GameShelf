using System;
using System.Threading.Tasks;
using GameShelf.Domain;
using GameShelf.Domain.Models;
using Microsoft.Extensions.Logging;

namespace GameShelf.Repository.Queries.Users
{
    public interface IGetUserQuery
    {
        Task<Result> Execute(Guid id);
    }

    public class GetUserQuery : IGetUserQuery
    {
        private readonly GameShelfContext _context;
        private readonly ILogger<GetUserQuery> _logger;

        public GetUserQuery(GameShelfContext context, ILogger<GetUserQuery> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<Result> Execute(Guid id)
        {
            var result = new Result<User>();
            try
            {
                result.Value = await _context.Users.FindAsync(id);
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