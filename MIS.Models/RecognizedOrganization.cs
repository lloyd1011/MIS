
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MIS.Models
{
    public class RecognizedOrganization : BaseModel
    {
        public Organization Organization { get; set; }
        public Adviser Adviser { get; set; }
        public string AcademciYear { get; set; }

    }
}