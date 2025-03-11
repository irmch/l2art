using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L2Art.Infrastructure
{
    public class JwtOptions
    {
        public string SecretKey { get; set; } = string.Empty;
        public int ExpiresDays { get; set; }
    }
}
