using LiveChat.Application.Interfaces;
using LiveChat.Application.DTO;
using LiveChat.Infrastructure.Entities;
using LiveChat.Infrastructure.Repository.IRepository;

namespace LiveChat.Infrastructure.Services;

public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;

    public UserService(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }


    public async Task<ICollection<UserListDto>> GetUsers(SearchParameters model)
    {
        ICollection<ApplicationUser> userList = await _userRepository.GetUserList(model);
        if (userList is null)
        {
            return null;
        }

        var dtoList = userList.Select(u => new UserListDto
        {
            UserId = u.Id,
            DisplayName = u.DisplayName
        }).ToList();
        return dtoList;
        
        throw new NotImplementedException();
    }
}