using RentalCarCore.Dtos;
using System.Threading.Tasks;

namespace RentalCarCore.Interfaces
{
    public interface IAuthentication
    {
        Task<Response<UserResponseDto>> Login(UserRequestDto userRequestDto);

        Task<Response<string>> UpdatePasswordAsync(string Id, UpdatePasswordDTO updatePasswordDto);
    }
}