using Api.Domain.Dtos;
using Api.Domain.Entities;
using Api.Domain.Interfaces;
using Api.Domain.Interfaces.Services.BlogPost;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Api.Service.Services
{
    public class PostService : IBlogPostService
    {
        private IRepository<BlogPostEntity> _repository;
        private readonly IMapper _Mapper;

        public PostService(IRepository<BlogPostEntity> repository, IMapper mapper)
        {
            _repository = repository;
            _Mapper = mapper;
        }


        public async Task<bool> Delete(int id)
        {
            return await _repository.DeleteAsync(id);
        }

        public async Task<BlogPostDto> Get(int id)
        {
            var entity = await _repository.SelectAsync(id);
            return _Mapper.Map<BlogPostDto>(entity);
        }

        public async Task<IEnumerable<BlogPostDto>> GetAll()
        {
            var listEntity = await _repository.SelectAsync();

            return _Mapper.Map<IEnumerable<BlogPostDto>>(listEntity);
        }

        public async Task<BlogPostDto> Post(BlogPostDtoCreate post)
        {
            var entity = _Mapper.Map<BlogPostEntity>(post);
            var result = await _repository.InsertAsync(entity);

            return _Mapper.Map<BlogPostDto>(result);
        }

        public async Task<BlogPostDto> Put(BlogPostDtoCreate post)
        {
            var entity = _Mapper.Map<BlogPostEntity>(post);
            var result = await _repository.UpdateAsync(entity);

            return _Mapper.Map<BlogPostDto>(result);
        }
    }
}
