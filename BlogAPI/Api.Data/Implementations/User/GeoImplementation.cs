using Api.Data.Repository;
using Api.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using Api.Domain.Repository;
using System.Threading.Tasks;
using Api.Domain.Dtos;
using Microsoft.EntityFrameworkCore;
using Api.Data.Context;

namespace Api.Data.Implementations
{
    public class GeoImplementation : BaseRepository<GeoEntity>, IGeoRepository
    {
        private DbSet<GeoEntity> _dataset;

        public GeoImplementation(MyContext context) : base(context)
        {
            _dataset = _context.Set<GeoEntity>();
        }
    }
}
