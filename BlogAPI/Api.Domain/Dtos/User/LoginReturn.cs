using System;
using System.Collections.Generic;
using System.Text;

namespace Api.Domain.Dtos.User
{
    public class LoginReturn
    {
        public bool Authenticated { get; set; }
        public string Create { get; set; }
        public string Expiration { get; set; }
        public string AccessToken { get; set; }
        public string UserName { get; set; }
        public string Message { get; set; }
    }
}
