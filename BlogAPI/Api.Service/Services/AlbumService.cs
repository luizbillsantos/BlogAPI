using Api.Domain.Dtos;
using Api.Domain.Entities;
using Api.Domain.Interfaces;
using Api.Domain.Interfaces.Services.Album;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Api.Service.Services
{
    public class AlbumService : IAlbumService
    {
        private IRepository<AlbumEntity> _repository;
        private readonly IMapper _Mapper;

        public AlbumService(IRepository<AlbumEntity> repository, IMapper mapper)
        {
            _repository = repository;
            _Mapper = mapper;
        }


        public async Task<bool> Delete(int id)
        {
            return await _repository.DeleteAsync(id);
        }

        public async Task<AlbumDto> Get(int id)
        {
            var entity = await _repository.SelectAsync(id);
            return _Mapper.Map<AlbumDto>(entity);
        }

        public async Task<IEnumerable<AlbumDto>> GetAll()
        {
            var listEntity = await _repository.SelectAsync();

            return _Mapper.Map<IEnumerable<AlbumDto>>(listEntity);
        }

        public async Task<AlbumDto> Post(AlbumDtoCreate album)
        {
            var entity = _Mapper.Map<AlbumEntity>(album);
            var result = await _repository.InsertAsync(entity);

            return _Mapper.Map<AlbumDto>(result);
        }

        public async Task<AlbumDto> Put(AlbumDtoCreate album)
        {
            var entity = _Mapper.Map<AlbumEntity>(album);
            var result = await _repository.UpdateAsync(entity);

            return _Mapper.Map<AlbumDto>(result);
        }
    }
}
