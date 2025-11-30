namespace LiveChat.Application.DTO;

public class RegisterRequestDto
{
    public string Email { get; set; }
    public string Password { get; set; }
    public string FullName { get; set; }
    public string DisplayName { get; set; }
}