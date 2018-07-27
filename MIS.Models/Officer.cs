using System;
using System.Collections.Generic;
using System.Text;

namespace MIS.Models
{
    public class Officer : BaseModel
    {
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public UserCredential UserCredential { get; set; }
        public Organization Organization { get; set; }
        public string Picture { get; set; }
        public string Status { get; set; }
    }
}
