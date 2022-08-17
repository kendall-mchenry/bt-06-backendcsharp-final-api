using final_api.Repositories;
using final_api.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication.JwtBearer;

namespace final_api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UsersController : ControllerBase
{
    private readonly ILogger<UsersController> _logger;

    private readonly IUserRepository _userRepository;

    public UsersController(ILogger<UsersController> logger, IUserRepository repository) {
        _logger = logger;
        _userRepository = repository;
    }

    // GET / ALL users
    [HttpGet]
    public ActionResult<IEnumerable<User>> GetAllUsers()
    {
        return Ok(_userRepository.GetAllUsers());
    }

    // GET / one user by user id
    [HttpGet]
    [Route("{userId:int}")]
    public ActionResult<User> GetUserById(int userId)
    {
        var user = _userRepository.GetUserById(userId);

        if (user == null) {
            return NotFound();
        }

        return Ok(user);
    }

    // PUT / edit user by user id
    [HttpPut]
    [Route("{userId:int}")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public ActionResult<User> EditUser(User editUser)
    {
        if (!ModelState.IsValid || editUser == null) {
            return BadRequest();
        }

        return Ok(_userRepository.EditUser(editUser));
    }

    // DELETE / user by user id (to clean up data)
    [HttpDelete]
    [Route("{userId:int}")]
    public ActionResult DeleteUser(int userId)
    {
        _userRepository.DeleteUserById(userId);
        return NoContent();
    }
}