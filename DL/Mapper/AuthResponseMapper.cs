using Core.Models.Response;
using DL.DbModels;


namespace DL.Mapper
{
    public class AuthResponseMapper
    {
        public static AuthResponseDto toAuthResponse(UserDbDto user)
        {
            return new AuthResponseDto
            {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                Password = user.Password,
                Role = RoleResponseDto.Customer,
            };
        }
        public static AuthResponseDto toAuthResponseAdmin(UserDbDto user)
        {
            return new AuthResponseDto
            {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                Password = user.Password,
                Role = RoleResponseDto.Admin,
            };
        }
    }
}