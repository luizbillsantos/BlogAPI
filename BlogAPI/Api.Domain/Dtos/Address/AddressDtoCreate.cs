using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Api.Domain.Dtos
{
    public class AddressDtoCreate
    {

        [Required(ErrorMessage = "Street é um campo obrigatório")]
        [StringLength(100, ErrorMessage = "Street deve ter no máximo {1} caracteres")]
        public string Street { get; set; }

        [Required(ErrorMessage = "Suite é um campo obrigatório")]
        [StringLength(100, ErrorMessage = "Suite deve ter no máximo {1} caracteres")]
        public string Suite { get; set; }

        [Required(ErrorMessage = "City é um campo obrigatório")]
        [StringLength(100, ErrorMessage = "City deve ter no máximo {1} caracteres")]
        public string City { get; set; }

        [Required(ErrorMessage = "ZipCode é um campo obrigatório")]
        [StringLength(10, ErrorMessage = "ZipCode deve ter no máximo {1} caracteres")]
        public string ZipCode { get; set; }

        [Required]
        public GeoDtoCreate Geo { get; set; }
    }
}
