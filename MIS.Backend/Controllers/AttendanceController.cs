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
    public class AttendanceController : TableController<Attendance>
    {
        protected override void Initialize(HttpControllerContext controllerContext)
        {
            base.Initialize(controllerContext);
            MobileServiceContext context = new MobileServiceContext();
            DomainManager = new EntityDomainManager<Attendance>(context, Request);
        }

        // GET tables/Attendance
        public IQueryable<Attendance> GetAllAttendance()
        {
            return Query(); 
        }

        // GET tables/Attendance/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public SingleResult<Attendance> GetAttendance(string id)
        {
            return Lookup(id);
        }

        // PATCH tables/Attendance/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public Task<Attendance> PatchAttendance(string id, Delta<Attendance> patch)
        {
             return UpdateAsync(id, patch);
        }

        // POST tables/Attendance
        public async Task<IHttpActionResult> PostAttendance(Attendance item)
        {
            Attendance current = await InsertAsync(item);
            return CreatedAtRoute("Tables", new { id = current.Id }, current);
        }

        // DELETE tables/Attendance/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public Task DeleteAttendance(string id)
        {
             return DeleteAsync(id);
        }
    }
}
