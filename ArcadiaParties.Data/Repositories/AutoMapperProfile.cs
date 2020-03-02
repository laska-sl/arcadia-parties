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
            CreateMap<User, UserDTO>()
                .ForMember(uDTO => uDTO.UserRoles, userDtoOpt => userDtoOpt.MapFrom(user => user.UserRoles.Select(y => y.Role.Name).ToList()))
                .ForMember(uDTO => uDTO.Department, userDtoOpt => userDtoOpt.MapFrom(user => user.Department.Name));

            CreateMap<Department, DepartmentDTO>();

            CreateMap<UserDTO, UserForCalendarDTO>()
                .ConstructUsing(user => new UserForCalendarDTO
                {
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    Dates = new List<CelebratingDateDTO>
                    {
                        new CelebratingDateDTO
                        {
                            DateName = "Birth Date",
                            Date = user.BirthDate
                        },
                        new CelebratingDateDTO
                        {
                            DateName = "Hire Date",
                            Date = user.HireDate
                        }
                    }
                });
        }
    }
}
