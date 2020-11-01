using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using GameShelf.Domain;
using GameShelf.Domain.Dtos;
using GameShelf.Domain.Exceptions;
using GameShelf.Repository;
using GameShelf.Repository.Commands.Users;
using GameShelf.Repository.Queries.Users;
using GameShelf.Services.User;
using Microsoft.EntityFrameworkCore;

namespace GameShelf.Services.User
{
    public class UserService : IUserService
    {
        private readonly IAddUserCommand _addUserCommand;
        private readonly IDeleteUserCommand _deleteUserCommand;
        private readonly IUpdateUserCommand _updateUserCommand;
        private readonly IGetUserQuery _getUserQuery;
        private readonly IGetAllUsersQuery _getAllUsersQuery;
        
        public UserService(
            IAddUserCommand addUserCommand,
            IDeleteUserCommand deleteUserCommand,
            IUpdateUserCommand updateUserCommand,
            IGetUserQuery getUserQuery,
            IGetAllUsersQuery getAllUsersQuery
        )
        {
            _addUserCommand = addUserCommand;
            _deleteUserCommand = deleteUserCommand;
            _updateUserCommand = updateUserCommand;
            _getUserQuery = getUserQuery;
            _getAllUsersQuery = getAllUsersQuery;
        }
        
        public async Task<Result<IList<Domain.Models.User>>> GetUsersAsync()
        {
            return await _getAllUsersQuery.Execute();
        }
        
        public async Task<Result<Domain.Models.User>> GetUserAsync(Guid id)
        {
            return await _getUserQuery.Execute(id);
        }
        
        public async Task<Result> CreateUserAsync(Domain.Models.User User)
        {
            return await _addUserCommand.Execute(User);
        }
        
        public async Task<Result> UpdateUserAsync(Domain.Models.User User)
        {
            return await _updateUserCommand.Execute(User);
        }
        
        public async Task<Result> DeleteUserAsync(Guid id)
        {
            return await _deleteUserCommand.Execute(id);
        }
        
    }
}