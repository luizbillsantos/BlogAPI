using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Api.Domain.Entities
{
    public class BlogPost : BaseEntity
    {
        [Required]
        [MaxLength(244)]
        public string Title { get; set; }

        [Required]
        [MaxLength(8000)]
        public string Body { get; set; }

        [Required]
        [ForeignKey("User")]
        public int UserId { get; set; }

        public virtual UserEntity User { get; set; }

        public virtual IEnumerable<Comment> Comments { get; set; }

    }
}
