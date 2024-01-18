using Core.Models.Response;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace Core.Models.Request
{
    public class AuthSignupRequestDto
    {
        
        public string FirstName { get; set; } = "";
        
        public string LastName { get; set; } = "";
        public string Email { get; set; } = "";
        public string Password { get; set; } = "";
        public RoleResponseDto Role { get; set; }
    }
}