using LiveChat.Application.DTO;

namespace LiveChat.Application.Interfaces;

public interface IAuthService
{
    Task<AuthResult> RegisterAsync(RegisterRequestDto request, CancellationToken ct = default);
    Task<AuthResult> LoginAsync(LoginRequestDto request, CancellationToken ct = default);
}