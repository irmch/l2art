using ErrorOr;
using L2Art.Domain.Users;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L2Art.Infrastructure.Repository
{
    internal class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(ApplicationDbContext context) : base(context)
        {
        }

        public void CreateUser(User user)
        {
            _DbContext.Add(user);
        }

        public async Task<ErrorOr<User>> GetUserByEmail(string email, CancellationToken cancellationToken)
        {
            var user = await _DbContext.Set<User>()
                               .Where(item => item.PersonalData.email == email)
                               .FirstOrDefaultAsync(cancellationToken);

            if (user is null)
            {
                return Error.NotFound("User.NotFound", $"User with email {email} not found.");
            }

            return user;
        }
    }
}
