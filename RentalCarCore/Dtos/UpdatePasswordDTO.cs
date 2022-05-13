using Microsoft.AspNetCore.Identity;
using RentalCarInfrastructure.ModelValidationHelper;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentalCarCore.Dtos
{
    public class UpdatePasswordDTO //: IdentityUser
    {
        [Required]
        public string Id { get; set; }

        [Required]
        public string CurrentPassword { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 2, ErrorMessage = DataAnnotationsHelper.PasswordValidator)]
        public string NewPassword { get; set; }
    }
}
