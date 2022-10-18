using Lab_KPZ_3.CQRS.Users.Models;
using Lab_KPZ_3.Data;
using Lab_KPZ_3.Data.Models;
using Lab_KPZ_3.Infrastructure.Exceptions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Lab_KPZ_3.CQRS.Users.Queries
{
    public class GetUserById : IRequest<UserModel>
    {
        public int Id { get; set; }
        public class Handler : IRequestHandler<GetUserById, UserModel>
        {
            private readonly CarpentryShopDbContext context;

            public Handler(CarpentryShopDbContext context)
            {
                this.context = context;
            }

            public async Task<UserModel> Handle(GetUserById request, CancellationToken cancellationToken)
            {
                var user = await context.Users
                    .AsNoTracking()
                    .Select(r => new UserModel
                    {
                        Id = r.Id,
                        UserName = r.UserName,
                        Password = r.Password,
                        FirstName = r.FirstName,
                        LastName = r.LastName,
                        Email = r.Email,
                        Phone = r.Phone,
                    })
                    .FirstOrDefaultAsync(s => s.Id == request.Id, cancellationToken);

                if(user is null)
                {
                    throw new NotFoundException(nameof(User), request.Id);
                }

                return user;
            }
        }
    }
}
