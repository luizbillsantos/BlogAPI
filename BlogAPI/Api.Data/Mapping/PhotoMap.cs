using Api.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Api.Data.Mapping
{
    public class PhotoMap : IEntityTypeConfiguration<PhotoEntity>
    {
        public void Configure(EntityTypeBuilder<PhotoEntity> builder)
        {
            builder.ToTable("Photo");
            builder.HasKey(u => u.Id);

            builder.Property(u => u.Title)
                   .IsRequired()
                   .HasMaxLength(244);

            builder.Property(u => u.Url)
                   .IsRequired()
                   .HasMaxLength(244);

            builder.Property(u => u.ThumbnailUrl)
                   .IsRequired()
                   .HasMaxLength(244);

            builder.HasOne(a => a.Album).WithMany(b => b.Photos);
        }
    }
}
