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
    public class YearController : TableController<Year>
    {
        protected override void Initialize(HttpControllerContext controllerContext)
        {
            base.Initialize(controllerContext);
            MobileServiceContext context = new MobileServiceContext();
            DomainManager = new EntityDomainManager<Year>(context, Request);
        }

        // GET tables/Year
        public IQueryable<Year> GetAllYear()
        {
            return Query(); 
        }

        // GET tables/Year/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public SingleResult<Year> GetYear(string id)
        {
            return Lookup(id);
        }

        // PATCH tables/Year/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public Task<Year> PatchYear(string id, Delta<Year> patch)
        {
             return UpdateAsync(id, patch);
        }

        // POST tables/Year
        public async Task<IHttpActionResult> PostYear(Year item)
        {
            Year current = await InsertAsync(item);
            return CreatedAtRoute("Tables", new { id = current.Id }, current);
        }

        // DELETE tables/Year/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public Task DeleteYear(string id)
        {
             return DeleteAsync(id);
        }
    }
}
