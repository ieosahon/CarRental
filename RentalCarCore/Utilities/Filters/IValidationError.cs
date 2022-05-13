using Newtonsoft.Json;

namespace RentalCarCore.Utilities.Filters
{
    public interface IValidationError
    {
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string PropertyName { get; set; }
        public string Message { get; set; }
    }
}