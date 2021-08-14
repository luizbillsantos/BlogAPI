using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Api.Domain.Entities
{
    public class Album : BaseEntity
    {
        [Required]
        [ForeignKey("User")]
        public int UserId { get; set; }

        [Required]
        [MaxLength(244)]
        public string Title { get; set; }

        public virtual UserEntity User { get; set; }

        public virtual IEnumerable<Photo> Photos { get; set; }
    }
}
