using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MIS.Backend.Models
{
    public class Activity
    {
        public int id { get; set; }
        public string activityName { get; set; }
        public string venue { get; set; }
        public DateTime date { get; set; }
        public string evaluationRating { get; set; }
        public Organization Organization { get; set; }
        public string description { get; set; }
        

    }
}