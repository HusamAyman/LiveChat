using Microsoft.AspNetCore.Mvc;
using LiveChat.Application.DTO;
using LiveChat.Application.Interfaces;

namespace LiveChat.WebAPI.Controllers;

public class AccountController : Controller
{
    private readonly IAuthService _authService;

    public AccountController(IAuthService authService)
    {
        _authService = authService;
    }
    
    [HttpPost("[controller]/[action]")]
    public async Task<IActionResult> Register([FromForm] RegisterRequestDto request)
    {
        AuthResult result = await _authService.RegisterAsync(request);

        if (!result.IsSucceeded)
        {
            return BadRequest(result.Errors);
        }

        return StatusCode(201, result);
    }

    [HttpPost("[controller]/[action]")]
    public async Task<IActionResult> Login([FromForm] LoginRequestDto request)
    {
        AuthResult result = await _authService.LoginAsync(request);
        if (!result.IsSucceeded)
        {
            return BadRequest(result.Errors);
        }

        return StatusCode(201, result);
    }
}