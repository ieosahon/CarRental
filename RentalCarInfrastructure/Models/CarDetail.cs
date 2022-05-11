using RentalCarInfrastructure.ModelValidationHelper;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentalCarInfrastructure.Models
{
    public class CarDetail : BaseEntity
    {
        [Required]
        public string CarId { get; set; }

        [StringLength(50, MinimumLength = 3, ErrorMessage = DataAnnotationsHelper.TypeOfSeatValidator)]
        public string TypeOfSeat { get; set; }

        public bool Sunroof { get; set; }
        public bool Bluetooth { get; set; }
        public bool NavigationSystem { get; set; }
        public bool AirCondition { get; set; }
        public bool RemoteStart { get; set; }
        public bool BackUpcamera { get; set; }
        public bool ThirdRowSeating { get; set; }
        public bool Driver { get; set; }
        public bool CarPlay { get; set; }
        public bool IsTrack { get; set; }
        public virtual Car Cars { get; set; }
    }
}
