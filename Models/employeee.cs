using System;
using System.ComponentModel.DataAnnotations;

namespace Shaurya_Round.Models
{
    public class employeee
    {
        [Key]
        [ScaffoldColumn(false)]
        public int Eid { get; set; }
        public string Fname { get; set; }
        public string Mname { get; set; }
        public string Lname { get; set; }
        public string Gender { get; set; }
        
        public string DOB { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public int Pcode { get; set; }

        [Required(ErrorMessage = "You must provide a phone number")]
        [DataType(DataType.PhoneNumber)]
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "Not a valid phone number")]
        public string Mobile { get; set; }
    }
}
