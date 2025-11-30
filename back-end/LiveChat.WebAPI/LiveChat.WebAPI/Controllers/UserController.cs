using LiveChat.Application.Interfaces;
using LiveChat.Application.DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LiveChat.WebAPI.Controllers;

[Authorize]
public class UserController : Controller
{
    private readonly IUserService _userService;

    public UserController(IUserService userService)
    {
        _userService = userService;
    }

    [HttpGet("[controller]/[action]")]
    public async Task<IActionResult> GetUsersList([FromQuery] SearchParameters model)
    {
        var userList = await _userService.GetUsers(model);
        return Ok(userList);
    }
    
}