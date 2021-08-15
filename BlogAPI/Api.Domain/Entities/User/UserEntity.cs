using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Api.Domain.Entities
{
    public class UserEntity : BaseEntity
    {
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        [Required]
        [MaxLength(50)]
        public string UserName { get; set; }

        [Required]
        [MaxLength(50)]
        public string Email { get; set; }

        [MaxLength(20)]
        public string Phone { get; set; }

        [MaxLength(100)]
        public string WebSite { get; set; }

        [Required]
        [ForeignKey("Company")]
        public int CompanyId { get; set; }

        public virtual AddressEntity Address { get; set; }

        public virtual CompanyEntity Company { get; set; }

        public virtual IEnumerable<BlogPostEntity> Posts { get; set; }

        public virtual IEnumerable<AlbumEntity> Albums { get; set; }

        public virtual IEnumerable<CommentEntity> Comments { get; set; }
    }
}
