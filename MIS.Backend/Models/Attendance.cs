﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MIS.Backend.Models
{
    public class Attendance
    {
        public int Id { get; set; }
        public Activity Activity { get; set; }
        public Student Student { get; set; }
        public Organization Organization { get; set; }

    }
}