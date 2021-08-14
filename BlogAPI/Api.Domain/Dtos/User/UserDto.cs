using System;
using System.Collections.Generic;
using System.Text;

namespace Api.Domain.Dtos
{
    public class UserDto
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string UserName { get; set; }

        public string Email { get; set; }

        public string Phone { get; set; }

        public string WebSite { get; set; }

        public AddressDto Address { get; set; }

        public CompanyDto Company { get; set; }
             
    }
}
