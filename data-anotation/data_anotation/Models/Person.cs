using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace data_anotation.Models
{
    public class Person
    {
        [Required(ErrorMessage = "Name không được để trống")]
        public string Name { get; set; }

        [Required(ErrorMessage = "DateOfBirth không được để trống")]
        public DateTime DateOfBirth { get; set; }

        [Required(ErrorMessage = "Address không được để trống")]
        public string Address { get; set; }

        [Required(ErrorMessage = "IdentityCard không được để trống")]
        public string IdentityCard { get; set; }

        [Required(ErrorMessage = "Sex không được để trống")]
        public int Sex { get; set; }

        [Required(ErrorMessage = "PhoneNumber không được để trống")]
        public string PhoneNumber { get; set; }
    }
}