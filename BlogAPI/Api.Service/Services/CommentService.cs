using Api.Domain.Dtos;
using Api.Domain.Entities;
using Api.Domain.Interfaces;
using Api.Domain.Interfaces.Services.Comment;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Api.Service.Services
{
    public class CommentService : ICommentService
    {
        private IRepository<CommentEntity> _repository;
        private readonly IMapper _Mapper;

        public CommentService(IRepository<CommentEntity> repository, IMapper mapper)
        {
            _repository = repository;
            _Mapper = mapper;
        }


        public async Task<bool> Delete(int id)
        {
            return await _repository.DeleteAsync(id);
        }

        public async Task<CommentDto> Get(int id)
        {
            var entity = await _repository.SelectAsync(id);
            return _Mapper.Map<CommentDto>(entity);
        }

        public async Task<IEnumerable<CommentDto>> GetAll()
        {
            var listEntity = await _repository.SelectAsync();

            return _Mapper.Map<IEnumerable<CommentDto>>(listEntity);
        }

        public async Task<CommentDto> Post(CommentDtoCreate comment)
        {
            var entity = _Mapper.Map<CommentEntity>(comment);
            var result = await _repository.InsertAsync(entity);

            return _Mapper.Map<CommentDto>(result);
        }

        public async Task<CommentDto> Put(CommentDtoCreate comment)
        {
            var entity = _Mapper.Map<CommentEntity>(comment);
            var result = await _repository.UpdateAsync(entity);

            return _Mapper.Map<CommentDto>(result);
        }
    }
}
