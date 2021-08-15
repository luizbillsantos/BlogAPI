using Api.Domain.Dtos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Api.Domain.Interfaces.Services
{
    public interface IBlogPostService
    {
        Task<BlogPostDto> Get(int id);

        Task<IEnumerable<BlogPostDto>> GetAll();

        Task<BlogPostDto> Post(BlogPostDtoCreate blogPost);

        Task<BlogPostDto> Put(BlogPostDtoCreate blogPost);

        Task<bool> Delete(int id);
    }
}
