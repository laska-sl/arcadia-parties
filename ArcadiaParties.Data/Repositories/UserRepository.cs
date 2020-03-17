using ArcadiaParties.Data.Abstractions.DTOs;
using ArcadiaParties.Data.Abstractions.Repositories;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
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
            var user = await _context.Users
                .Include(u => u.Department)
                .Include(u => u.UserRoles)
                .ThenInclude(userRole => userRole.Role)
                .FirstOrDefaultAsync(u => u.Identity == identity);

            var userToReturn = _mapper.Map<UserDTO>(user);

            return userToReturn;
        }

        public async Task<IEnumerable<UserDTO>> GetUsers()
        {
            var users = await _context.Users
                .Include(u => u.Department)
                .Include(u => u.UserRoles)
                .ThenInclude(r => r.Role)
                .ToListAsync();

            var usersToReturn = _mapper.Map<List<UserDTO>>(users);

            return usersToReturn;
        }

        public async Task<IEnumerable<UserForCalendarDTO>> GetUsersOfDepartment(int departmentId)
        {
            var users = await _context.Users.Where(u => u.DepartmentId == departmentId).ToListAsync();
            var usersToReturn = _mapper.Map<List<UserForCalendarDTO>>(users);

            return usersToReturn;
        }
    }
}
