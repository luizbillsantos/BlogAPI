using Api.Domain.Dtos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Api.Domain.Interfaces.Services
{
    public interface IGeoService
    {
        Task<GeoDto> Get(int id);

        Task<IEnumerable<GeoDto>> GetAll();

        Task<GeoDto> Post(GeoDtoCreate geo);

        Task<GeoDto> Put(GeoDtoCreate geo);

        Task<bool> Delete(int id);
    }
}
