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
using Api.Domain.Interfaces;

namespace Api.Data.Implementations
{
    public class CompanyImplementation : BaseRepository<CompanyEntity>, ICompanyRepository
    {
        private DbSet<CompanyEntity> _dataset;

        public CompanyImplementation(MyContext context) : base(context)
        {
            _dataset = _context.Set<CompanyEntity>();
        }
    }
}
