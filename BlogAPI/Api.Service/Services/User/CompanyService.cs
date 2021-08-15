using Api.Domain.Dtos;
using Api.Domain.Entities;
using Api.Domain.Interfaces;
using Api.Domain.Interfaces.Services;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Api.Service.Services
{
    public class CompanyService : ICompanyService
    {

        private IRepository<CompanyEntity> _repository;
        private readonly IMapper _Mapper;


        public CompanyService(IRepository<CompanyEntity> repository, IMapper mapper)
        {
            _repository = repository;
            _Mapper = mapper;
        }

        public async Task<bool> Delete(int id)
        {
            return await _repository.DeleteAsync(id);
        }

        public async Task<CompanyDto> Get(int id)
        {
            var entity = await _repository.SelectAsync(id);
            return _Mapper.Map<CompanyDto>(entity);
        }

        public async Task<IEnumerable<CompanyDto>> GetAll()
        {
            var listEntity = await _repository.SelectAsync();

            return _Mapper.Map<IEnumerable<CompanyDto>>(listEntity);
        }

        public async Task<CompanyDto> Post(CompanyDtoCreate Company)
        {
            var entity = _Mapper.Map<CompanyEntity>(Company);
            var result = await _repository.InsertAsync(entity);

            return _Mapper.Map<CompanyDto>(result);
        }

        public async Task<CompanyDto> Put(CompanyDtoCreate Company)
        {
            var entity = _Mapper.Map<CompanyEntity>(Company);
            var result = await _repository.UpdateAsync(entity);

            return _Mapper.Map<CompanyDto>(result);
        }
    }
}
