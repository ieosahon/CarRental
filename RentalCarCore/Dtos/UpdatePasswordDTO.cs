using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentalCarCore.Dtos
{
    public class UpdatePasswordDTO : IdentityUser
    {
        [Required]
        public string CurrentPassword { get; set; }

        [Required]

        public string NewPassword { get; set; }

        //public string UserId { get; set; }

    }
}