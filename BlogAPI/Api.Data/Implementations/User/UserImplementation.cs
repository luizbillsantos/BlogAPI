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
    public class UserImplementation : BaseRepository<UserEntity>, IUserRepository
    {
        private DbSet<UserEntity> _dataset;

        public UserImplementation(MyContext context) : base(context)
        {
            _dataset = _context.Set<UserEntity>();
        }

        public async Task<UserEntity> FindByLogin(string email)
        {
            return await _dataset.FirstOrDefaultAsync(a => a.Email.Equals(email));
        }

        public Task<UserDto> GetCompleteById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
