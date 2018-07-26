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
    public class CollegeCoordinatorController : TableController<CollegeCoordinator>
    {
        protected override void Initialize(HttpControllerContext controllerContext)
        {
            base.Initialize(controllerContext);
            MobileServiceContext context = new MobileServiceContext();
            DomainManager = new EntityDomainManager<CollegeCoordinator>(context, Request);
        }

        // GET tables/CollegeCoordinator
        public IQueryable<CollegeCoordinator> GetAllCollegeCoordinator()
        {
            return Query(); 
        }

        // GET tables/CollegeCoordinator/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public SingleResult<CollegeCoordinator> GetCollegeCoordinator(string id)
        {
            return Lookup(id);
        }

        // PATCH tables/CollegeCoordinator/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public Task<CollegeCoordinator> PatchCollegeCoordinator(string id, Delta<CollegeCoordinator> patch)
        {
             return UpdateAsync(id, patch);
        }

        // POST tables/CollegeCoordinator
        public async Task<IHttpActionResult> PostCollegeCoordinator(CollegeCoordinator item)
        {
            CollegeCoordinator current = await InsertAsync(item);
            return CreatedAtRoute("Tables", new { id = current.Id }, current);
        }

        // DELETE tables/CollegeCoordinator/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public Task DeleteCollegeCoordinator(string id)
        {
             return DeleteAsync(id);
        }
    }
}
