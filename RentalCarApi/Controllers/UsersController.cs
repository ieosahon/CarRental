using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RentalCarCore.Dtos;
using RentalCarCore.Interfaces;
using System;
using System.Threading.Tasks;

namespace RentalCarApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {

        private readonly IUserServices _userServie;

        public UsersController(IUserServices userServie)
        {
            _userServie = userServie;
        }


        [HttpPost]
        [Route("Update-password")]
        public async Task<IActionResult> UpdatePassword(UpdateUserDto updateUserdDto)
        {
            try
            {

                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                if (ModelState.IsValid)
                {
                    var result = await _userServie.UpdateUserDetails(updateUserdDto);
                    return Ok(result);
                }

                return BadRequest(ModelState);

            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }

        }
    }
}
