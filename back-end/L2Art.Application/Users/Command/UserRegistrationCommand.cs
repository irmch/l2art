using ErrorOr;
using L2Art.Domain.Users;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L2Art.Application.Users.Command
{
    public record UserRegistrationCommand(string userName, string email, string password) : IRequest<ErrorOr<User>>;
}
