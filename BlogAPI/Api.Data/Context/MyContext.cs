using Api.Data.Mapping;
using Api.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Api.Data.Context
{
    public class MyContext : DbContext
    {
        public MyContext(DbContextOptions<MyContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<UserEntity>(new UserMap().Configure);
            modelBuilder.Entity<AddressEntity>(new AddressMap().Configure);
            modelBuilder.Entity<CompanyEntity>(new CompanyMap().Configure);
            modelBuilder.Entity<GeoEntity>(new GeoMap().Configure);
            modelBuilder.Entity<AlbumEntity>(new AlbumMap().Configure);
            modelBuilder.Entity<BlogPostEntity>(new BlogPostMap().Configure);
            modelBuilder.Entity<CommentEntity>(new CommentMap().Configure);
            modelBuilder.Entity<PhotoEntity>(new PhotoMap().Configure);

            modelBuilder.Entity<UserEntity>().HasData(new UserEntity()
            {
                Name = "Administrador",
                Email = "luizbillsantos@gmail.com",
                Address = new AddressEntity()
                {
                    CreateAt = DateTime.Now,
                    UpdateAt = DateTime.Now,
                    City = "Lapa",
                    Street = "Estrada do Lara",
                    Suite = "Casa",
                    ZipCode = "83750-000",
                    Geo = new GeoEntity()
                    {
                        Lat = -544454,
                        Lng = -698555
                    }
                },
                Company = new CompanyEntity()
                {
                    CreateAt = DateTime.Now,
                    UpdateAt = DateTime.Now,
                    Name = "BillSoft",
                    CatchPhrase = "Teste",
                    Bs = "Meu Teste Técnico"
                },
                CreateAt = DateTime.Now,
                UpdateAt = DateTime.Now
            });
    }
    }
}
