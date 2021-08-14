using Api.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Api.Data.Mapping
{
    public class AddressMap : IEntityTypeConfiguration<AddressEntity>
    {
        public void Configure(EntityTypeBuilder<AddressEntity> builder)
        {
            builder.ToTable("Address");
            builder.HasKey(u => u.Id);

            builder.Property(u => u.City)
                   .IsRequired()
                   .HasMaxLength(100);

            builder.Property(u => u.Street)
                   .IsRequired()
                   .HasMaxLength(100);

            builder.Property(u => u.Suite)
                   .IsRequired()
                   .HasMaxLength(100);

            builder.Property(u => u.ZipCode)
                   .IsRequired()
                   .HasMaxLength(10);

            builder.HasOne(a => a.Geo).WithMany(b => b.Addressess);
            builder.HasOne(a => a.User).WithOne(b => b.Address);
        }
    }
}
