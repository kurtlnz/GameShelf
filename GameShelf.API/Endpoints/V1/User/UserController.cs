using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using GameShelf.Domain;
using GameShelf.Domain.Services.User;
using GameShelf.Domain.Services.User.DTO;
using Microsoft.AspNetCore.Mvc;

namespace GameShelf.API.Endpoints.V1.User
{
    [ApiController]
    [Route("v1/[controller]")]
    public class UserController : Controller
    {
        private readonly IUserService _userService; 
        private readonly DataContext _db;

        public UserController(DataContext db,
            IUserService userService)
        {
            _userService = userService ?? throw new ArgumentNullException(nameof(UserService));
            _db = db ?? throw new ArgumentNullException(nameof(DataContext));
        }
        
        [HttpPost]
        [Route("CreateUser")]
        public async Task<IActionResult> CreateUser(CreateRequest req)
        {
            var dto = new CreateUser()
            {
                Name = req.Name,
                DateOfBirth = req.DateOfBirth,
                EmailAddress = req.EmailAddress
            };
            
            await _userService.CreateUser(dto);
            
            return Ok();
        }
        
        [HttpGet]
        [Route("GetUsers")]
        public async Task<ActionResult<List<Domain.Models.User>>> GetUsers()
        {
            return await _userService.GetUsers();
        }

        [HttpPost]
        [Route("UpdateUser")]
        public async Task<V1Response> DeleteUser(int id)
        {
            var (success, message) = await _userService.DeleteUser(id);

            return new V1Response(success, message);
        }

        [HttpPost]
        [Route("DeleteUser")]
        public async Task<V1Response> UpdateUser(UpdateRequest req)
        {
            var dto = new UpdateUser()
            {
                Id = req.Id,
                Name = req.Name,
                DateOfBirth = req.DateOfBirth,
                EmailAddress = req.EmailAddress
            };

            var (success, message) = await _userService.UpdateUser(dto);

            return new V1Response(success, message);
        }
    }
}