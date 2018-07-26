using System;
using System.Collections.Generic;
using System.Text;

namespace MIS.Models
{
    public class Admin : BaseModel
    {
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string Picture { get; set; }
        public UserCredential UserCredential { get; set; }

    }
}
