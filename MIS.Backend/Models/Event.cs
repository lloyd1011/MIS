using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MIS.Backend.Models
{
    public class Event
    {
        public int id { get; set; }
        public string eventTitle { get; set; }
        public AdviserOrganization AdviserOrganization { get; set; }
        public string dateStart { get; set; }
        public string dateEnd { get; set; }

    }
}