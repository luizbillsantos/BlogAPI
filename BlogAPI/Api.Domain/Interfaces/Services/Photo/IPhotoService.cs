using Api.Domain.Dtos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Api.Domain.Interfaces.Services
{
    public interface IPhotoService
    {
        Task<PhotoDto> Get(int id);

        Task<IEnumerable<PhotoDto>> GetAll();

        Task<PhotoDto> Post(PhotoDtoCreate photo);

        Task<PhotoDto> Put(PhotoDtoCreate photo);

        Task<bool> Delete(int id);
    }
}
