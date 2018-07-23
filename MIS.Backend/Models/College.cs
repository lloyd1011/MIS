using Microsoft.Azure.Mobile.Server;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MIS.Backend.Models
{
    public class College : EntityData
    {
        public string CollegeName { get; set; }
        public string Logo { get; set; }
    }
}