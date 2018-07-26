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
    public class RecognizedOrganizationController : TableController<RecognizedOrganization>
    {
        protected override void Initialize(HttpControllerContext controllerContext)
        {
            base.Initialize(controllerContext);
            MobileServiceContext context = new MobileServiceContext();
            DomainManager = new EntityDomainManager<RecognizedOrganization>(context, Request);
        }

        // GET tables/RecognizedOrganization
        public IQueryable<RecognizedOrganization> GetAllRecognizedOrganization()
        {
            return Query(); 
        }

        // GET tables/RecognizedOrganization/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public SingleResult<RecognizedOrganization> GetRecognizedOrganization(string id)
        {
            return Lookup(id);
        }

        // PATCH tables/RecognizedOrganization/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public Task<RecognizedOrganization> PatchRecognizedOrganization(string id, Delta<RecognizedOrganization> patch)
        {
             return UpdateAsync(id, patch);
        }

        // POST tables/RecognizedOrganization
        public async Task<IHttpActionResult> PostRecognizedOrganization(RecognizedOrganization item)
        {
            RecognizedOrganization current = await InsertAsync(item);
            return CreatedAtRoute("Tables", new { id = current.Id }, current);
        }

        // DELETE tables/RecognizedOrganization/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public Task DeleteRecognizedOrganization(string id)
        {
             return DeleteAsync(id);
        }
    }
}
