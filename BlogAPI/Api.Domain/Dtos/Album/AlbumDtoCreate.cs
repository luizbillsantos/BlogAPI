using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Api.Domain.Dtos
{
    public class AlbumDtoCreate
    {
        [Required(ErrorMessage = "Title é um campo obrigatório")]
        [StringLength(244, ErrorMessage = "Title deve ter no máximo {1} caracteres")]
        public string Title { get; set; }
    }
}
