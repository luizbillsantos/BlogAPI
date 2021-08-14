using Api.Domain.Dtos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Api.Domain.Interfaces.Services.Comment
{
    public interface ICommentService
    {
        Task<CommentDto> Get(int id);

        Task<IEnumerable<CommentDto>> GetAll();

        Task<CommentDto> Post(CommentDtoCreate comment);

        Task<CommentDto> Put(CommentDtoCreate comment);

        Task<bool> Delete(int id);
    }
}
