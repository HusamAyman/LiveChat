using LiveChat.Application.DTO;

namespace LiveChat.Application.Interfaces;

public interface IUserService
{
    Task<ICollection<UserListDto>> GetUsers(SearchParameters model);
}