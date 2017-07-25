using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace Demo.Models.Validation
{
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property, AllowMultiple = false, Inherited = true)]
    public class CountryAttribute: ValidationAttribute
    {
        public string AllowCountry { get; set; }

        public override bool IsValid(object value)
        {
            if (value == null)
            {
                return true;
            }

            if (value.ToString() != AllowCountry)
            {
                return false;
            }

            return true;
        }
    }
}
