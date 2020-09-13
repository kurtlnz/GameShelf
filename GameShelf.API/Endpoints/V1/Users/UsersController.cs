using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using GameShelf.Domain;
using GameShelf.Domain.Dtos;
using GameShelf.Domain.Services.User;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace GameShelf.API.Endpoints.V1.User
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly ILogger<UserController> _logger;

        public UserController(IUserService userService, ILogger<UserController> logger)
        {
            _userService = userService ?? throw new ArgumentNullException(nameof(UserService));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }
        
        // GET: /users
        [HttpGet]
        [ProducesResponseType( StatusCodes.Status200OK)]
        public async Task<ActionResult<List<Domain.Models.User>>> GetUsers()
        {
            try
            {
                var result = await _userService.GetUsersAsync();
                
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                
                return StatusCode(500);
            }
        }
        
        // GET: /users/{id}
        [HttpGet("{id}")]
        [ProducesResponseType( StatusCodes.Status200OK)]
        public async Task<ActionResult<Domain.Models.User>> GetUser(Guid id)
        {
            try
            {
                var result = await _userService.GetUserAsync(id);
                
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                
                return StatusCode(500);
            }
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

            try
            {
                await _userService.CreateUserAsync(dto);
                
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                
                return StatusCode(500);
            }
        }
        
        // PUT: /users/{id}
        [HttpPut]
        [ProducesResponseType( StatusCodes.Status200OK)]
        public async Task<IActionResult> UpdateUser(UpdateUser dto)
        {
            try
            {
                await _userService.UpdateUserAsync(dto);

                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                
                return StatusCode(500);
            }
        }

        // DELETE: /users/{id}
        [HttpDelete]
        [ProducesResponseType( StatusCodes.Status200OK)]
        public async Task<IActionResult> DeleteUser(Guid id)
        {
            try
            {
                await _userService.DeleteUserAsync(id);
                
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                
                return StatusCode(500);
            }
        }
    }
}