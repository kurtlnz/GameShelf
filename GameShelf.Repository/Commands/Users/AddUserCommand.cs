using System;
using System.Threading.Tasks;
using GameShelf.Domain;
using GameShelf.Domain.Models;
using Microsoft.Extensions.Logging;

namespace GameShelf.Repository.Commands.Users
{
    public interface IAddUserCommand
    {
        Task<Result> Execute(User user);
    }

    public class AddUserCommand : IAddUserCommand
    {
        private readonly GameShelfContext _context;
        private readonly ILogger<AddUserCommand> _logger;

        public AddUserCommand(GameShelfContext context, ILogger<AddUserCommand> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<Result> Execute(User user)
        {
            Result result = new Result();
            try
            {
                await _context.Users.AddAsync(user);
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