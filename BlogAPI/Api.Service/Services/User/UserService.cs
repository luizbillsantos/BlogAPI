using Api.Domain.Dtos;
using Api.Domain.Entities;
using Api.Domain.Interfaces;
using Api.Domain.Interfaces.Services.User;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Api.Service.Services
{
    public class UserService : IUserService
    {

        private IRepository<UserEntity> _repository;
        private readonly IMapper _Mapper;

        public UserService(IRepository<UserEntity> repository, IMapper mapper)
        {
            _repository = repository;
            _Mapper = mapper;
        }

        public async Task<bool> Delete(int id)
        {
            return await _repository.DeleteAsync(id);
        }

        public async Task<UserDto> Get(int id)
        {
            var entity = await _repository.SelectAsync(id);
            return _Mapper.Map<UserDto>(entity);
        }

        public async Task<IEnumerable<UserDto>> GetAll()
        {
            var listEntity = await _repository.SelectAsync();

            return _Mapper.Map<IEnumerable<UserDto>>(listEntity);
        }

        public async Task<UserDto> Post(UserDtoCreate user)
        {
            var entity = _Mapper.Map<UserEntity>(user);
            var result = await _repository.InsertAsync(entity);

            return _Mapper.Map<UserDto>(result);
        }

        public async Task<UserDto> Put(UserDtoCreate user)
        {
            var entity = _Mapper.Map<UserEntity>(user);
            var result = await _repository.UpdateAsync(entity);

            return _Mapper.Map<UserDto>(result);
        }
    }
}
