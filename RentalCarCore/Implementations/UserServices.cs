
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using RentalCarCore.Dtos;
using RentalCarCore.Interfaces;
using RentalCarInfrastructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentalCarCore.Implementations
{
    public class UserServices : IUserServices
    {

        private readonly UserManager<User> _userManager;

        public UserServices(UserManager<User> userManager)
        {
            _userManager = userManager;
            // _tokenGen = tokenGen;
        }
        public async Task<Response<string>> UpdateUserDetails(string Id, UpdateUserDto updateUserDto)
        {

            var user = await _userManager.FindByIdAsync(Id);

            if (user != null)
            {
                user.FirstName = string.IsNullOrWhiteSpace(updateUserDto.FirstName) ? user.FirstName : updateUserDto.FirstName;
                user.LastName = string.IsNullOrWhiteSpace(updateUserDto.LastName) ? user.LastName : updateUserDto.LastName;
                user.PhoneNumber = string.IsNullOrWhiteSpace(updateUserDto.PhoneNumber) ? user.PhoneNumber : updateUserDto.PhoneNumber;
                user.Address = string.IsNullOrWhiteSpace(updateUserDto.Address) ? user.Address : updateUserDto.Address;

                var result = await _userManager.UpdateAsync(user);
                if (result.Succeeded)
                {
                    return new Response<string>()
                    {
                        IsSuccessful = true,
                        Message = "Profile updated"
                    };
                }
                return new Response<string>()
                {
                    IsSuccessful = false,
                    Message = "Profile not updated"
                };
                //throw new Exception("Update operation failed");
            }

            throw new ArgumentException("User not found");
        }


    }
}

