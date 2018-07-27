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
    public class AdviserController : TableController<Adviser>
    {
        protected override void Initialize(HttpControllerContext controllerContext)
        {
            base.Initialize(controllerContext);
            MobileServiceContext context = new MobileServiceContext();
            DomainManager = new EntityDomainManager<Adviser>(context, Request);
        }

        // GET tables/Adviser
        public IQueryable<Adviser> GetAllAdviser()
        {
            return Query(); 
        }

        // GET tables/Adviser/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public SingleResult<Adviser> GetAdviser(string id)
        {
            return Lookup(id);
        }

        // PATCH tables/Adviser/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public Task<Adviser> PatchAdviser(string id, Delta<Adviser> patch)
        {
             return UpdateAsync(id, patch);
        }

        // POST tables/Adviser
        public async Task<IHttpActionResult> PostAdviser(Adviser item)
        {
            Adviser current = await InsertAsync(item);
            return CreatedAtRoute("Tables", new { id = current.Id }, current);
        }

        // DELETE tables/Adviser/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public Task DeleteAdviser(string id)
        {
             return DeleteAsync(id);
        }
    }
}
