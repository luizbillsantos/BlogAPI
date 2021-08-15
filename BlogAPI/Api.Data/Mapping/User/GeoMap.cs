using Api.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Api.Data.Mapping 
{
    public class GeoMap : IEntityTypeConfiguration<GeoEntity>
    {
        public void Configure(EntityTypeBuilder<GeoEntity> builder)
        {
            builder.ToTable("Geo");
            builder.HasKey(u => u.Id);

            builder.Property(u => u.Lat)
                   .IsRequired().HasColumnType("DECIMAL(18,6)");

            builder.Property(u => u.Lng)
                   .IsRequired().HasColumnType("DECIMAL(18,6)");
        }
    }
}
