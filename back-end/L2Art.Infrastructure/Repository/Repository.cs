using L2Art.Domain.Abstractions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L2Art.Infrastructure.Repository
{
    internal abstract class Repository<T>
        where T : Entity
    {
        protected readonly ApplicationDbContext _DbContext;

        protected Repository(ApplicationDbContext context)
        {
            _DbContext = context;
        }

        public async Task<T?> GetByIdAsync(Guid id, CancellationToken cancellationToken)
        {
            return await _DbContext.Set<T>().FirstOrDefaultAsync(res => res.Id == id, cancellationToken);
        }

        public virtual void Add(T entity)
        {
            _DbContext.Add(entity);
        }

    }
}
