using RentalCarInfrastructure.ModelValidationHelper;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentalCarInfrastructure.Models
{
    public class Transaction : BaseEntity
    {
        [Required]
        public string TripId { get; set; }
        public double Amount { get; set; }

        [StringLength(125, MinimumLength = 5, ErrorMessage = DataAnnotationsHelper.PaymentMethodValidator)]
        public string PaymentMethod { get; set; }

        [StringLength(125, MinimumLength = 5, ErrorMessage = DataAnnotationsHelper.TransactionRefValidator)]
        public string TransactionRef { get; set; }

        [StringLength(50, MinimumLength = 4, ErrorMessage = DataAnnotationsHelper.StatusValidator)]
        public string Status { get; set; }

        public virtual Trip Trips { get; set; }
    }
}
