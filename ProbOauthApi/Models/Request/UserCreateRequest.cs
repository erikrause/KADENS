using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProbOauthApi.Models.Request
{
    public class UserCreateRequest
    {
        public string Login { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
    }
}
