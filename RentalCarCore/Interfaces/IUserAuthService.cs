using RentalCarCore.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RentalCarCore.Utilities;

namespace RentalCarCore.Interfaces
{
    public interface IUserAuthService
    {
        //Task<CustomResponse<string>> UpdatePassword(UpdatePasswordDTO updatePasswordDto);
        Task<CustomResponse<string>> UpdatePasswordAsync(UpdatePasswordDTO updatePasswordDto);
    }
}
