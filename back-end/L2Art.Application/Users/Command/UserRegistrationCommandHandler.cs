using ErrorOr;
using L2Art.Application.Abstractions;
using L2Art.Domain.Abstractions;
using L2Art.Domain.Users;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L2Art.Application.Users.Command
{
    public class UserRegistrationCommandHandler : IRequestHandler<UserRegistrationCommand, ErrorOr<User>>
    {
        private readonly IPasswordHasher _passwordHasher;
        private readonly IUserRepository _userRepository;
        private readonly IUnitOfWork _UnitOfWork;

        public UserRegistrationCommandHandler(IPasswordHasher passwordHasher, IUserRepository userRepository, IUnitOfWork unitOfWork)
        {
            _passwordHasher = passwordHasher;
            _userRepository = userRepository;
            _UnitOfWork = unitOfWork;
        }

        public async Task<ErrorOr<User>> Handle(UserRegistrationCommand request, CancellationToken cancellationToken)
        {
            var passwordHash = _passwordHasher.Generate(request.password);

            var existingUser = await _userRepository.GetUserByEmail(request.email, cancellationToken);
            if (!existingUser.IsError)
            {
                return Error.Conflict("User.AlreadyExists", $"User with email {existingUser.Value.PersonalData.email} already exists");
            }

            var createResult = User.Create(
                new PersonalData(request.userName, request.email, passwordHash));


            var user = createResult.Value;

            _userRepository.CreateUser(user);
            await _UnitOfWork.SaveChangesAsync();

            return user;
        }

    }
}
