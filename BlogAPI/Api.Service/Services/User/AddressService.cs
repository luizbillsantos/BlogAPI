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
    public class AddressService : IAddressService
    {


        private IRepository<AddressEntity> _repository;
        private readonly IMapper _Mapper;


        public AddressService(IRepository<AddressEntity> repository, IMapper mapper)
        {
            _repository = repository;
            _Mapper = mapper;
        }
        public async Task<bool> Delete(int id)
        {
            return await _repository.DeleteAsync(id);
        }

        public async Task<AddressDto> Get(int id)
        {
            var entity = await _repository.SelectAsync(id);
            return _Mapper.Map<AddressDto>(entity);
        }

        public async Task<IEnumerable<AddressDto>> GetAll()
        {
            var listEntity = await _repository.SelectAsync();

            return _Mapper.Map<IEnumerable<AddressDto>>(listEntity);
        }

        public async Task<AddressDto> Post(AddressDtoCreate address)
        {
            var entity = _Mapper.Map<AddressEntity>(address);
            var result = await _repository.InsertAsync(entity);

            return _Mapper.Map<AddressDto>(result);
        }

        public async Task<AddressDto> Put(AddressDtoCreate address)
        {
            var entity = _Mapper.Map<AddressEntity>(address);
            var result = await _repository.UpdateAsync(entity);

            return _Mapper.Map<AddressDto>(result);
        }
    }
}
