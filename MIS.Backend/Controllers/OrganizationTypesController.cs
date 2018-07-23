using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using MIS.Backend.Models;

namespace MIS.Backend.Controllers
{
    public class OrganizationTypesController : ApiController
    {
        private MISDbContext db = new MISDbContext();

        // GET: api/OrganizationTypes
        public IQueryable<OrganizationType> GetOrganizationTypes()
        {
            return db.OrganizationTypes;
        }

        // GET: api/OrganizationTypes/5
        [ResponseType(typeof(OrganizationType))]
        public IHttpActionResult GetOrganizationType(int id)
        {
            OrganizationType organizationType = db.OrganizationTypes.Find(id);
            if (organizationType == null)
            {
                return NotFound();
            }

            return Ok(organizationType);
        }

        // PUT: api/OrganizationTypes/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutOrganizationType(int id, OrganizationType organizationType)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != organizationType.id)
            {
                return BadRequest();
            }

            db.Entry(organizationType).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OrganizationTypeExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/OrganizationTypes
        [ResponseType(typeof(OrganizationType))]
        public IHttpActionResult PostOrganizationType(OrganizationType organizationType)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.OrganizationTypes.Add(organizationType);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = organizationType.id }, organizationType);
        }

        // DELETE: api/OrganizationTypes/5
        [ResponseType(typeof(OrganizationType))]
        public IHttpActionResult DeleteOrganizationType(int id)
        {
            OrganizationType organizationType = db.OrganizationTypes.Find(id);
            if (organizationType == null)
            {
                return NotFound();
            }

            db.OrganizationTypes.Remove(organizationType);
            db.SaveChanges();

            return Ok(organizationType);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool OrganizationTypeExists(int id)
        {
            return db.OrganizationTypes.Count(e => e.id == id) > 0;
        }
    }
}