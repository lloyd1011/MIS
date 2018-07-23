﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MIS.Backend.Models
{
    public class StudentLiability
    {
        public int Id { get; set; }
        public Liability Liability { get; set; }
        public Student Student { get; set; }
        public Organization Organization { get; set; }
        public string Status { get; set; }

    }
}