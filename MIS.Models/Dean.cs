
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MIS.Models
{
    public class Dean : BaseModel
    {
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string Picture { get; set; }
        public College College { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}