using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Api.Domain.Entities
{
    public class CompanyEntity : BaseEntity
    {

        [Required]
        [MaxLength(244)]
        public string Name { get; set; }

        [Required]
        [MaxLength(100)]
        public string CatchPhrase { get; set; }

        [Required]
        [MaxLength(100)]
        public string Bs { get; set; }

        public virtual IEnumerable<UserEntity> User { get; set; }
    }
}
