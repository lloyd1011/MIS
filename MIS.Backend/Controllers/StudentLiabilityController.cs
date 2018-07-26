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
    public class StudentLiabilityController : TableController<StudentLiability>
    {
        protected override void Initialize(HttpControllerContext controllerContext)
        {
            base.Initialize(controllerContext);
            MobileServiceContext context = new MobileServiceContext();
            DomainManager = new EntityDomainManager<StudentLiability>(context, Request);
        }

        // GET tables/StudentLiability
        public IQueryable<StudentLiability> GetAllStudentLiability()
        {
            return Query(); 
        }

        // GET tables/StudentLiability/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public SingleResult<StudentLiability> GetStudentLiability(string id)
        {
            return Lookup(id);
        }

        // PATCH tables/StudentLiability/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public Task<StudentLiability> PatchStudentLiability(string id, Delta<StudentLiability> patch)
        {
             return UpdateAsync(id, patch);
        }

        // POST tables/StudentLiability
        public async Task<IHttpActionResult> PostStudentLiability(StudentLiability item)
        {
            StudentLiability current = await InsertAsync(item);
            return CreatedAtRoute("Tables", new { id = current.Id }, current);
        }

        // DELETE tables/StudentLiability/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public Task DeleteStudentLiability(string id)
        {
             return DeleteAsync(id);
        }
    }
}
