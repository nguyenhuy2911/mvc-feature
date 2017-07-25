using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel.DataAnnotations;
using Demo.Models.Validation;

namespace Demo.Models.Domain
{
    public class Customer
    {
        [Required]
        public virtual string CustomerID { get; set; }

        [Required]
        [StringLength(15)]
        public virtual string CompanyName { get; set; }
    
        public virtual string Address { get; set; }
    
        public virtual string City { get; set; }
    
        public virtual string PostalCode { get; set; }
    
        [Country(AllowCountry="USA")]
        public virtual string Country { get; set; }
    
        [Phone]
        public virtual string Phone { get; set; }
    }
}
