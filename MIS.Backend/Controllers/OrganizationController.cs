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
    public class OrganizationController : TableController<Organization>
    {
        protected override void Initialize(HttpControllerContext controllerContext)
        {
            base.Initialize(controllerContext);
            MobileServiceContext context = new MobileServiceContext();
            DomainManager = new EntityDomainManager<Organization>(context, Request);
        }

        // GET tables/Organization
        public IQueryable<Organization> GetAllOrganization()
        {
            return Query(); 
        }

        // GET tables/Organization/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public SingleResult<Organization> GetOrganization(string id)
        {
            return Lookup(id);
        }

        // PATCH tables/Organization/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public Task<Organization> PatchOrganization(string id, Delta<Organization> patch)
        {
             return UpdateAsync(id, patch);
        }

        // POST tables/Organization
        public async Task<IHttpActionResult> PostOrganization(Organization item)
        {
            Organization current = await InsertAsync(item);
            return CreatedAtRoute("Tables", new { id = current.Id }, current);
        }

        // DELETE tables/Organization/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public Task DeleteOrganization(string id)
        {
             return DeleteAsync(id);
        }
    }
}
