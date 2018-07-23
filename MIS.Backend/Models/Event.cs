using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MIS.Backend.Models
{
    public class Event
    {
        public int Id { get; set; }
        public string EventTitle { get; set; }
        public AdviserOrganization AdviserOrganization { get; set; }
        public string DateStart { get; set; }
        public string DateEnd { get; set; }

    }
}