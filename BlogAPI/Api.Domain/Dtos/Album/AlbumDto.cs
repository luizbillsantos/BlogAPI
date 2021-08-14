using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Api.Domain.Dtos
{
    public class AlbumDto
    {

        public int Id { get; set; }

        public int UserId { get; set; }

        public string Title { get; set; }
    }
}
