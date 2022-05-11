using RentalCarInfrastructure.ModelValidationHelper;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentalCarInfrastructure.Models
{
    public class Dealer : BaseEntity
    {
        [Required]
        public string UserId { get; set; }

        [StringLength(150, MinimumLength = 3, ErrorMessage = DataAnnotationsHelper.CompanyNameValidator)]
        public string CompanyName { get; set; }

        [StringLength(50, MinimumLength = 3, ErrorMessage = DataAnnotationsHelper.TypeValidator)]
        public string Type { get; set; }

        [StringLength(125, MinimumLength = 3, ErrorMessage = DataAnnotationsHelper.BusinessEmailValidator)]
        public string BusinessEmail { get; set; }

        [StringLength(50, MinimumLength = 11, ErrorMessage = DataAnnotationsHelper.BusinessPhoneNumberValidator)]
        public string BusinessPhoneNumber { get; set; }

        public bool IsActivated { get; set; }


        [StringLength(50, MinimumLength = 4, ErrorMessage = DataAnnotationsHelper.IdentityNumberValidator)]
        public string IdentityNumber { get; set; }

        [StringLength(50, MinimumLength = 4, ErrorMessage = DataAnnotationsHelper.SocialMediaValidator)]
        public string SocialMedia { get; set; }

        public virtual User User { get; set; }
        public virtual ICollection<Car> Cars { get; set; }
        public virtual ICollection<Location> Locations { get; set; }
    }
}
