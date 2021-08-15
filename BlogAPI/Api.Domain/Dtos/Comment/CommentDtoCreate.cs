using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Text.Json.Serialization;

namespace Api.Domain.Dtos
{
    public class CommentDtoCreate
    {

        [Required(ErrorMessage = "Name é um campo obrigatório")]
        [StringLength(100, ErrorMessage = "Name deve ter no máximo {1} caracteres")]
        public string Name { get; set; }

        [Required(ErrorMessage = "E-mail é um campo obrigatório")]
        [EmailAddress(ErrorMessage = "E-mail em formato inválido")]
        [StringLength(50, ErrorMessage = "E-mail deve ter no máximo {1} caracteres")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Body é um campo obrigatório")]
        [StringLength(244, ErrorMessage = "Body deve ter no máximo {1} caracteres")]
        public string Body { get; set; }

        [Required(ErrorMessage = "PostId é um campo obrigatório")]
        [Range(1, int.MaxValue, ErrorMessage = "PostId é um campo obrigatório")]
        public int PostId { get; set; }

        [JsonIgnore]
        public int UserId { get; set; }
    }
}
