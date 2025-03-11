using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L2Art.Application.Data
{
    public interface IConnectionFactory
    {
        IDbConnection CreateConnection();
    }
}
