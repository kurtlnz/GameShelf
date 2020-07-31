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
            
            await _userService.CreateUserAsync(dto);
            
            return Ok();
        }
        
        [HttpGet]
        [Route("GetUsers")]
        public async Task<ActionResult<List<Domain.Models.User>>> GetUsers()
        {
            return await _userService.GetUsersAsync();
        }

        [HttpPost]
        [Route("UpdateUser")]
        [ProducesResponseType(typeof(V1Response), 200)]
        public async Task<IActionResult> DeleteUser(int id)
        {
            var (success, message) = await _userService.DeleteUserAsync(id);

            return Ok(new V1Response(success, message));
        }

        [HttpPost]
        [Route("DeleteUser")]
        [ProducesResponseType(typeof(V1Response), 200)]
        public async Task<IActionResult> UpdateUser(UpdateRequest req)
        {
            var dto = new UpdateUser()
            {
                Id = req.Id,
                Name = req.Name,
                DateOfBirth = req.DateOfBirth,
                EmailAddress = req.EmailAddress
            };

            var (success, message) = await _userService.UpdateUserAsync(dto);

            return Ok(new V1Response(success, message));
        }
    }
}