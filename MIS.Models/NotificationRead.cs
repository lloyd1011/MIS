
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MIS.Models
{
    public class NotificationRead : BaseModel
    {
        public User User { get; set; }
        public string studentRead { get; set; }
        public Notification Notification { get; set; }
       
    }
}