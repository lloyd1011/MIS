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
    public class OrganizationTypeController : TableController<OrganizationType>
    {
        protected override void Initialize(HttpControllerContext controllerContext)
        {
            base.Initialize(controllerContext);
            MobileServiceContext context = new MobileServiceContext();
            DomainManager = new EntityDomainManager<OrganizationType>(context, Request);
        }

        // GET tables/OrganizationType
        public IQueryable<OrganizationType> GetAllOrganizationType()
        {
            return Query(); 
        }

        // GET tables/OrganizationType/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public SingleResult<OrganizationType> GetOrganizationType(string id)
        {
            return Lookup(id);
        }

        // PATCH tables/OrganizationType/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public Task<OrganizationType> PatchOrganizationType(string id, Delta<OrganizationType> patch)
        {
             return UpdateAsync(id, patch);
        }

        // POST tables/OrganizationType
        public async Task<IHttpActionResult> PostOrganizationType(OrganizationType item)
        {
            OrganizationType current = await InsertAsync(item);
            return CreatedAtRoute("Tables", new { id = current.Id }, current);
        }

        // DELETE tables/OrganizationType/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public Task DeleteOrganizationType(string id)
        {
             return DeleteAsync(id);
        }
    }
}
