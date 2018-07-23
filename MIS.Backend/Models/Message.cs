﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MIS.Backend.Models
{
    public class Message
    {
        public int Id { get; set; }
        public int ReceiverId { get; set; }
        public string Content { get; set; }
        public string DateSent { get; set; }
        public string SenderId { get; set; }
        public string ReceiverName { get; set; }
        public string SenderName { get; set; }
        public string SenderStatus { get; set; }

    }
}