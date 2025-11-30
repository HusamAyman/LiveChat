namespace LiveChat.Application.DTO;

public class AuthResult
{
    public bool IsSucceeded { get; set; }
    public string? Token { get; set; }
    public DateTime? ExpiresAt { get; set; }
    public IEnumerable<string> Errors { get; set; } = Array.Empty<string>();
}