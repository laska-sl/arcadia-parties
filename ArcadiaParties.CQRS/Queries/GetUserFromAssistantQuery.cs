﻿using ArcadiaParties.Data.Abstractions.DTOs;
using MediatR;

namespace ArcadiaParties.CQRS.Queries
{
    public class GetUserFromAssistantQuery : IRequest<UserFromAssistantDTO>
    {
    }
}
