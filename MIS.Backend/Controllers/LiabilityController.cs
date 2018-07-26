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
    public class LiabilityController : TableController<Liability>
    {
        protected override void Initialize(HttpControllerContext controllerContext)
        {
            base.Initialize(controllerContext);
            MobileServiceContext context = new MobileServiceContext();
            DomainManager = new EntityDomainManager<Liability>(context, Request);
        }

        // GET tables/Liability
        public IQueryable<Liability> GetAllLiability()
        {
            return Query(); 
        }

        // GET tables/Liability/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public SingleResult<Liability> GetLiability(string id)
        {
            return Lookup(id);
        }

        // PATCH tables/Liability/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public Task<Liability> PatchLiability(string id, Delta<Liability> patch)
        {
             return UpdateAsync(id, patch);
        }

        // POST tables/Liability
        public async Task<IHttpActionResult> PostLiability(Liability item)
        {
            Liability current = await InsertAsync(item);
            return CreatedAtRoute("Tables", new { id = current.Id }, current);
        }

        // DELETE tables/Liability/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public Task DeleteLiability(string id)
        {
             return DeleteAsync(id);
        }
    }
}
