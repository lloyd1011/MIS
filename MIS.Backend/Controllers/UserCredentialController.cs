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
    public class UserCredentialController : TableController<UserCredential>
    {
        protected override void Initialize(HttpControllerContext controllerContext)
        {
            base.Initialize(controllerContext);
            MobileServiceContext context = new MobileServiceContext();
            DomainManager = new EntityDomainManager<UserCredential>(context, Request);
        }

        // GET tables/UserCredential
        public IQueryable<UserCredential> GetAllUserCredential()
        {
            return Query(); 
        }

        // GET tables/UserCredential/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public SingleResult<UserCredential> GetUserCredential(string id)
        {
            return Lookup(id);
        }

        // PATCH tables/UserCredential/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public Task<UserCredential> PatchUserCredential(string id, Delta<UserCredential> patch)
        {
             return UpdateAsync(id, patch);
        }

        // POST tables/UserCredential
        public async Task<IHttpActionResult> PostUserCredential(UserCredential item)
        {
            UserCredential current = await InsertAsync(item);
            return CreatedAtRoute("Tables", new { id = current.Id }, current);
        }

        // DELETE tables/UserCredential/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public Task DeleteUserCredential(string id)
        {
             return DeleteAsync(id);
        }
    }
}
