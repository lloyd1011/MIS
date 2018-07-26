
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MIS.Models
{
    public class Liability : BaseModel
    {
        public string LiabilityName { get; set; }
        public string Date { get; set; }
        public User User { get; set; }
        public Organization Organization { get; set; }
        public Semester Semester { get; set; }
        public SchoolYear SchoolYear { get; set; }



    }
}