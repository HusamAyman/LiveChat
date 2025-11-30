using LiveChat.Application.DTO;
using LiveChat.Infrastructure.Entities;
using LiveChat.Infrastructure.Repository.IRepository;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace LiveChat.Infrastructure.Repository;

public class UserRepository : IUserRepository
{
    private readonly UserManager<ApplicationUser> _userManager;

    public UserRepository(UserManager<ApplicationUser> userManager)
    {
        _userManager = userManager;
    }
    
    public async Task<ICollection<ApplicationUser>> GetUserList(SearchParameters model)
    {
        IQueryable<ApplicationUser> query = _userManager.Users
            .Skip(model.PageSize * (model.PageNumber - 1))
            .Take(model.PageSize)
            .OrderBy(u => u.DisplayName)
            ;
        if (!string.IsNullOrEmpty(model.Search))
        {
            string searchTerm = model.Search.Trim();
            query.Where(u => u.DisplayName.Contains(searchTerm));
        }

        return await query.ToListAsync();
    }
}