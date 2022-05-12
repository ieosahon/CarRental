using AutoMapper;
using Microsoft.AspNetCore.Identity;
using RentalCarCore.Dtos;
using RentalCarCore.Interfaces;
using RentalCarCore.Utilities;
using RentalCarInfrastructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentalCarCore.Services
{
    public class UserAuthService : IUserAuthService

    {

        private readonly UserManager<User> _userManager;
        private readonly IMapper _mapper;
        private readonly IdentityUser _identityUser;
        public UserAuthService(UserManager<User> userManager, IMapper mapper, IdentityUser identityUser)
        {
            _userManager = userManager;
            _mapper = mapper;
            _identityUser = identityUser;

        }

        public async Task<CustomResponse<string>> UpdatePassword(string userId, UpdatePasswordDTO updatePasswordDto)
        {
            var user = await _userManager.FindByIdAsync(userId);
            var comparePassword = await _userManager.CheckPasswordAsync(user, updatePasswordDto.CurrentPassword);
            if (comparePassword)
            {
                var result = await _userManager.ChangePasswordAsync(user, updatePasswordDto.CurrentPassword, updatePasswordDto.NewPassword);
                if (result.Succeeded)
                {
                    return new CustomResponse<string>()
                    {
                        Success = true,
                        Message = "Password updated"

                    };

                }
                return new CustomResponse<string>()
                {
                    Success = false,
                    Message = "password failed, please try again."

                };
            }

            return new CustomResponse<string>()
            {
                Message = "Current password is not correct"
            };

        }
    }
}