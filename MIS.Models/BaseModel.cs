
using System;
using System.Collections.Generic;
using System.Text;
#if MOBILE
#else
using Microsoft.Azure.Mobile.Server;
#endif


namespace MIS.Models
{
#if MOBILE
    public class BaseModel
    {
        public string Id { get; set; }

        [Microsoft.WindowsAzure.MobileServices.Version]
        public byte[] Version { get; set; }

        [Microsoft.WindowsAzure.MobileServices.CreatedAt]
        public DateTimeOffset? CreatedAt { get; set; }

        [Microsoft.WindowsAzure.MobileServices.UpdatedAt]
        public DateTimeOffset? UpdatedAt { get; set; }
    }
#else
    public class BaseModel : EntityData
    {
    }
#endif
}
