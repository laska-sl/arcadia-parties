using ArcadiaParties.Data.Abstractions.DTOs;
using ArcadiaParties.Data.Models;
using AutoMapper;

namespace ArcadiaParties.Data.Helpers
{
    class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<User, UserDTO>();
            CreateMap<Role, RoleDTO>();
            CreateMap<Role, RoleDTO>();
            CreateMap<Department, DepartmentDTO>();
            CreateMap<UserRole, UserRoleDTO>();
        }
    }
}
