using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ValidationComponentDemo
{
    class Program
    {
        static void Main(string[] args)
        {
        }
    }

    public class GreetInput
    {
        [Mandatory]
        public string FirstName { get; set; }

        //String length should be minimum of 10 characters
        [Mandatory]
        public string LastName { get; set; }

    }

    [AttributeUsage(AttributeTargets.Property)]
    public class MandatoryAttribute : Attribute, IValidate
    {
        public bool IsValid(object value)
        {
            return string.IsNullOrEmpty(value.ToString());
        }
    }

    class ObjectValidator
    {
        private readonly object _objectToBeValidated;

        public ObjectValidator(object objectToBeValidated)
        {
            _objectToBeValidated = objectToBeValidated;
        }
        public ObjectValidationResult Validate()
        {
            var result = new ObjectValidationResult();

            return result;
        }
    }

    public class ObjectValidationResult
    {
        public Dictionary<string,string> Errors { get; private set; }
        public bool HasErrors { get { return Errors.Count > 0; } }

        public ObjectValidationResult()
        {
            Errors = new Dictionary<string, string>();
        }

        public void AddError(string propName, string errorMessage)
        {
            Errors.Add(propName,errorMessage);
        }
    }
}
