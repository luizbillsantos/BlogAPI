using Api.Domain.Dtos;
using Api.Domain.Interfaces.Services.User;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Api.Service.Services
{
    public class LoginService : ILoginService
    {
        public async Task<object> FindByLogin(LoginDto user)
        {
            throw new NotImplementedException();
        }
    }
}
