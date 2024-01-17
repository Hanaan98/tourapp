using Core.Interfaces.BL;
using Core.Interfaces.DL;
using Core.Models.Request;
using Core.Models.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class AuthService : IAuthBL
    {
        public IAuthDL authDL;
        public AuthService(IAuthDL authDL)
        {
            this.authDL = authDL;
        }

        public async Task<AuthResponseDto> LoginAdmin(AuthLoginRequestDto authLoginDto)
        {
            return await authDL.LoginAdmin(authLoginDto);
        }

        public async Task<AuthResponseDto> LoginUser(AuthLoginRequestDto authLoginDto)
        {
            return await authDL.LoginUser(authLoginDto);
        }

        public async Task<AuthResponseDto> RegisterUser(AuthSignupRequestDto authRegisterDto)
        {
            return await authDL.RegisterUser(authRegisterDto);
        }
    }
}