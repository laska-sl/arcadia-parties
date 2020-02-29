using ArcadiaParties.Data.Abstractions.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ArcadiaParties.Data.Abstractions.Repositories
{
    public interface IUserRepository
    {
        Task<UserDTO> GetUser(string identity);
        Task<IEnumerable<UserDTO>> GetUsers();
        Task<IEnumerable<string>> GetUserRoles(string identity);
    }
}
