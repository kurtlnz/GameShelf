using System;
using System.Threading.Tasks;
using GameShelf.Domain;
using GameShelf.Domain.Models;
using Microsoft.Extensions.Logging;

namespace GameShelf.Repository.Commands.Users
{
    public interface IDeleteUserCommand
    {
        Task<Result> Execute(User user);
    }

    public class DeleteUserCommand : IDeleteUserCommand
    {
        private readonly DataContext _context;
        private readonly ILogger<DeleteUserCommand> _logger;

        public DeleteUserCommand(DataContext context, ILogger<DeleteUserCommand> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<Result> Execute(User user)
        {
            Result result = new Result();
            try
            {
                _context.Users.Remove(user);
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