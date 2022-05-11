using RentalCarInfrastructure.ModelValidationHelper;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentalCarInfrastructure.Models
{
    public class Location : BaseEntity
    {
        [Required]
        public string DealerId { get; set; }

        [StringLength(150, MinimumLength = 3, ErrorMessage = DataAnnotationsHelper.AddressValidator)]
        [Required]
        public string Address { get; set; }

        [StringLength(50, MinimumLength = 3, ErrorMessage = DataAnnotationsHelper.StateValidator)]
        [Required]
        public string State { get; set; }

        [StringLength(125, MinimumLength = 3, ErrorMessage = DataAnnotationsHelper.LatitudeValidator)]
        public string Latitude { get; set; }

        [StringLength(125, MinimumLength = 3, ErrorMessage = DataAnnotationsHelper.LongitudeValidator)]
        public string Longitude { get; set; }
         
        
    }
}
