using ArcadiaParties.Data.Abstractions.DTOs;
using ArcadiaParties.Data.Models;
using AutoMapper;
using System.Collections.Generic;
using System.Linq;

namespace ArcadiaParties.Data.Helpers
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Department, DepartmentDTO>();

            CreateMap<UserDTO, UsersForCalendarDTO>();

            CreateMap<User, UserDTO>()
                .ConstructUsing(user => new UserDTO
                {
                    Identity = user.Identity,
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    Dates = new List<CelebratingDateDTO>
                    {
                        new CelebratingDateDTO
                        {
                            Name = "Birth Date",
                            Date = user.BirthDate
                        },
                        new CelebratingDateDTO
                        {
                            Name = "Hire Date",
                            Date = user.HireDate
                        }
                    },
                    Department = new DepartmentDTO
                    {
                        Id = user.Department.Id,
                        Name = user.Department.Name
                    }
                })
                .ForMember(uDTO => uDTO.Roles, userDtoOpt => userDtoOpt.MapFrom(user => user.UserRoles.Select(y => y.Role.Name).ToList()));
        }
    }
}
