using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RentalCarCore.Dtos;
using RentalCarCore.Interfaces;
using System.Threading.Tasks;
using System;

namespace RentalCarApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserAuthController : ControllerBase
    {

        private readonly IUserAuthService _userAuthService;
        // private readonly IUserService _userService;

        public UserAuthController(IUserAuthService userAuthService)
        {
            _userAuthService = userAuthService;
        }

        [HttpPost]
        [Route("Update-password")]
        public async Task<IActionResult> UpdatePassword(UpdatePasswordDTO updatePasswordDto)
        {
            try
            {

                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                if (ModelState.IsValid)
                {
                    var result = await _userAuthService.UpdatePasswordAsync(updatePasswordDto);
                }

                return BadRequest(ModelState);

            }
            catch (Exception ex)
            {
                return new BadRequestObjectResult(ex.Message);

            }
        }
    }
}
