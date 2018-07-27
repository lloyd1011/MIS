
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MIS.Models
{
    public class NotificationRead : BaseModel
    {
        public Student Student { get; set; }
        public string StudentRead { get; set; }
        public Notification Notification { get; set; }
       
    }
}