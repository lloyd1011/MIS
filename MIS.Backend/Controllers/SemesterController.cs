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
    public class SemesterController : TableController<Semester>
    {
        protected override void Initialize(HttpControllerContext controllerContext)
        {
            base.Initialize(controllerContext);
            MobileServiceContext context = new MobileServiceContext();
            DomainManager = new EntityDomainManager<Semester>(context, Request);
        }

        // GET tables/Semester
        public IQueryable<Semester> GetAllSemester()
        {
            return Query(); 
        }

        // GET tables/Semester/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public SingleResult<Semester> GetSemester(string id)
        {
            return Lookup(id);
        }

        // PATCH tables/Semester/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public Task<Semester> PatchSemester(string id, Delta<Semester> patch)
        {
             return UpdateAsync(id, patch);
        }

        // POST tables/Semester
        public async Task<IHttpActionResult> PostSemester(Semester item)
        {
            Semester current = await InsertAsync(item);
            return CreatedAtRoute("Tables", new { id = current.Id }, current);
        }

        // DELETE tables/Semester/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public Task DeleteSemester(string id)
        {
             return DeleteAsync(id);
        }
    }
}
