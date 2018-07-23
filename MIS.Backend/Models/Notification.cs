using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MIS.Backend.Models
{
    public class Notification
    {
        public int id { get; set; }
        public AdviserOrganization AdviserOrganization { get; set; }
        public string notification { get; set; }
        public string NotificationDate { get; set; }
        public string link { get; set; }

    }
}