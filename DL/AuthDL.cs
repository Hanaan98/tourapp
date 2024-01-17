using Core.Interfaces.DL;
using Core.Models;
using Core.Models.Request;
using Core.Models.Response;
using DL.DbModels;
using DL.Mapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DL
{
    public class AuthDL : IAuthDL
    {
        ApplicationDbContext _db;
        public AuthDL(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<AuthResponseDto> LoginAdmin(AuthLoginRequestDto authLoginDto)
        {
            UserDbDto _existingUser = await _db.Users.FirstOrDefaultAsync(user => user.Email == authLoginDto.Email);
            if (_existingUser == null)
            {
                throw new Exception("Invalid Email or Password");
            }
            if (_existingUser.Password != authLoginDto.Password || _existingUser.Role != Role.Admin)
            {
                throw new Exception("Invalid Email or Password");

            }
            return AuthResponseMapper.toAuthResponseAdmin(_existingUser);
        }

        public async Task<AuthResponseDto> LoginUser(AuthLoginRequestDto authLoginDto)
        {
            UserDbDto _existingUser = await _db.Users.Include(b => b.Bookings).ThenInclude(t => t.Tour).FirstOrDefaultAsync(user => user.Email == authLoginDto.Email);
              if (_existingUser == null)
              {
                throw new Exception("Invalid Email or Password");
              }
              if (_existingUser.Password != authLoginDto.Password || _existingUser.Role != Role.Customer)
              {
                throw new Exception("Invalid Email or Password");
                
              }
             return AuthResponseMapper.toAuthResponse(_existingUser);



        }

        public async Task<AuthResponseDto> RegisterUser(AuthSignupRequestDto authRegisterDto)
        {
            UserDbDto existingUser = await _db.Users.FirstOrDefaultAsync(user => user.Email == authRegisterDto.Email);
            if (existingUser!=null)
            {
                throw new Exception("User with this email already exists");
            }
            UserDbDto user = new UserDbDto()
            {
                Id = new Guid(),
                FirstName = authRegisterDto.FirstName,
                LastName = authRegisterDto.LastName,
                Email = authRegisterDto.Email,
                Password = authRegisterDto.Password,
                Role = Role.Customer,
            };
            _db.Users.Add(user);
            await _db.SaveChangesAsync();
            return AuthResponseMapper.toAuthResponse(user);
        }
        
    }
}