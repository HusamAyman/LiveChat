using Microsoft.AspNetCore.Identity;

namespace LiveChat.Infrastructure.Entities;

public class ApplicationUser : IdentityUser<Guid>
{
    public string FullName { get; set; }
    public string DisplayName { get; set; }
    public string? ProfilePicture { get; set; }
    public DateTime CreatedOn { get; set; }
    public DateTime? ModifiedOn { get; set; }
}