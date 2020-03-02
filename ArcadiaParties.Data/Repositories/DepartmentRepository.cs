using System.Collections.Generic;
using System.Threading.Tasks;
using ArcadiaParties.Data.Abstractions.DTOs;
using ArcadiaParties.Data.Abstractions.Repositories;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace ArcadiaParties.Data.Repositories
{
    public class DepartmentRepository : IDepartmentRepository
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public DepartmentRepository(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<DepartmentDTO>> GetDepartments()
        {
            var departments = await _context.Department.ToListAsync();
            var departmentsToReturn = _mapper.Map<List<DepartmentDTO>>(departments);
            return departmentsToReturn;
        }
    }
}