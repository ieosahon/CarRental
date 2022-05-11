using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentalCarInfrastructure.ModelValidationHelper
{
    public static class DataAnnotationsHelper
    {
        public const string FirstNameValidator = "FirstName must be between 2 and 50 characters in length";
        public const string LastNameValidator = "LastName must be between 2 and 50 characters in length";
        public const string PasswordValidator = "password must be between 2 and 50 characters in length";
        public const string EmailValidator = "Email must be between 10 and 125 characters in length";
        public const string PhoneNumberValidator = "PhoneNUmber must be between 11 and 50 characters in length";
        public const string AddressValidator = "Address must be between 5 and 250 characters in length";
        public const string GenderValidator = "Gender must be between 0 and 50 characters in length";
        public const string AvatarValidator = "Avatar must be between 3 and 250 characters in length";
        public const string TitleValidator = "Title must be between 3 and 50 characters in length";
        public const string ThumbnailValidator = "Thumbnail must be between 5 and 50 characters in length";
        public const string ModelValidator = "Model must be between 5 and 50 characters in length";
        public const string YearOfManValidator = "YearOfMan must be between 4 and 50 characters in length";
        public const string PlateNumberValidator = "PlateNumber must be between 10 and 150 characters in length";
        public const string ChasisNumberValidator = "ChasisNumber must be between 10 and 150 characters in length";
        public const string ColorValidator = "Color must be between 3 and 50 characters in length";
        public const string TypeOfCarValidator = "TypeOfCar must be between 3 and 50 characters in length";
        public const string UnitOfPriceValidator = "UnitOfPrice must be between 3 and 50 characters in length";
        public const string CompanyNameValidator = "CompanyName must be between 3 and 150 characters in length";
        public const string TypeValidator = "Type must be between 3 and 50 characters in length";
        public const string BusinessEmailValidator = "BusinessEmail must be between 3 and 125 characters in length";
        public const string BusinessPhoneNumberValidator = "BusinessPhoneNumber must be between 11 and 50 characters in length";
        public const string IdentityNumberValidator = "IdentityNumber must be between 4 and 50 characters in length";
        public const string SocialMediaValidator = "SocialMedia must be between 4 and 50 characters in length";
        public const string TypeOfOfferValidator = "TypeOfOffer must be between 3 and 50 characters in length";
        public const string LatitudeValidator = "Latitude must be between 3 and 50 characters in length";
        public const string LongitudeValidator = "Longitude must be between 3 and 50 characters in length";
        public const string StateValidator = "State must be between 3 and 50 characters in length";
        public const string StatusValidator = "Status must be between 4 and 50 characters in length";
        public const string PaymentMethodValidator = "PaymentMethod must be between 5 and 125 characters in length";
        public const string TransactionRefValidator = "TransactionRef must be between 5 and 125 characters in length";
        public const string TypeOfSeatValidator = "TypeOfSeat must be between 3 and 50 characters in length";
    }
}
