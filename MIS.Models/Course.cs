
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MIS.Models
{
    public class Course : BaseModel
    {
        public string CourseAcronym { get; set; }
        public string CourseTitle { get; set; }

    }
}