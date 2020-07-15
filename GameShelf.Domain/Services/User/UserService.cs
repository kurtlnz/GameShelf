using System.Collections.Generic;
using System.Threading.Tasks;
using GameShelf.Domain.Services.User.DTO;
using Microsoft.EntityFrameworkCore;

namespace GameShelf.Domain.Services.User
{
    public class UserService : IUserService
    {
        private readonly DataContext _db;
        public UserService(DataContext db)
        {
            _db = db;
        }
        
        public async Task CreateUser(CreateUser dto)
        {
            var user = new Models.User()
            {
                Name = dto.Name,
                DateOfBirth = dto.DateOfBirth,
                EmailAddress = dto.EmailAddress
            };
            await _db.Users.AddAsync(user);
            
            await _db.SaveChangesAsync();
        }
        
        public async Task<List<Models.User>> GetUsers()
        {
            return await _db.Users.ToListAsync();
        }
        
        public async Task<(bool, string)> DeleteUser(int id)
        {
            var user = await _db.Users.SingleOrDefaultAsync(_ => _.Id == id);
            
            if (user == null)
            {
                return (false, "User could not be found.");
            }
            _db.Users.Remove(user);
            
            await _db.SaveChangesAsync();

            return (true, "");
        }
        
        public async Task<(bool, string)> UpdateUser(UpdateUser dto)
        {
            var user = await _db.Users.SingleOrDefaultAsync(_ => _.Id == dto.Id);

            if (user == null)
            {
                return (false, "User could not be found.");
            }
            user.Name = dto.Name;
            user.DateOfBirth = dto.DateOfBirth;
            user.EmailAddress = dto.EmailAddress;
            
            await _db.SaveChangesAsync();
            
            return (true, "");
        }
        
    }
}