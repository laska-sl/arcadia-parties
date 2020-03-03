using ArcadiaParties.Data.Abstractions.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ArcadiaParties.Data.Abstractions.Repositories
{
    public interface IDepartmentRepository
    {
        Task<IEnumerable<DepartmentDTO>> GetDepartments();

        Task<bool> DepartmentExists(int id);
    }
}
