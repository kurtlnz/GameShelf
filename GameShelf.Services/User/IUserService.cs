using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using GameShelf.Domain.Dtos;
using GameShelf.Repository;

namespace GameShelf.Services.User
{
    public interface IUserService
    {
        /// <summary>
        /// Get list of all users
        /// </summary>
        /// <returns></returns>
        Task<Result<IList<Domain.Models.User>>> GetUsersAsync();
        
        /// <summary>
        /// Retrieve user from the database
        /// </summary>
        /// <returns></returns>
        Task<Result<Domain.Models.User>> GetUserAsync(Guid id);
        
        /// <summary>
        /// Add a new user to the database
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        Task<Result> CreateUserAsync(Domain.Models.User User);
        
        
        /// <summary>
        /// Delete user from the database
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<Result> DeleteUserAsync(Guid id);
        
        /// <summary>
        /// Update user in the database
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        Task<Result> UpdateUserAsync(Domain.Models.User User);
    }
}