using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MIS.Backend.Models
{
    public class AdviserNotification
    {
        public int id { get; set; }
        public AdviserOrganization AdviserOrganization { get; set; }
        public string notification { get; set; }
        public string notificationDate { get; set; }
        public string link { get; set; }
        public Student Student { get; set; }
        public Liability Liability { get; set; }


    }
}