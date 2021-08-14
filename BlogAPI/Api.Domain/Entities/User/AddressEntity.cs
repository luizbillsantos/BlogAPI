using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Api.Domain.Entities
{
    public class AddressEntity: BaseEntity
    {
        [Required]
        [MaxLength(100)]
        public string Street { get; set; }

        [Required]
        [MaxLength(100)]
        public string Suite { get; set; }

        [Required]
        [MaxLength(100)]
        public string City { get; set; }

        [Required]
        [MaxLength(10)]
        public string ZipCode { get; set; }

        [Required]
        [ForeignKey("Geo")]
        public int GeoId { get; set; }

        //[Required]
        //[ForeignKey("User")]
        //public int UserId { get; set; }

        public virtual GeoEntity Geo { get; set; }

        //public virtual UserEntity User { get; set; }
    }
}
