using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using RentalCarCore.Dtos;
using RentalCarCore.Interfaces;
using RentalCarInfrastructure.Models;
using System;
using System.Security.Claims;
using System.Threading.Tasks;

namespace RentalCarApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {

        private readonly IUserServices _userServie;
        private readonly UserManager<User> _userManager;

        public UsersController(IUserServices userServie, UserManager<User> userManager)
        {
            _userServie = userServie;
            _userManager = userManager;
        }


        [HttpPost]
        [Route("Update-user-profile")]
        public async Task<IActionResult> UpdatePassword(UpdateUserDto updateUserdDto)
        {


            var userId = HttpContext.User.FindFirst(user => user.Type == ClaimTypes.NameIdentifier).Value;

            try
            {

                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                if (ModelState.IsValid)
                {
                    var result = await _userServie.UpdateUserDetails(userId, updateUserdDto);
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
