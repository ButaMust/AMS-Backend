using System;
using App.Data;
using MediatR;

namespace Application.Users.Commands;

public class DeleteUser
{
    public class Command : IRequest
    {
        public required string Id { get; set; }
    }

    public class Handler(ApplicationDbContext context) : IRequestHandler<Command>
    {
        public async Task Handle(Command request, CancellationToken cancellationToken)
        {
            var user = await context.Users.FindAsync([request.Id], cancellationToken) ?? throw new Exception("User not found");

            context.Remove(user);

            await context.SaveChangesAsync(cancellationToken);
        }
    }
}
