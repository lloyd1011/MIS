using System;
using System.Collections.Generic;
using System.Text;

namespace MIS.Models
{
    public class UserCredential : BaseModel
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string UserType { get; set; }
    }
}
