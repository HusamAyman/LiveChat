using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using LiveChat.Application.DTO;
using LiveChat.Application.Interfaces;
using LiveChat.Infrastructure.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using JwtRegisteredClaimNames = Microsoft.IdentityModel.JsonWebTokens.JwtRegisteredClaimNames;

namespace LiveChat.Infrastructure.Services;

public class AuthService : IAuthService
{
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly SignInManager<ApplicationUser> _signInManager;
    private readonly IConfiguration _configuration;

    public AuthService(UserManager<ApplicationUser> userManager,
        SignInManager<ApplicationUser> signInManager,
        IConfiguration configuration)
    {
        _userManager = userManager;
        _signInManager = signInManager;
        _configuration = configuration;
    }
    
    public async Task<AuthResult> RegisterAsync(RegisterRequestDto request, CancellationToken ct = default)
    {
        ApplicationUser newUser = new ApplicationUser
        {
            Email = request.Email,
            UserName = request.Email,
            FullName = request.FullName,
            DisplayName = request.DisplayName
        };
        IdentityResult result = await _userManager.CreateAsync(newUser, request.Password);
        if (!result.Succeeded)
        {
            return new AuthResult
            {
                IsSucceeded = false,
                Errors = result.Errors.Select(e => e.Description)
            };
        }

        return await GenerateNewJwtToken(newUser);
    }

    public async Task<AuthResult> LoginAsync(LoginRequestDto request, CancellationToken ct = default)
    {
        ApplicationUser user = await _userManager.FindByEmailAsync(request.Email);
        if (user is null)
        {
            return new AuthResult
            {
                IsSucceeded = false,
                Errors = new[] { "Invalid credentails" }
            };
        }

        var validPassword = await _userManager.CheckPasswordAsync(user, request.Password);
        if (!validPassword)
        {
            return new AuthResult
            {
                IsSucceeded = false,
                Errors = new[] { "Invalid credentails" }
            };
        }

        return await GenerateNewJwtToken(user);
    }

    private async Task<AuthResult> GenerateNewJwtToken(ApplicationUser user)
    {
        var tokenHandler = new JwtSecurityTokenHandler();
        byte[] tokenKey = Encoding.ASCII.GetBytes(_configuration["JwtSettings:Key"]);
        DateTime expires = DateTime.Now.AddYears(1);
        
        
        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(new Claim[]
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Name, user.UserName),
            }),
            Expires = expires,
            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(tokenKey), SecurityAlgorithms.HmacSha256Signature)
        };
        
        SecurityToken tokenObject = tokenHandler.CreateToken(tokenDescriptor);
        string token = tokenHandler.WriteToken(tokenObject);
        return new AuthResult
        {
            IsSucceeded = true,
            ExpiresAt = expires,
            Token = token.ToString()
        };
    }
    
}