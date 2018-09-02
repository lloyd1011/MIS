using System;
using System.Collections.Generic;
using System.Text;

namespace MIS.Models
{
    public class Course : BaseModel
    {
        public string CourseAcronym { get; set; }
        public string CourseTitle { get; set; }
    }
}
