using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MIS.Backend.Models
{
    public class Student
    {
        public int id { get; set; }
        public string firstName { get; set; }
        public string middleName { get; set; }
        public string lastName { get; set; }
        public string srCode { get; set; }
        public int courseId { get; set; }
        public int yearId { get; set; }
        public string contactNumber { get; set; }
        public string emailAddress { get; set; }
        public int collegeId { get; set; }
        public string picture { get; set; }
        public string password { get; set; }
        public string status { get; set; }
    }
}