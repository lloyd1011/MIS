
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MIS.Models
{
    public class Attendance : BaseModel
    {
        public Activity Activity { get; set; }
        public User User { get; set; }
        public Organization Organization { get; set; }

    }
}