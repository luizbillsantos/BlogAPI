using Api.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Api.Data.Mapping
{
    public class UserMap : IEntityTypeConfiguration<UserEntity>
    {
        public void Configure(EntityTypeBuilder<UserEntity> builder)
        {
            builder.ToTable("User");
            builder.HasKey(u => u.Id);
            builder.HasIndex(u => u.Email)
                   .IsUnique();      
            builder.Property(u => u.Name)
                   .IsRequired()
                   .HasMaxLength(100);
            builder.Property(u => u.UserName)
                   .IsRequired()
                   .HasMaxLength(50);

            builder.Property(u => u.Email)
                   .IsRequired()
                   .HasMaxLength(50);

            builder.Property(u => u.Phone)
                   .HasMaxLength(20);

            builder.Property(u => u.WebSite)
                   .HasMaxLength(100);

            builder.Property(u => u.CompanyId)
                    .IsRequired();

            builder.HasOne(a => a.Address).WithOne(b => b.User).HasForeignKey<AddressEntity>(c => c.UserId);

            builder.HasOne(a => a.Company).WithMany(b => b.User);

            builder.HasMany(a => a.Comments).WithOne(b => b.User);
        }
    }
}
