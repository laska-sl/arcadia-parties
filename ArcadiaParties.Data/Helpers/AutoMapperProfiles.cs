using ArcadiaParties.Data.Abstractions.DTOs;
using ArcadiaParties.Data.Models;
using AutoMapper;
using System.Linq;

namespace ArcadiaParties.Data.Helpers
{
    class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<User, UserDTO>()
                .ForMember(uDTO => uDTO.UserRoles, opt => opt.MapFrom(x => x.UserRoles.Select(y => y.Role.Name).ToList()))
                .ForMember(uDTO => uDTO.Department, opt => opt.MapFrom(x => x.Department.Name));
        }
    }
}
