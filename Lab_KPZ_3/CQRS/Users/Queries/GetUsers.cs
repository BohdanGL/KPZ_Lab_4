using Lab_KPZ_3.CQRS.Users.Models;
using Lab_KPZ_3.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Lab_KPZ_3.CQRS.Users.Queries
{
    public class GetUsers : IRequest<IEnumerable<UserModel>>
    {
        public class Handler : IRequestHandler<GetUsers, IEnumerable<UserModel>>
        {
            private readonly CarpentryShopDbContext context;

            public Handler(CarpentryShopDbContext context)
            {
                this.context = context;
            }

            public async Task<IEnumerable<UserModel>> Handle(GetUsers request, CancellationToken cancellationToken)
            {
                var users = context.Users
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
                    });

                return users;
            }
        }
    }
}
