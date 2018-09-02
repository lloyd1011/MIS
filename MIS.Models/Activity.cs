using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MIS.Models
{
    public class Activity : BaseModel
    {
        public string ActivityName { get; set; }
        public string Venue { get; set; }
        public string Date { get; set; }
        public string EvaluationRating { get; set; }
        public Organization Organization { get; set; }
        public string Description { get; set; }

    }
}