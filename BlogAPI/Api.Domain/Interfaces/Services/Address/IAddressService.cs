using Api.Domain.Dtos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Api.Domain.Interfaces.Services.Address
{
    public interface IAddressService
    {
        Task<AddressDto> Get(int id);

        Task<IEnumerable<AddressDto>> GetAll();

        Task<AddressDto> Post(AddressDtoCreate address);

        Task<AddressDto> Put(AddressDtoCreate address);

        Task<bool> Delete(int id);
    }
}
