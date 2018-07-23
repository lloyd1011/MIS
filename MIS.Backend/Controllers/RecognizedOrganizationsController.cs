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
    public class RecognizedOrganizationsController : ApiController
    {
        private MISDbContext db = new MISDbContext();

        // GET: api/RecognizedOrganizations
        public IQueryable<RecognizedOrganization> GetRecognizedOrganizations()
        {
            return db.RecognizedOrganizations;
        }

        // GET: api/RecognizedOrganizations/5
        [ResponseType(typeof(RecognizedOrganization))]
        public IHttpActionResult GetRecognizedOrganization(int id)
        {
            RecognizedOrganization recognizedOrganization = db.RecognizedOrganizations.Find(id);
            if (recognizedOrganization == null)
            {
                return NotFound();
            }

            return Ok(recognizedOrganization);
        }

        // PUT: api/RecognizedOrganizations/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutRecognizedOrganization(int id, RecognizedOrganization recognizedOrganization)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != recognizedOrganization.id)
            {
                return BadRequest();
            }

            db.Entry(recognizedOrganization).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RecognizedOrganizationExists(id))
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

        // POST: api/RecognizedOrganizations
        [ResponseType(typeof(RecognizedOrganization))]
        public IHttpActionResult PostRecognizedOrganization(RecognizedOrganization recognizedOrganization)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.RecognizedOrganizations.Add(recognizedOrganization);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = recognizedOrganization.id }, recognizedOrganization);
        }

        // DELETE: api/RecognizedOrganizations/5
        [ResponseType(typeof(RecognizedOrganization))]
        public IHttpActionResult DeleteRecognizedOrganization(int id)
        {
            RecognizedOrganization recognizedOrganization = db.RecognizedOrganizations.Find(id);
            if (recognizedOrganization == null)
            {
                return NotFound();
            }

            db.RecognizedOrganizations.Remove(recognizedOrganization);
            db.SaveChanges();

            return Ok(recognizedOrganization);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool RecognizedOrganizationExists(int id)
        {
            return db.RecognizedOrganizations.Count(e => e.id == id) > 0;
        }
    }
}