using System;
using System.Collections.Generic;
using System.Text;

namespace Api.Domain.Entities
{
    public class GeoEntity : BaseEntity
    {
        public decimal Lat { get; set; }

        public decimal Lng { get; set; }

        public virtual IEnumerable<AddressEntity> Addressess { get; set; }
    }
}
