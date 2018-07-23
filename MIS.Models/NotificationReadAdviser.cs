
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MIS.Models
{
    public class NotificationReadAdviser : BaseDataObject
    {
        public Adviser Adviser { get; set; }
        public string Status { get; set; }
        public Notification Notification { get; set; }

    }
}