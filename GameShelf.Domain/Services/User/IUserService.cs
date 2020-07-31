using System.Collections.Generic;
using System.Threading.Tasks;
using GameShelf.Domain.Services.User.DTO;

namespace GameShelf.Domain.Services.User
{
    public interface IUserService
    {
        /// <summary>
        /// Add a new user
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        Task CreateUserAsync(CreateUser user);
        
        /// <summary>
        /// Get list of all user
        /// </summary>
        /// <returns></returns>
        Task<List<Models.User>> GetUsersAsync();
        
        /// <summary>
        /// Delete user
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<(bool Success, string Message)> DeleteUserAsync(int id);
        
        /// <summary>
        /// Update user
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        Task<(bool Success, string Message)> UpdateUserAsync(UpdateUser dto);
    }
}