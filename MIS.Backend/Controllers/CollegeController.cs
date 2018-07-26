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
    public class CollegeController : TableController<College>
    {
        protected override void Initialize(HttpControllerContext controllerContext)
        {
            base.Initialize(controllerContext);
            MobileServiceContext context = new MobileServiceContext();
            DomainManager = new EntityDomainManager<College>(context, Request);
        }

        // GET tables/College
        public IQueryable<College> GetAllCollege()
        {
            return Query(); 
        }

        // GET tables/College/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public SingleResult<College> GetCollege(string id)
        {
            return Lookup(id);
        }

        // PATCH tables/College/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public Task<College> PatchCollege(string id, Delta<College> patch)
        {
             return UpdateAsync(id, patch);
        }

        // POST tables/College
        public async Task<IHttpActionResult> PostCollege(College item)
        {
            College current = await InsertAsync(item);
            return CreatedAtRoute("Tables", new { id = current.Id }, current);
        }

        // DELETE tables/College/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public Task DeleteCollege(string id)
        {
             return DeleteAsync(id);
        }
    }
}
