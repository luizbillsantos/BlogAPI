using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Api.Domain.Dtos
{
    public class UserDtoCreate
    {
        [Required(ErrorMessage = "Name é um campo obrigatório")]
        [StringLength(100, ErrorMessage = "Name deve ter no máximo {1} caracteres")]
        public string Name { get; set; }

        [Required(ErrorMessage = "UserName é um campo obrigatório")]
        [StringLength(50, ErrorMessage = "UserName deve ter no máximo {1} caracteres")]
        public string UserName { get; set; }


        [Required(ErrorMessage = "E-mail é um campo obrigatório")]
        [EmailAddress(ErrorMessage = "E-mail em formato inválido")]
        [StringLength(50, ErrorMessage = "E-mail deve ter no máximo {1} caracteres")]
        public string Email { get; set; }

        [StringLength(20, ErrorMessage = "Phone deve ter no máximo {1} caracteres")]
        public string Phone { get; set; }

        [StringLength(100, ErrorMessage = "WebSite deve ter no máximo {1} caracteres")]
        public string WebSite { get; set; }

        [Required]
        public AddressDtoCreate Address { get; set; }

        [Required]
        public CompanyDtoCreate Company { get; set; }

    }
}
