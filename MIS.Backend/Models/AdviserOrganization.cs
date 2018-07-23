using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MIS.Backend.Models
{
    public class AdviserOrganization
    {
        public int id { get; set; }
        public Adviser Adviser { get; set; }
        public Organization Organization { get; set; }
        public int MyProperty { get; set; }
        public College College { get; set; }
        public string thumbNails { get; set; }
        public string schoolYear { get; set; }

    }
}