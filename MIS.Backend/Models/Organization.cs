using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MIS.Backend.Models
{
    public class Organization
    {
        public int id { get; set; }
        public string organizationName { get; set; }
        public string logo { get; set; }
        public College College { get; set; }
        public string academicYear { get; set; }
        public string level { get; set; }
        public OrganizationType OrganizationType { get; set; }
    }
}