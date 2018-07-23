using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MIS.Backend.Models
{
    public class Officer
    {
        public int id { get; set; }
        public string firstName { get; set; }
        public string middleName { get; set; }
        public string lastName { get; set; }
        public Organization Organization { get; set; }
        public string userName { get; set; }
        public string password { get; set; }
        public string picture { get; set; }
    }
}