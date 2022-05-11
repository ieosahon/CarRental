using AutoMapper;
using RentalCarInfrastructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentalCarCore.Dtos.Mapping
{
    public class UserMappings : Profile
    {
        public UserMappings()
        {
            CreateMap<User, UserRequestDto>().ReverseMap();
            CreateMap<User, UpdatePasswordDTO>();
        }
    }
}
