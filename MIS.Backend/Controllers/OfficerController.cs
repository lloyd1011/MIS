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
    public class OfficerController : TableController<Officer>
    {
        protected override void Initialize(HttpControllerContext controllerContext)
        {
            base.Initialize(controllerContext);
            MobileServiceContext context = new MobileServiceContext();
            DomainManager = new EntityDomainManager<Officer>(context, Request);
        }

        // GET tables/Officer
        public IQueryable<Officer> GetAllOfficer()
        {
            return Query(); 
        }

        // GET tables/Officer/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public SingleResult<Officer> GetOfficer(string id)
        {
            return Lookup(id);
        }

        // PATCH tables/Officer/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public Task<Officer> PatchOfficer(string id, Delta<Officer> patch)
        {
             return UpdateAsync(id, patch);
        }

        // POST tables/Officer
        public async Task<IHttpActionResult> PostOfficer(Officer item)
        {
            Officer current = await InsertAsync(item);
            return CreatedAtRoute("Tables", new { id = current.Id }, current);
        }

        // DELETE tables/Officer/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public Task DeleteOfficer(string id)
        {
             return DeleteAsync(id);
        }
    }
}
