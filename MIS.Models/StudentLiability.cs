
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MIS.Models
{
    public class StudentLiability : BaseDataObject
    { 
        public Liability Liability { get; set; }
        public Student Student { get; set; }
        public Organization Organization { get; set; }
        public string Status { get; set; }

    }
}