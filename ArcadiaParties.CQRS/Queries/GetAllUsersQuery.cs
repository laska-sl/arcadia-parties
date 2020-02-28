using ArcadiaParties.Data.Abstractions.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace ArcadiaParties.CQRS.Queries
{
    public class GetAllUsersQuery : IRequest<IEnumerable<UserDTO>>
    {
    }
}
