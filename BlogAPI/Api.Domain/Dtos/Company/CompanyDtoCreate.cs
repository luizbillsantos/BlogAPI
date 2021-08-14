using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Api.Domain.Dtos
{
    public class CompanyDtoCreate
    {
        [Required(ErrorMessage = "Name é um campo obrigatório")]
        [StringLength(244, ErrorMessage = "Name deve ter no máximo {1} caracteres")]
        public string Name { get; set; }

        [Required(ErrorMessage = "CatchPhrase é um campo obrigatório")]
        [StringLength(100, ErrorMessage = "CatchPhrase deve ter no máximo {1} caracteres")]
        public string CatchPhrase { get; set; }

        [Required(ErrorMessage = "Bs é um campo obrigatório")]
        [StringLength(100, ErrorMessage = "Bs deve ter no máximo {1} caracteres")]
        public string Bs { get; set; }
    }
}
