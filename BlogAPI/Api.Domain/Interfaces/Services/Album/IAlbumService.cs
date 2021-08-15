using Api.Domain.Dtos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Api.Domain.Interfaces.Services
{
    public interface IAlbumService
    {
        Task<AlbumDto> Get(int id);

        Task<IEnumerable<AlbumDto>> GetAll();

        Task<AlbumDto> Post(AlbumDtoCreate album);

        Task<AlbumDto> Put(AlbumDtoCreate album);

        Task<bool> Delete(int id);
    }
}
