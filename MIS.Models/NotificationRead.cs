using Microsoft.Azure.Mobile.Server;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MIS.Models
{
    public class NotificationRead : EntityData
    {
        public Student Student { get; set; }
        public string studentRead { get; set; }
        public Notification Notification { get; set; }
       
    }
}