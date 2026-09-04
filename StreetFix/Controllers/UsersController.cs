using Microsoft.AspNetCore.Mvc;
using StreetFix.Dtos;
using StreetFix.Services.Interfaces;

namespace StreetFix.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly IUserServices _userServices;

        public UsersController(IUserServices userServices)
        {
            _userServices = userServices;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserDto>>> GetAllUsers()
        {
            return Ok(await _userServices.GetAllUsers());
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<UserDto>> GetUserById(int id)
        {
            try
            {
                return Ok(await _userServices.GetUserById(id));
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
        }

        [HttpPost]
        public async Task<ActionResult<UserDto>> CreateUser([FromBody] UserDto user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var createdUser = await _userServices.CreateUser(user);
            return CreatedAtAction(nameof(GetUserById), new { id = createdUser.Id }, createdUser);
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult<UserDto>> UpdateUser(int id, [FromBody] UserDto user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var updatedUser = await _userServices.UpdateUser(id, user);
                return Ok(updatedUser);
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            var deleted = await _userServices.DeleteUser(id);
            if (!deleted)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
