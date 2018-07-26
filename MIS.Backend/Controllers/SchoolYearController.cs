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
    public class SchoolYearController : TableController<SchoolYear>
    {
        protected override void Initialize(HttpControllerContext controllerContext)
        {
            base.Initialize(controllerContext);
            MobileServiceContext context = new MobileServiceContext();
            DomainManager = new EntityDomainManager<SchoolYear>(context, Request);
        }

        // GET tables/SchoolYear
        public IQueryable<SchoolYear> GetAllSchoolYear()
        {
            return Query(); 
        }

        // GET tables/SchoolYear/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public SingleResult<SchoolYear> GetSchoolYear(string id)
        {
            return Lookup(id);
        }

        // PATCH tables/SchoolYear/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public Task<SchoolYear> PatchSchoolYear(string id, Delta<SchoolYear> patch)
        {
             return UpdateAsync(id, patch);
        }

        // POST tables/SchoolYear
        public async Task<IHttpActionResult> PostSchoolYear(SchoolYear item)
        {
            SchoolYear current = await InsertAsync(item);
            return CreatedAtRoute("Tables", new { id = current.Id }, current);
        }

        // DELETE tables/SchoolYear/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public Task DeleteSchoolYear(string id)
        {
             return DeleteAsync(id);
        }
    }
}
