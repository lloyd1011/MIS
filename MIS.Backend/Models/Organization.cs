using Microsoft.Azure.Mobile.Server;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MIS.Backend.Models
{
    public class Organization : EntityData
    {
        public string OrganizationName { get; set; }
        public string Logo { get; set; }
        public College College { get; set; }
        public string AcademicYear { get; set; }
        public string Level { get; set; }
        public OrganizationType OrganizationType { get; set; }
    }
}