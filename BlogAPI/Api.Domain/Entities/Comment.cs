using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Api.Domain.Entities
{
    public class Comment : BaseEntity
    {
        [Required]
        [ForeignKey("Post")]
        public int PostId { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        [Required]
        [MaxLength(50)]
        public string Email { get; set; }

        [Required]
        [MaxLength(244)]
        public string Body { get; set; }

        public virtual BlogPost Post { get; set; }
    }
}
