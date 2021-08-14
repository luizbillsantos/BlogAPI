using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Api.Domain.Dtos
{
    public class BlogPostDtoCreate
    {
        [Required(ErrorMessage = "Title é um campo obrigatório")]
        [StringLength(244, ErrorMessage = "Title deve ter no máximo {1} caracteres")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Body é um campo obrigatório")]
        [StringLength(8000, ErrorMessage = "Body deve ter no máximo {1} caracteres")]
        public string Body { get; set; }

    }
}
