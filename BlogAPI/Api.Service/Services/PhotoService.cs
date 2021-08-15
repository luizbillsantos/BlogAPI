using Api.Domain.Dtos;
using Api.Domain.Entities;
using Api.Domain.Interfaces;
using Api.Domain.Interfaces.Services;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Api.Service.Services
{
    public class PhotoService : IPhotoService
    {
        private IRepository<PhotoEntity> _repository;
        private readonly IMapper _Mapper;

        public PhotoService(IRepository<PhotoEntity> repository, IMapper mapper)
        {
            _repository = repository;
            _Mapper = mapper;
        }


        public async Task<bool> Delete(int id)
        {
            return await _repository.DeleteAsync(id);
        }

        public async Task<PhotoDto> Get(int id)
        {
            var entity = await _repository.SelectAsync(id);
            return _Mapper.Map<PhotoDto>(entity);
        }

        public async Task<IEnumerable<PhotoDto>> GetAll()
        {
            var listEntity = await _repository.SelectAsync();

            return _Mapper.Map<IEnumerable<PhotoDto>>(listEntity);
        }

        public async Task<PhotoDto> Post(PhotoDtoCreate post)
        {
            var entity = _Mapper.Map<PhotoEntity>(post);
            var result = await _repository.InsertAsync(entity);

            return _Mapper.Map<PhotoDto>(result);
        }

        public async Task<PhotoDto> Put(PhotoDtoCreate post)
        {
            var entity = _Mapper.Map<PhotoEntity>(post);
            var result = await _repository.UpdateAsync(entity);

            return _Mapper.Map<PhotoDto>(result);
        }
    }
}
