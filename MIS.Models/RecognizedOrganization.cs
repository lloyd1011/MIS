using Microsoft.Azure.Mobile.Server;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MIS.Models
{
    public class RecognizedOrganization : EntityData
    {
        public Organization Organization { get; set; }
        public Adviser Adviser { get; set; }
        public string AcademciYear { get; set; }

    }
}