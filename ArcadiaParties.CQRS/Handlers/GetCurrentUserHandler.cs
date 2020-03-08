﻿using ArcadiaParties.CQRS.Queries;
using ArcadiaParties.Data.Abstractions.DTOs;
using ArcadiaParties.Data.Abstractions.Repositories;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace ArcadiaParties.CQRS.Handlers
{
    internal class GetCurrentUserHandler : IRequestHandler<GetCurrentUserQuery, UserDTO>
    {
        private readonly IUserRepository _repo;

        public GetCurrentUserHandler(IUserRepository repo)
        {
            _repo = repo;
        }

        public async Task<UserDTO> Handle(GetCurrentUserQuery request, CancellationToken cancellationToken)
        {
            return await _repo.GetUser(request.Principal.Identity.Name);
        }
    }
}