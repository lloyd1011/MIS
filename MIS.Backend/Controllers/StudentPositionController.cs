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
    public class StudentPositionController : TableController<StudentPosition>
    {
        protected override void Initialize(HttpControllerContext controllerContext)
        {
            base.Initialize(controllerContext);
            MobileServiceContext context = new MobileServiceContext();
            DomainManager = new EntityDomainManager<StudentPosition>(context, Request);
        }

        // GET tables/StudentPosition
        public IQueryable<StudentPosition> GetAllStudentPosition()
        {
            return Query(); 
        }

        // GET tables/StudentPosition/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public SingleResult<StudentPosition> GetStudentPosition(string id)
        {
            return Lookup(id);
        }

        // PATCH tables/StudentPosition/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public Task<StudentPosition> PatchStudentPosition(string id, Delta<StudentPosition> patch)
        {
             return UpdateAsync(id, patch);
        }

        // POST tables/StudentPosition
        public async Task<IHttpActionResult> PostStudentPosition(StudentPosition item)
        {
            StudentPosition current = await InsertAsync(item);
            return CreatedAtRoute("Tables", new { id = current.Id }, current);
        }

        // DELETE tables/StudentPosition/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public Task DeleteStudentPosition(string id)
        {
             return DeleteAsync(id);
        }
    }
}
