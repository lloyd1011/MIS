using System;
using System.Collections.Generic;
using System.Text;

namespace MIS.Models
{
    public class User : BaseModel
    {
        public string UserType { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string SrCode { get; set; }
        public Course Course { get; set; }
        public Year Year { get; set; }
        public string ContactNumber { get; set; }
        public string EmailAddress { get; set; }
        public College College { get; set; }
        public string Picture { get; set; }
        public string Password { get; set; }
        public string Status { get; set; }
    }
}
