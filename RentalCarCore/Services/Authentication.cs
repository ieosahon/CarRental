using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using RentalCarCore.Dtos;
using RentalCarCore.Interfaces;
using RentalCarInfrastructure.Models;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace RentalCarCore.Services
{
    public class Authentication : IAuthentication
    {
        private readonly UserManager<User> _userManager;
        private readonly IMapper _mapper;
        private readonly ITokenGen _tokenGen;

        public Authentication(UserManager<User> userManager, IMapper mapper, ITokenGen tokenGen)
        {
            _userManager = userManager;
            _mapper = mapper;
            _tokenGen = tokenGen;
        }
        public async Task<Response<UserResponseDto>> Login(UserRequestDto userRequestDto)
        {
            User user = await _userManager.FindByEmailAsync(userRequestDto.Email);
            if (user.GetType().GetProperties().All(x => x.GetValue(user) == null))
            {
                throw new Exception("");
            }
            if (user != null)
            {
                if (await _userManager.CheckPasswordAsync(user, userRequestDto.Password))
                {
                    var response = _mapper.Map<UserResponseDto>(user);
                    response.Token = _tokenGen.GenerateToken(user);
                    user.RefreshToken = _tokenGen.GenerateRefreshToken();
                    user.ExpiryTime = DateTime.Now.AddDays(3);
                    return new Response<UserResponseDto>
                    {
                        Data = response,
                        Message = MessageResponse.SuccessMessage,
                        ResponseCode = System.Net.HttpStatusCode.OK,
                        IsSuccessful = true
                    };
                }
                return new Response<UserResponseDto>
                {
                    Message = MessageResponse.FailedMessage,
                    ResponseCode = System.Net.HttpStatusCode.BadRequest,
                    IsSuccessful = false,
                };
            }
            throw new AccessViolationException("Invalid Credentails");
        }

        public async Task<Response<string>> UpdatePasswordAsync(UpdatePasswordDTO updatePasswordDto)
        {
            var user = await _userManager.FindByIdAsync(updatePasswordDto.Id);
            var comparePassword = await _userManager.CheckPasswordAsync(user, updatePasswordDto.CurrentPassword);
            if (comparePassword)
            {
                var result = await _userManager.ChangePasswordAsync(user, updatePasswordDto.CurrentPassword, updatePasswordDto.NewPassword);
                if (result.Succeeded)
                {
                    return new Response<string>()
                    {
                        IsSuccessful = true,
                        Message = "Password updated"
                    };

                }
                return new Response<string>()
                {
                    IsSuccessful = false,
                    ResponseCode = System.Net.HttpStatusCode.BadRequest,
                    Message = "password failed, please try again."
                };
            }

            return new Response<string>()
            {
                Message = "Current password is not correct",
                ResponseCode = System.Net.HttpStatusCode.BadRequest,
                IsSuccessful = false
            };
        }
    }
}
