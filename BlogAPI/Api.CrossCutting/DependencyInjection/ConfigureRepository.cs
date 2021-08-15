using Api.Data.Context;
using Api.Data.Implementations;
using Api.Data.Repository;
using Api.Domain.Interfaces;
using Api.Domain.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Api.CrossCutting.DependencyInjection
{
    public class ConfigureRepository
    {
        public static void ConfigureDepenciesRepository(IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped(typeof(IRepository<>), typeof(BaseRepository<>));
            serviceCollection.AddScoped<IUserRepository, UserImplementation>();
            serviceCollection.AddScoped<IAddressRepository, AdressImplementation>();
            serviceCollection.AddScoped<ICompanyRepository, CompanyImplementation>();
            serviceCollection.AddScoped<IGeoRepository, GeoImplementation>();
            serviceCollection.AddScoped<IAlbumRepository, AlbumImplementation>();
            serviceCollection.AddScoped<IBlogPostRepository, BlogPostImplementation>();
            serviceCollection.AddScoped<ICommentRepository, CommentImplementation>();
            serviceCollection.AddScoped<IPhotoRepository, PhotoImplementation>();

            serviceCollection.AddDbContext<MyContext>(
                options => options.UseSqlServer(Environment.GetEnvironmentVariable("DB_CONNECTION"))
            );
        }
    }
}
