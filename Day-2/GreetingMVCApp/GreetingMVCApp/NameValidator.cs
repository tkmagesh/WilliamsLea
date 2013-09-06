using System.Collections.Generic;

namespace GreetingMVCApp
{
    public class NameValidator
    {
        public NameValidator()
        {
            ValidationResult = new Dictionary<string, string>();
        }
        public Dictionary<string, string> ValidationResult { get; private set; }
        public void Validate(string firstName, string lastName)
        {
            if (firstName.Equals(string.Empty))
                ValidationResult["FirstName"] = "First Name cannot be empty";
            if (lastName.Equals(string.Empty))
                ValidationResult["LastName"] = "Last Name cannot be empty";
        }
        public bool HasErrors
        {
            get { return ValidationResult.Count > 0; }
        }
    }
}