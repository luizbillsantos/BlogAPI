using Api.Domain.Dtos;
using Api.Domain.Entities;
using Api.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Api.Domain.Repository
{
    interface IUserRepository : IRepository<UserEntity>
    {
        Task<UserEntity> FindByLogin(string email);

        Task<UserDto> GetCompleteById(int id);
    }
}
