using ArcadiaParties.Data.Abstractions.DTOs;
using ArcadiaParties.Data.Abstractions.Repositories;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ArcadiaParties.Data.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public UserRepository(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<UserDTO> GetUser(string identity)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Identity == identity);

            var userToReturn = _mapper.Map<UserDTO>(user);

            return userToReturn;
        }

        public async Task<IEnumerable<UserDTO>> GetUsers()
        {
            var users = await _context.Users.ToListAsync();

            var usersToReturn = _mapper.Map<List<UserDTO>>(users);

            return usersToReturn;
        }
    }
}
