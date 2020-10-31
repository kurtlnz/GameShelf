using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GameShelf.Domain;
using GameShelf.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace GameShelf.Repository.Queries.Users
{
    public interface IGetAllUsersQuery
    {
        Task<Result<IList<User>>> Execute();
    }

    public class GetAllUsersQuery : IGetAllUsersQuery
    {
        private readonly DataContext _context;
        private readonly ILogger<GetAllUsersQuery> _logger;

        public GetAllUsersQuery(DataContext context, ILogger<GetAllUsersQuery> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<Result<IList<User>>> Execute()
        {
            var result = new Result<IList<User>>();
            try
            {
                var query = _context.Users.AsQueryable();

                result.Value = await query.ToListAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                result.Errors.Add(ex.Message);
            }

            return result;
        }
    }
}