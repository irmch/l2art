using ErrorOr;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L2Art.Domain.Users
{
    public interface IUserRepository
    {
        void CreateUser(User user);
        Task<ErrorOr<User>> GetUserByEmail(string user, CancellationToken cancellationToken);
    }
}
