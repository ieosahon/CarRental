using AutoMapper;
using Microsoft.AspNetCore.Identity;
using RentalCarCore.Dtos;
using RentalCarCore.Interfaces;
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
        public UserAuthService(UserManager<User> userManager, IMapper mapper)
        {
            _userManager = userManager;
            _mapper = mapper;

        }

        public async Task<bool> UpdatePassword(UpdatePasswordDTO updatePasswordDto)
        {
            var user = await _userManager.
        }
    }
