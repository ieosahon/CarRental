using RentalCarInfrastructure.ModelValidationHelper;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RentalCarInfrastructure.Models
{
    public class Car : BaseEntity
    {
        [Required]
        public string DealerId { get; set; }

        [StringLength(50, MinimumLength = 5, ErrorMessage = DataAnnotationsHelper.ModelValidator)]
        public string Model { get; set; }


        [StringLength(50, MinimumLength = 4, ErrorMessage = DataAnnotationsHelper.YearOfManValidator)]
        public string YearOfMan { get; set; }


        [StringLength(150, MinimumLength = 10, ErrorMessage = DataAnnotationsHelper.PlateNumberValidator)]
        public string PlateNumber { get; set; }


        [StringLength(150, MinimumLength = 10, ErrorMessage = DataAnnotationsHelper.ChasisNumberValidator)]
        public string ChasisNumber { get; set; }

        
        [StringLength(50, MinimumLength = 3, ErrorMessage = DataAnnotationsHelper.ColorValidator)]
        public string Color { get; set; }

        [StringLength(50, MinimumLength = 3, ErrorMessage = DataAnnotationsHelper.TypeOfCarValidator)]
        public string TypeOfCar { get; set; }

        public int Mileage { get; set; }
        public double Price { get; set; }

        [StringLength(50, MinimumLength = 3, ErrorMessage = DataAnnotationsHelper.UnitOfPriceValidator)]
        public string UnitOfPrice { get; set; }

        public bool IsVerify { get; set; }
        public virtual Dealer Dealers { get; set; }
        public virtual CarDetail CarDetails { get; set; }
        public virtual ICollection<Rating> Ratings { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }
        public virtual ICollection<Offer> Offers { get; set; }
        public virtual ICollection<Trip> Trips { get; set; }
        public virtual ICollection<Image> Images { get; set; }
    }
}
