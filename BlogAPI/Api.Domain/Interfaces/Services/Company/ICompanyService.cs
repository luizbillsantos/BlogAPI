using Api.Domain.Dtos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Api.Domain.Interfaces.Services
{
    public interface ICompanyService
    {
        Task<CompanyDto> Get(int id);

        Task<IEnumerable<CompanyDto>> GetAll();

        Task<CompanyDto> Post(CompanyDtoCreate company);

        Task<CompanyDto> Put(CompanyDtoCreate company);

        Task<bool> Delete(int id);
    }
}
