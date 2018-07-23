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
    public class AdviserOrganizationsController : ApiController
    {
        private MISDbContext db = new MISDbContext();

        // GET: api/AdviserOrganizations
        public IQueryable<AdviserOrganization> GetAdviserOrganizations()
        {
            return db.AdviserOrganizations;
        }

        // GET: api/AdviserOrganizations/5
        [ResponseType(typeof(AdviserOrganization))]
        public IHttpActionResult GetAdviserOrganization(int id)
        {
            AdviserOrganization adviserOrganization = db.AdviserOrganizations.Find(id);
            if (adviserOrganization == null)
            {
                return NotFound();
            }

            return Ok(adviserOrganization);
        }

        // PUT: api/AdviserOrganizations/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutAdviserOrganization(int id, AdviserOrganization adviserOrganization)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != adviserOrganization.id)
            {
                return BadRequest();
            }

            db.Entry(adviserOrganization).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AdviserOrganizationExists(id))
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

        // POST: api/AdviserOrganizations
        [ResponseType(typeof(AdviserOrganization))]
        public IHttpActionResult PostAdviserOrganization(AdviserOrganization adviserOrganization)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.AdviserOrganizations.Add(adviserOrganization);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = adviserOrganization.id }, adviserOrganization);
        }

        // DELETE: api/AdviserOrganizations/5
        [ResponseType(typeof(AdviserOrganization))]
        public IHttpActionResult DeleteAdviserOrganization(int id)
        {
            AdviserOrganization adviserOrganization = db.AdviserOrganizations.Find(id);
            if (adviserOrganization == null)
            {
                return NotFound();
            }

            db.AdviserOrganizations.Remove(adviserOrganization);
            db.SaveChanges();

            return Ok(adviserOrganization);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool AdviserOrganizationExists(int id)
        {
            return db.AdviserOrganizations.Count(e => e.id == id) > 0;
        }
    }
}