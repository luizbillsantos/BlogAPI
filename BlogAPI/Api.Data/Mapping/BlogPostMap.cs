using Api.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Api.Data.Mapping
{
    public class BlogPostMap : IEntityTypeConfiguration<BlogPostEntity>
    {
        public void Configure(EntityTypeBuilder<BlogPostEntity> builder)
        {
            builder.ToTable("BlogPost");
            builder.HasKey(u => u.Id);

            builder.Property(u => u.Title)
                   .IsRequired()
                   .HasMaxLength(244);
            
            builder.Property(u => u.Body)
                   .IsRequired()
                   .HasMaxLength(8000);

            builder.HasOne(a => a.User).WithMany(b => b.Posts);
        }
    }
}
