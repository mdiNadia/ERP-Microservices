using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Authentication.Application.Features.IdentityService.Commands
{

    public class LoginResultDto
    {

        public string Access_token { get; set; }
        public int Expires_in { get; set; }
        public string Token_type { get; set; }
        public string Refresh_token { get; set; }
        public List<string> Roles { get; set; }
        public string Scope { get; set; }

    }
}