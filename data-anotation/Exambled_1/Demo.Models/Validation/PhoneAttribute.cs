using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace Demo.Models.Validation
{
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property, AllowMultiple = false, Inherited = true)]
    public class PhoneAttribute : RegexAttribute
    {
        public PhoneAttribute()
            : base(@"^[2-9]\d{2}-\d{3}-\d{4}$", RegexOptions.IgnoreCase)
        { }
    }
}
