using Api.Domain.Dtos;
using Api.Domain.Entities;
using Api.Domain.Interfaces;
using Api.Domain.Interfaces.Services.Address;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Api.Service.Services.User
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

        public Task<bool> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<AddressDto> Get(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<AddressDto>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<AddressDto> Post(AddressDtoCreate address)
        {
            throw new NotImplementedException();
        }

        public Task<AddressDto> Put(AddressDtoCreate address)
        {
            throw new NotImplementedException();
        }
    }
}
