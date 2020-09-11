using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using GameShelf.Domain.Dtos;

namespace GameShelf.Domain.Services.User
{
    public interface IUserService
    {
        /// <summary>
        /// Get list of all users
        /// </summary>
        /// <returns></returns>
        Task<List<Models.User>> GetUsersAsync();
        
        /// <summary>
        /// Retrieve user from the database
        /// </summary>
        /// <returns></returns>
        Task<Models.User> GetUserAsync(Guid id);
        
        /// <summary>
        /// Add a new user to the database
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        Task CreateUserAsync(CreateUser user);
        
        
        /// <summary>
        /// Delete user from the database
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task DeleteUserAsync(Guid id);
        
        /// <summary>
        /// Update user in the database
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        Task UpdateUserAsync(UpdateUser dto);
    }
}