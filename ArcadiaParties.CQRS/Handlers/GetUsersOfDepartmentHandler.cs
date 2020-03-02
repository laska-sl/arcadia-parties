using ArcadiaParties.CQRS.Queries;
using ArcadiaParties.Data.Abstractions.DTOs;
using ArcadiaParties.Data.Abstractions.Repositories;
using AutoMapper;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace ArcadiaParties.CQRS.Handlers
{
    internal class GetUsersOfDepartmentHandler : IRequestHandler<GetUsersOfDepartmentQuery, IEnumerable<UserForCalendarDTO>>
    {
        private readonly IUserRepository _repo;
        private readonly IMapper _mapper;

        public GetUsersOfDepartmentHandler(IUserRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }
        public async Task<IEnumerable<UserForCalendarDTO>> Handle(GetUsersOfDepartmentQuery request, CancellationToken cancellationToken)
        {
            var users = await _repo.GetUsersOfDepartment(request.DepartmentId);
            var usersToReturn = _mapper.Map<List<UserForCalendarDTO>>(users);
            return usersToReturn;

        }
    }
}
