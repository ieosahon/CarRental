namespace RentalCarCore.Utilities.Filters
{
    public class ValidationError : IValidationError
    {
        public string PropertyName { get; set; }
        public string Message { get; set; }
        public ValidationError(string field, string message)
        {
            PropertyName = !string.IsNullOrWhiteSpace(field) ? field : null;
            Message = message;
        }
    }
}
