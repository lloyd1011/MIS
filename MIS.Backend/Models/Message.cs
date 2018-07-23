using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MIS.Backend.Models
{
    public class Message
    {
        public int id { get; set; }
        public int receiverId { get; set; }
        public string content { get; set; }
        public string dateSent { get; set; }
        public string senderId { get; set; }
        public string receiverName { get; set; }
        public string senderName { get; set; }
        public string senderStatus { get; set; }

    }
}