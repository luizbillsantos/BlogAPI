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
        #region DbSet

        public DbSet<UserEntity> DbUser { get; set; }
        public DbSet<AddressEntity> DbAddress { get; set; }
        public DbSet<GeoEntity> DbGeo { get; set; }
        public DbSet<CompanyEntity> DbCompany { get; set; }


        public DbSet<AlbumEntity> DbAlbum { get; set; }
        public DbSet<BlogPostEntity> DbBlogPost { get; set; }
        public DbSet<CommentEntity> DbComment { get; set; }
        public DbSet<PhotoEntity> DbPhoto { get; set; }

        #endregion

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

            modelBuilder.Entity<CompanyEntity>().HasData(new CompanyEntity
            {
                Id = 1,
                CreateAt = DateTime.Now,
                UpdateAt = DateTime.Now,
                Name = "BillSoft",
                CatchPhrase = "Teste",
                Bs = "Meu Teste Técnico"
            });


            modelBuilder.Entity<GeoEntity>().HasData(new GeoEntity()
            {
                Id = 1,
                Lat = -25.722589M,
                Lng = -49.763019M,
                CreateAt = DateTime.Now,
                UpdateAt = DateTime.Now,
            });

            modelBuilder.Entity<UserEntity>().HasData(new UserEntity()
            {
                Id = 1,
                Name = "Administrador",
                Email = "luizbillsantos@gmail.com",
                UserName = "luizbillsantos",
                Phone = "5541999642960",
                CreateAt = DateTime.Now,
                UpdateAt = DateTime.Now,
                CompanyId = 1,
            });

            modelBuilder.Entity<AddressEntity>().HasData(new AddressEntity
            {
                Id = 1,
                UserId = 1,
                CreateAt = DateTime.Now,
                UpdateAt = DateTime.Now,
                City = "Lapa",
                Street = "Estrada do Lara",
                Suite = "Casa",
                ZipCode = "83750-000",
                GeoId = 1
            });

        }

    }
}
