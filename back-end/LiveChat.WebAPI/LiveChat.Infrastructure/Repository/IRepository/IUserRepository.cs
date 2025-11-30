using LiveChat.Infrastructure.Entities;
using LiveChat.Application.DTO;

namespace LiveChat.Infrastructure.Repository.IRepository;

public interface IUserRepository
{
    Task<ICollection<ApplicationUser>> GetUserList(SearchParameters model);
}