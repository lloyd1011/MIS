using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MIS.Backend.Models
{
    public class NotificationRead
    {
        public int Id { get; set; }
        public Student Student { get; set; }
        public string studentRead { get; set; }
        public Notification Notification { get; set; }
       
    }
}