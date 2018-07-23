using Microsoft.Azure.Mobile.Server;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MIS.Models
{
    public class Notification : EntityData
    {
        public AdviserOrganization AdviserOrganization { get; set; }
        public string NotificationName { get; set; }
        public string NotificationDate { get; set; }
        public string Link { get; set; }

    }
}