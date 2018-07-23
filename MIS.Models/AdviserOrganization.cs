﻿using Microsoft.Azure.Mobile.Server;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MIS.Models
{
    public class AdviserOrganization : EntityData
    {
        public Adviser Adviser { get; set; }
        public Organization Organization { get; set; }
        public College College { get; set; }
        public string ThumbNails { get; set; }
        public string SchoolYear { get; set; }

    }
}