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
    public class DeanController : TableController<Dean>
    {
        protected override void Initialize(HttpControllerContext controllerContext)
        {
            base.Initialize(controllerContext);
            MobileServiceContext context = new MobileServiceContext();
            DomainManager = new EntityDomainManager<Dean>(context, Request);
        }

        // GET tables/Dean
        public IQueryable<Dean> GetAllDean()
        {
            return Query(); 
        }

        // GET tables/Dean/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public SingleResult<Dean> GetDean(string id)
        {
            return Lookup(id);
        }

        // PATCH tables/Dean/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public Task<Dean> PatchDean(string id, Delta<Dean> patch)
        {
             return UpdateAsync(id, patch);
        }

        // POST tables/Dean
        public async Task<IHttpActionResult> PostDean(Dean item)
        {
            Dean current = await InsertAsync(item);
            return CreatedAtRoute("Tables", new { id = current.Id }, current);
        }

        // DELETE tables/Dean/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public Task DeleteDean(string id)
        {
             return DeleteAsync(id);
        }
    }
}
