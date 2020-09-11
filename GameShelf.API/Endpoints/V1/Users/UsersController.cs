using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using GameShelf.Domain;
using GameShelf.Domain.Dtos;
using GameShelf.Domain.Services.User;
using Microsoft.AspNetCore.Http;
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
        
        // GET: /users
        [HttpGet]
        [ProducesResponseType( StatusCodes.Status200OK)]
        public async Task<ActionResult<List<Domain.Models.User>>> GetUsers()
        {
            var result = await _userService.GetUsersAsync();
            
            return Ok(result);
        }
        
        // GET: /users/{id}
        [HttpGet]
        [ProducesResponseType( StatusCodes.Status200OK)]
        public async Task<ActionResult<Domain.Models.User>> GetUser(Guid id)
        {
            var result = await _userService.GetUserAsync(id);
            
            return Ok(result);
        }
        
        // POST: /users
        [HttpPost]
        [ProducesResponseType( StatusCodes.Status200OK)]
        [ProducesResponseType( StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CreateUser(CreateUser dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            
            await _userService.CreateUserAsync(dto);
            
            return Ok();
        }
        
        // PUT: /users/{id}
        [HttpPut]
        [ProducesResponseType( StatusCodes.Status200OK)]
        public async Task<IActionResult> UpdateUser(UpdateUser dto)
        {
            await _userService.UpdateUserAsync(dto);

            return Ok();
        }

        // DELETE: /users/{id}
        [HttpDelete]
        [ProducesResponseType( StatusCodes.Status200OK)]
        public async Task<IActionResult> DeleteUser(Guid id)
        {
            await _userService.DeleteUserAsync(id);
            
            return Ok();
        }
    }
}