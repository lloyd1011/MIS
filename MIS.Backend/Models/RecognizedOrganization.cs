﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MIS.Backend.Models
{
    public class RecognizedOrganization
    {
        public int id { get; set; }
        public Organization Organization { get; set; }
        public Adviser Adviser { get; set; }
        public string academciYear { get; set; }

    }
}