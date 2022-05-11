using RentalCarInfrastructure.ModelValidationHelper;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentalCarInfrastructure.Models
{
    public class Blog : BaseEntity
    {
        [Required]
        public string UserId { get; set; }

        [StringLength(50, MinimumLength = 3, ErrorMessage = DataAnnotationsHelper.TitleValidator)]
        public string Title { get; set; }

        public string Article { get; set; }

        [StringLength(50, MinimumLength = 5, ErrorMessage = DataAnnotationsHelper.ThumbnailValidator)]
        public string Thumbnail { get; set; }

        public bool IsActive { get; set; }
    }
}
