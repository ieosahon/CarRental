using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentalCarInfrastructure.Models
{
    public class Comment : BaseEntity
    {
        [Required]
        public string CarId { get; set; }

        [Required]
        public string Userid { get; set; }
        public string Comments { get; set; }
    }
}
