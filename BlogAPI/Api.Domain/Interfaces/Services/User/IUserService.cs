using Api.Domain.Dtos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Api.Domain.Interfaces.Services.User
{
    public interface IUserService
    {
        Task<UserDto> Get(int id);

        Task<IEnumerable<UserDto>> GetAll();

        Task<UserDto> Post(UserDtoCreate user);

        Task<UserDtoCreate> Put(UserDtoCreate user);

        Task<bool> Delete(int id);
    }
}
