using Api.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Api.Data.Mapping
{
    public class AlbumMap : IEntityTypeConfiguration<AlbumEntity>
    {
        public void Configure(EntityTypeBuilder<AlbumEntity> builder)
        {
            builder.ToTable("Album");
            builder.HasKey(u => u.Id);

            builder.Property(u => u.Title)
                   .IsRequired()
                   .HasMaxLength(244);

            builder.HasOne(a => a.User).WithMany(b => b.Albums);

        }
    }
}
