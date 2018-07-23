
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MIS.Models
{
    public class AdviserNotification : BaseDataObject
    {
        public AdviserOrganization AdviserOrganization { get; set; }
        public string Notification { get; set; }
        public string NotificationDate { get; set; }
        public string Link { get; set; }
        public Student Student { get; set; }
        public Liability Liability { get; set; }


    }
}