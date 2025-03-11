using ErrorOr;
using L2Art.Application.Abstractions;
using L2Art.Domain.Users;
using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L2Art.Application.Users.Command
{
    public class UserLoginCommandHandler : IRequestHandler<UserLoginCommand, ErrorOr<string>>
    {
        private readonly IUserRepository _userRepository;
        private readonly IPasswordHasher _passwordHasher;
        private readonly IJwtProvider _jwtProvider;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public UserLoginCommandHandler(IUserRepository userRepository, IPasswordHasher passwordHasher, IJwtProvider jwtProvider, IHttpContextAccessor httpContextAccessor)
        {
            _userRepository = userRepository;
            _passwordHasher = passwordHasher;
            _jwtProvider = jwtProvider;
            _httpContextAccessor = httpContextAccessor;
        }


        public async Task<ErrorOr<string>> Handle(UserLoginCommand request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetUserByEmail(request.email, cancellationToken);

            if (user.IsError)
            {
                return Error.NotFound("User.NotFound", $"User with email {request.email} found");
            }

            var res = _passwordHasher.Verify(request.password, user.Value.PersonalData.password);

            if (!res)
            {
                return Error.Validation(code: "User.InvalidCredentials",
                    description: "Invalid password or email");
            }



            var token = _jwtProvider.GenerateToken(user.Value);

            _httpContextAccessor.HttpContext.Response.Cookies.Append("tasty-cookies", token);

            return token;
        }
    }
}
