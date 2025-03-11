using L2Art.Domain.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L2Art.Infrastructure.Configurations
{
    internal sealed class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(x => x.Id);

            builder.OwnsOne(u => u.PersonalData, un =>
            {
                un.Property(un => un.userName).HasColumnName("UserName");
            });
            builder.OwnsOne(u => u.PersonalData, em =>
            {
                em.Property(em => em.email).HasColumnName("Email");
            });
            builder.OwnsOne(u => u.PersonalData, ps =>
            {
                ps.Property(ps => ps.password).HasColumnName("Password");
            });
        }
    }
}
