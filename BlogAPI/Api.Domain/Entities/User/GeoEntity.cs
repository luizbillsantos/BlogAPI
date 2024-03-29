﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Api.Domain.Entities
{
    public class GeoEntity : BaseEntity
    {
        [Required]
        public decimal Lat { get; set; }

        [Required]
        public decimal Lng { get; set; }

        public virtual IEnumerable<AddressEntity> Addressess { get; set; }
    }
}
