using ArcadiaParties.Data.Abstractions.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ArcadiaParties.Data.Abstractions.Repositories
{
    public interface IUserRepository
    {
        Task<UserDTO> GetUser(string identity);
        Task<List<UserDTO>> GetUsers();
    }
}
