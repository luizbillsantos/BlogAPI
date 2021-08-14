using Api.Data.Repository;
using Api.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using Api.Domain.Repository;
using System.Threading.Tasks;
using Api.Domain.Dtos;
using Microsoft.EntityFrameworkCore;
using Api.Data.Context;

namespace Api.Data.Implementations
{
    public class BlogPostImplementation : BaseRepository<BlogPostEntity>, IBlogPostRepository
    {

        private DbSet<BlogPostEntity> _dataset;

        public BlogPostImplementation(MyContext context) : base(context)
        {
            _dataset = _context.Set<BlogPostEntity>();
        }
    }
}
