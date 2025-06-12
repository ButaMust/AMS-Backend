using System;
using App.Data;
using AutoMapper;
using Domain;
using MediatR;

namespace Application.Users.Commands;

public class EditUser
{
    public class Command : IRequest
    {
        public required User User { get; set; }
    }

    public class Handler(ApplicationDbContext context, IMapper mapper) : IRequestHandler<Command>
    {
        public async Task Handle(Command request, CancellationToken cancellationToken)
        {
            var user = await context.Users.FindAsync([request.User.Id], cancellationToken) ?? throw new Exception("User not found");

            mapper.Map(request.User, user);

            await context.SaveChangesAsync(cancellationToken);
        }
    }
}
