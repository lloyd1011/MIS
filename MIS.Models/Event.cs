﻿
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MIS.Models
{
    public class Event : BaseModel
    {
        public string EventTitle { get; set; }
        public AdviserOrganization AdviserOrganization { get; set; }
        public string DateStart { get; set; }
        public string DateEnd { get; set; }

    }
}