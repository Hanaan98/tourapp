using Core.Models.Request;
using Core.Models.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces.DL
{
    public interface IAuthDL
    {
        public Task<AuthResponseDto> LoginUser(AuthLoginRequestDto authLoginDto);
        public Task<AuthResponseDto> RegisterUser(AuthSignupRequestDto authRegisterDto);
        public Task<AuthResponseDto> LoginAdmin(AuthLoginRequestDto authLoginDto);
    }
}