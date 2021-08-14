using Api.Data.Context;
using Api.Data.Repository;
using Api.Domain.Entities;
using Api.Domain.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Api.Data.Implementations
{
    public class AdressImplementation : BaseRepository<AddressEntity>, IAddressRepository
    {


        private DbSet<AddressEntity> _dataset;

        public AdressImplementation(MyContext context) : base(context)
        {
            _dataset = _context.Set<AddressEntity>();
        }

        public Task<AddressEntity> GetCompleteById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
