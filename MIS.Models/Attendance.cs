
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MIS.Models
{
    public class Attendance : BaseDataObject
    {
        public Activity Activity { get; set; }
        public Student Student { get; set; }
        public Organization Organization { get; set; }

    }
}