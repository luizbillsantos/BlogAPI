using Api.Domain.Entities;
using Api.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Api.Domain.Repository
{
    public interface IAddressRepository : IRepository<AddressEntity>
    {
        Task<AddressEntity> GetCompleteById(int id);
    }
}
