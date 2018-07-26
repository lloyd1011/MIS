using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Http.OData;
using Microsoft.Azure.Mobile.Server;
using MIS.Backend.Models;
using MIS.Models;

namespace MIS.Backend.Controllers
{
    public class NotificationReadController : TableController<NotificationRead>
    {
        protected override void Initialize(HttpControllerContext controllerContext)
        {
            base.Initialize(controllerContext);
            MobileServiceContext context = new MobileServiceContext();
            DomainManager = new EntityDomainManager<NotificationRead>(context, Request);
        }

        // GET tables/NotificationRead
        public IQueryable<NotificationRead> GetAllNotificationRead()
        {
            return Query(); 
        }

        // GET tables/NotificationRead/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public SingleResult<NotificationRead> GetNotificationRead(string id)
        {
            return Lookup(id);
        }

        // PATCH tables/NotificationRead/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public Task<NotificationRead> PatchNotificationRead(string id, Delta<NotificationRead> patch)
        {
             return UpdateAsync(id, patch);
        }

        // POST tables/NotificationRead
        public async Task<IHttpActionResult> PostNotificationRead(NotificationRead item)
        {
            NotificationRead current = await InsertAsync(item);
            return CreatedAtRoute("Tables", new { id = current.Id }, current);
        }

        // DELETE tables/NotificationRead/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public Task DeleteNotificationRead(string id)
        {
             return DeleteAsync(id);
        }
    }
}
