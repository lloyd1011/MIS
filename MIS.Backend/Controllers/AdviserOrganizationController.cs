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
    public class AdviserOrganizationController : TableController<AdviserOrganization>
    {
        protected override void Initialize(HttpControllerContext controllerContext)
        {
            base.Initialize(controllerContext);
            MobileServiceContext context = new MobileServiceContext();
            DomainManager = new EntityDomainManager<AdviserOrganization>(context, Request);
        }

        // GET tables/AdviserOrganization
        public IQueryable<AdviserOrganization> GetAllAdviserOrganization()
        {
            return Query(); 
        }

        // GET tables/AdviserOrganization/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public SingleResult<AdviserOrganization> GetAdviserOrganization(string id)
        {
            return Lookup(id);
        }

        // PATCH tables/AdviserOrganization/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public Task<AdviserOrganization> PatchAdviserOrganization(string id, Delta<AdviserOrganization> patch)
        {
             return UpdateAsync(id, patch);
        }

        // POST tables/AdviserOrganization
        public async Task<IHttpActionResult> PostAdviserOrganization(AdviserOrganization item)
        {
            AdviserOrganization current = await InsertAsync(item);
            return CreatedAtRoute("Tables", new { id = current.Id }, current);
        }

        // DELETE tables/AdviserOrganization/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public Task DeleteAdviserOrganization(string id)
        {
             return DeleteAsync(id);
        }
    }
}
