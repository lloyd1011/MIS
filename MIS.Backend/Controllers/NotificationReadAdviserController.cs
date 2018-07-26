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
    public class NotificationReadAdviserController : TableController<NotificationReadAdviser>
    {
        protected override void Initialize(HttpControllerContext controllerContext)
        {
            base.Initialize(controllerContext);
            MobileServiceContext context = new MobileServiceContext();
            DomainManager = new EntityDomainManager<NotificationReadAdviser>(context, Request);
        }

        // GET tables/NotificationReadAdviser
        public IQueryable<NotificationReadAdviser> GetAllNotificationReadAdviser()
        {
            return Query(); 
        }

        // GET tables/NotificationReadAdviser/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public SingleResult<NotificationReadAdviser> GetNotificationReadAdviser(string id)
        {
            return Lookup(id);
        }

        // PATCH tables/NotificationReadAdviser/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public Task<NotificationReadAdviser> PatchNotificationReadAdviser(string id, Delta<NotificationReadAdviser> patch)
        {
             return UpdateAsync(id, patch);
        }

        // POST tables/NotificationReadAdviser
        public async Task<IHttpActionResult> PostNotificationReadAdviser(NotificationReadAdviser item)
        {
            NotificationReadAdviser current = await InsertAsync(item);
            return CreatedAtRoute("Tables", new { id = current.Id }, current);
        }

        // DELETE tables/NotificationReadAdviser/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public Task DeleteNotificationReadAdviser(string id)
        {
             return DeleteAsync(id);
        }
    }
}
