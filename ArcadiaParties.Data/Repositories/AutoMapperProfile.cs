﻿using ArcadiaParties.Data.Abstractions.DTOs;
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

            CreateMap<User, UserForCalendarDTO>()
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
                            DateName = "Birth Date",
                            Date = user.BirthDate
                        },
                        new CelebratingDateDTO
                        {
                            DateName = "Hire Date",
                            Date = user.HireDate
                        }
                    },
                    Department = new DepartmentDTO
                    {
                        Id = user.Department.Id,
                        Name = user.Department.Name
                    }
                })
                .ForMember(uDTO => uDTO.UserRoles, userDtoOpt => userDtoOpt.MapFrom(user => user.UserRoles.Select(y => y.Role.Name).ToList()));
        }
    }
}
