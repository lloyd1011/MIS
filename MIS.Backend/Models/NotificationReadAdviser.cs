using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MIS.Backend.Models
{
    public class NotificationReadAdviser
    {
        public int Id { get; set; }
        public Adviser Adviser { get; set; }
        public string Status { get; set; }
        public Notification Notification { get; set; }

    }
}