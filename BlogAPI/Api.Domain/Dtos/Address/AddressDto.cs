using System;
using System.Collections.Generic;
using System.Text;

namespace Api.Domain.Dtos
{
    public class AddressDto
    {
        public int Id { get; set; }

        public string Street { get; set; }

        public string Suite { get; set; }

        public string City { get; set; }

        public string ZipCode { get; set; }

        public GeoDto Geo { get; set; }
    }
}
