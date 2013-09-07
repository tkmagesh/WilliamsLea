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
            var value = new GreetInput(){FirstName = "Magesh", LastName = "someone else"};
            var result = new ObjectValidator(value).Validate();
            Console.ReadLine();
        }
    }

    public class GreetInput
    {
        [Mandatory]
        public string FirstName { get; set; }

        //String length should be minimum of 10 characters
        [MinLength(10)]
        public string LastName { get; set; }

    }

    [AttributeUsage(AttributeTargets.Property)]
    public class MandatoryAttribute : Attribute, IValidate
    {
        private readonly string _propName;
        public string ErrorMessage { get; set; }

        public bool IsValid(object value)
        {
            return value != null && !string.IsNullOrEmpty(value.ToString());
        }

        public MandatoryAttribute(string propName)
        {
            _propName = propName;
            ErrorMessage = _propName + " cannot be null or empty";
        }

        public MandatoryAttribute(string propName, string errorMessage)
        {
            _propName = propName;
            ErrorMessage = errorMessage;
        }

        public MandatoryAttribute()
        {
            ErrorMessage = "Value cannot be empty or null";
        }
    }

    [AttributeUsage(AttributeTargets.Property)]
    public class MinLengthAttribute : Attribute, IValidate
    {
        private readonly int _length;
        private readonly string _propName;
        public string ErrorMessage { get; set; }

        public bool IsValid(object value)
        {
            return value != null && value.ToString().Length >= _length;
        }

        public MinLengthAttribute(int length)
        {
            _length = length;
            ErrorMessage = string.Format("Value cannot be less that {0} charactors length", _length);
        }

        public MinLengthAttribute(int length, string errorMessage)
        {
            _length = length;
            ErrorMessage = errorMessage;
        }


        public MinLengthAttribute()
        {
            ErrorMessage = string.Format("Value cannot be less that {0} charactors length",_length);
        }
    }


    public interface IValidate
    {
        bool IsValid(object value);
        string ErrorMessage { get; set; }
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
            var type = _objectToBeValidated.GetType();
            var allPropertyInfos = type.GetProperties();
            foreach (var propertyInfo in allPropertyInfos)
            {
                var allAttributes = propertyInfo.GetCustomAttributes(false);
                foreach (var attribute in allAttributes)
                {
                    var validate = attribute as IValidate;
                    if (validate != null)
                    {
                        var attrValue = propertyInfo.GetValue(_objectToBeValidated, null);
                        var validator = validate;
                        if (!validator.IsValid(attrValue))
                        {
                            result.AddError(propertyInfo.Name, validator.ErrorMessage);
                        }
                    }
                }
            }
            //Write code 
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
