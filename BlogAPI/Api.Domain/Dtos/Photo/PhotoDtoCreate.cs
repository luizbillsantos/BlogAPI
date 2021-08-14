using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Api.Domain.Dtos
{
    public class PhotoDtoCreate
    {

        [Required(ErrorMessage = "Title é um campo obrigatório")]
        [StringLength(244, ErrorMessage = "Title deve ter no máximo {1} caracteres")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Title é um campo obrigatório")]
        [StringLength(244, ErrorMessage = "Url deve ter no máximo {1} caracteres")]
        public string Url { get; set; }

        [Required(ErrorMessage = "ThumbnailUrl é um campo obrigatório")]
        [StringLength(244, ErrorMessage = "ThumbnailUrl deve ter no máximo {1} caracteres")]
        public string ThumbnailUrl { get; set; }
    }
}
