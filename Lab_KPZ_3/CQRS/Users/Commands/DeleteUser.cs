using Lab_KPZ_3.Data;
using Lab_KPZ_3.Data.Models;
using Lab_KPZ_3.Infrastructure.Exceptions;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Lab_KPZ_3.CQRS.Users.Commands
{
    public class DeleteUser : IRequest
    {
        public int Id { get; set; }
        public class Handler : IRequestHandler<DeleteUser>
        {
            private readonly CarpentryShopDbContext context;

            public Handler(CarpentryShopDbContext context)
            {
                this.context = context;
            }

            public async Task<Unit> Handle(DeleteUser request, CancellationToken cancellationToken)
            {
                var user = await context.Users.FindAsync(new object[] { request.Id }, cancellationToken);

                if (user is null)
                {
                    throw new NotFoundException(nameof(User), request.Id);
                }

                context.Remove(user);
                await context.SaveChangesAsync(cancellationToken);

                return Unit.Value;
            }
        }
    }
}
