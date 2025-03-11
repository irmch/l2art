using L2Art.Domain.Abstractions;
using L2Art.Domain.PrivateShops;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L2Art.Infrastructure
{
    public class ApplicationDbContext : DbContext, IUnitOfWork
    {
        public DbSet<PrivateShop> PrivateShops { get; set; }

        private readonly IPublisher _publisher;
        public ApplicationDbContext(DbContextOptions options, IPublisher publisher) : base(options)
        {
            _publisher = publisher;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
            base.OnModelCreating(modelBuilder);
        }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            try
            {
                var result = await base.SaveChangesAsync(cancellationToken);

                await PublishDomainEventsAsync();

                return result;

            }
            catch (Exception)
            {

                throw new Exception("Concurrency exception occurred.");
            }

        }

        public async Task PublishDomainEventsAsync()
        {
            var domainEvents = ChangeTracker
                .Entries<Entity>()
                .Select(e => e.Entity)
                .SelectMany(e =>
                {
                    var domainEvents = e.GetDomainEvents();
                    e.ClearDomainEvents();
                    return domainEvents;
                }).ToList();

            foreach (var domainEvent in domainEvents)
            {
                await _publisher.Publish(domainEvent);
            }
        }
    }
}
