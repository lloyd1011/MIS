using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MIS.Backend.Models
{
    public class Liability
    {
        public int Id { get; set; }
        public string LiabilityName { get; set; }
        public string Date { get; set; }
        public Adviser Adviser { get; set; }
        public Organization Organization { get; set; }
        public Semester Semester { get; set; }
        public SchoolYear SchoolYear { get; set; }



    }
}