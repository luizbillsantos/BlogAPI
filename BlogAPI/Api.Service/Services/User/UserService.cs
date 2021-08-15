using Api.Data.Context;
using Api.Data.Implementations;
using Api.Domain.Dtos;
using Api.Domain.Entities;
using Api.Domain.Interfaces;
using Api.Domain.Interfaces.Services;
using Api.Domain.Repository;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Api.Service.Services
{
    public class UserService : IUserService
    {

        private IUserRepository _repository;
        private readonly IMapper _Mapper;

        public UserService(IUserRepository repository, IMapper mapper)
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
            var entity = await _repository.GetCompleteById(id);
            return _Mapper.Map<UserDto>(entity);
        }

        public async Task<IEnumerable<UserDto>> GetAll()
        {
            var listEntity = await _repository.GetAllComplete();

            return _Mapper.Map<IEnumerable<UserDto>>(listEntity);
        }

        public async Task<UserDto> Post(UserDtoCreate user)
        {
            var entity = _Mapper.Map<UserEntity>(user);
            entity.Address.CreateAt = DateTime.Now;
            entity.Address.Geo.CreateAt = DateTime.Now;



            entity.Company.CreateAt = DateTime.Now;

            var result = await _repository.InsertAsync(entity);

            return _Mapper.Map<UserDto>(result);
        }

        public async Task<UserDto> Put(UserDtoCreate user)
        {
            var entity = _Mapper.Map<UserEntity>(user);
            entity.Address.UpdateAt = DateTime.Now;

            var result = await _repository.UpdateAsync(entity);

            return _Mapper.Map<UserDto>(result);
        }
    }
}
