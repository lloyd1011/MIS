using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MIS.Backend.Models
{
    public class Activity
    {
        public int Id { get; set; }
        public string ActivityName { get; set; }
        public string Venue { get; set; }
        public DateTime Date { get; set; }
        public string EvaluationRating { get; set; }
        public Organization Organization { get; set; }
        public string Description { get; set; }

    }
}