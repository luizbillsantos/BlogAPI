using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Api.Domain.Dtos
{
    public class GeoDtoCreate
    {
        [Required(ErrorMessage = "Lat é um campo obrigatório")]
        public decimal Lat { get; set; }

        [Required(ErrorMessage = "Lng é um campo obrigatório")]
        public decimal Lng { get; set; }
    }
}
