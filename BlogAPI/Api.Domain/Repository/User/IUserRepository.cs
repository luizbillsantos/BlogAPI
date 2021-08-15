using Api.Domain.Dtos;
using Api.Domain.Entities;
using Api.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Api.Domain.Repository
{
    public interface IUserRepository : IRepository<UserEntity>
    {
        Task<UserEntity> FindByLogin(string email);

        Task<UserEntity> GetCompleteById(int id);

        Task<List<UserEntity>> GetAllComplete();
    }
}
