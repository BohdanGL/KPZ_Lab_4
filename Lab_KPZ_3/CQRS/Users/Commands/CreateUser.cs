using FluentValidation;
using Lab_KPZ_3.Data;
using Lab_KPZ_3.Data.Models;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Lab_KPZ_3.CQRS.Users.Commands
{
    public class CreateUser : IRequest<int>
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }

        public class Validator : AbstractValidator<CreateUser>
        {
            public Validator()
            {
                RuleFor(x => x.UserName)
                    .NotEmpty()
                    .Length(2, 50);
                RuleFor(x => x.Password)
                    .NotEmpty()
                    .Length(2, 50);
                RuleFor(x => x.FirstName)
                    .NotEmpty()
                    .Length(2, 50)
                    .Matches("[A-Z][a-z]").WithMessage("Is not a valid name. Use only latin letters.");
                RuleFor(x => x.LastName)
                    .NotEmpty()
                    .Length(2, 50)
                    .Matches("[A-Z][a-z]").WithMessage("Is not a valid name. Use only latin letters.");
                RuleFor(x => x.Email)
                    .EmailAddress();
                RuleFor(x => x.Phone)
                    .NotEmpty()
                    .Matches(@"\(?\d{3}\)?-? *\d{3}-? *-?\d{4}").WithMessage("Is not a valid name. Use only numbers");
            }
        }


        public class Handler : IRequestHandler<CreateUser, int>
        {
            private readonly CarpentryShopDbContext context;

            public Handler(CarpentryShopDbContext context)
            {
                this.context = context;
            }

            public async Task<int> Handle(CreateUser request, CancellationToken cancellationToken)
            {
                var user = new User
                {
                    UserName = request.UserName,
                    Password = request.Password,
                    FirstName = request.FirstName,
                    LastName = request.LastName,
                    Email = request.Email,
                    Phone = request.Phone,
                };

                context.Users.Add(user);
                await context.SaveChangesAsync(cancellationToken);

                return user.Id;
            }
        }
    }
}
