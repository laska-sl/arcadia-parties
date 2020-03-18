using ArcadiaParties.CQRS.Queries;
using ArcadiaParties.Data;
using ArcadiaParties.Data.Abstractions.DTOs;
using ArcadiaParties.Data.Abstractions.Repositories;
using AutoMapper;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace ArcadiaParties.CQRS.Handlers
{
    internal class GetDatesOfDepartmentHandler : IRequestHandler<GetDatesOfDepartmentQuery, IEnumerable<UsersForCalendarDTO>>
    {
        private readonly IUserRepository _repo;
        private readonly IMapper _mapper;

        public GetDatesOfDepartmentHandler(IUserRepository repo, DataContext context, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task<IEnumerable<UsersForCalendarDTO>> Handle(GetDatesOfDepartmentQuery request, CancellationToken cancellationToken)
        {
            var users = await _repo.GetUsersOfDepartment(request.DepartmentId);
            var usersToReturn = _mapper.Map<List<UsersForCalendarDTO>>(users);
            return usersToReturn;
        }
    }
}
