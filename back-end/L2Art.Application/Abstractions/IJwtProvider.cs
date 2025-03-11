using L2Art.Domain.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L2Art.Application.Abstractions
{
    public interface IJwtProvider
    {
        string GenerateToken(User user);
    }
}
