using System;
using System.Threading.Tasks;
using GameShelf.Domain;
using GameShelf.Domain.Models;
using Microsoft.Extensions.Logging;

namespace GameShelf.Repository.Commands.Users
{
    public interface IUpdateUserCommand
    {
        Task<Result> Execute(User user);
    }

    public class UpdateUserCommand : IUpdateUserCommand
    {
        private readonly GameShelfContext _context;
        private readonly ILogger<UpdateUserCommand> _logger;

        public UpdateUserCommand(GameShelfContext context, ILogger<UpdateUserCommand> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<Result> Execute(User user)
        {
            Result result = new Result();
            try
            {
                _context.Users.Update(user);
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