using final_api.Repositories;
using final_api.Models;
using Microsoft.AspNetCore.Mvc;

namespace final_api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly ILogger<AuthController> _logger;

    private readonly IAuthService _authService;

    public AuthController(ILogger<AuthController> logger, IAuthService service) {
        _logger = logger;
        _authService = service;
    }

    [HttpPost]
    [Route("register")]
    public ActionResult CreateNewUser(User user)
    {
        if (user == null || !ModelState.IsValid) {
            return BadRequest();
        }

        _authService.CreateUser(user);
        return NoContent();
    }

    [HttpPost]
    [Route("signin")]
    public ActionResult<string> SignIn(SignInRequest request)
    {
        // Since we're passing in the model as a parameter instead of strings, which method of validating the request data is correct/better?
        if (string.IsNullOrWhiteSpace(request.Username) || string.IsNullOrWhiteSpace(request.Password) || request == null || !ModelState.IsValid)
        {
            return BadRequest();
        }

        var token = _authService.SignIn(request);

        if (string.IsNullOrWhiteSpace(token) || token == null)
        {
            return Unauthorized();
        }

        return Ok(token);
    }

    
}