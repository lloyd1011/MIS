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
    public class AdviserNotificationController : TableController<AdviserNotification>
    {
        protected override void Initialize(HttpControllerContext controllerContext)
        {
            base.Initialize(controllerContext);
            MobileServiceContext context = new MobileServiceContext();
            DomainManager = new EntityDomainManager<AdviserNotification>(context, Request);
        }

        // GET tables/AdviserNotification
        public IQueryable<AdviserNotification> GetAllAdviserNotification()
        {
            return Query(); 
        }

        // GET tables/AdviserNotification/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public SingleResult<AdviserNotification> GetAdviserNotification(string id)
        {
            return Lookup(id);
        }

        // PATCH tables/AdviserNotification/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public Task<AdviserNotification> PatchAdviserNotification(string id, Delta<AdviserNotification> patch)
        {
             return UpdateAsync(id, patch);
        }

        // POST tables/AdviserNotification
        public async Task<IHttpActionResult> PostAdviserNotification(AdviserNotification item)
        {
            AdviserNotification current = await InsertAsync(item);
            return CreatedAtRoute("Tables", new { id = current.Id }, current);
        }

        // DELETE tables/AdviserNotification/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public Task DeleteAdviserNotification(string id)
        {
             return DeleteAsync(id);
        }
    }
}
