using System.ComponentModel.DataAnnotations;

namespace Shaurya_Round.Models
{
    public class Employee
    {
        public int e_id { get; set; }
        public string Fname { get; set; }
        public string Mname { get; set; }
        public string Lname { get; set; }
        public string Gender { get; set; }

        [DataType(DataType.Date)]
        public string  DOB { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public long Pincode { get; set; }
        public long MobileNo { get; set; }
    }
}
