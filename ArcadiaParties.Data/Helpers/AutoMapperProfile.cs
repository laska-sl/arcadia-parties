using ArcadiaParties.Data.Abstractions.DTOs;
using ArcadiaParties.Data.Models;
using AutoMapper;
using System.Linq;

namespace ArcadiaParties.Data.Helpers
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<User, UserDTO>()
                .ForMember(uDTO => uDTO.UserRoles, opt => opt.MapFrom(x => x.UserRoles.Select(y => y.Role.Name).ToList()))
                .ForMember(uDTO => uDTO.Department, opt => opt.MapFrom(x => x.Department.Name));
        }
    }
}
