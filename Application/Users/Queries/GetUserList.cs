using System;
using App.Data;
using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Users.Queries;

public class GetUserList
{
    public class Query : IRequest<List<User>> { }

    public class Handler(ApplicationDbContext context) : IRequestHandler<Query, List<User>>
    {
        public async Task<List<User>> Handle(Query request, CancellationToken cancellationToken)
        {
            return await context.Users.ToListAsync(cancellationToken);
        }
    }
}
