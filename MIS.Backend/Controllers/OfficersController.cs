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
    public class OfficersController : ApiController
    {
        private MISDbContext db = new MISDbContext();

        // GET: api/Officers
        public IQueryable<Officer> GetOfficers()
        {
            return db.Officers;
        }

        // GET: api/Officers/5
        [ResponseType(typeof(Officer))]
        public IHttpActionResult GetOfficer(int id)
        {
            Officer officer = db.Officers.Find(id);
            if (officer == null)
            {
                return NotFound();
            }

            return Ok(officer);
        }

        // PUT: api/Officers/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutOfficer(int id, Officer officer)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != officer.id)
            {
                return BadRequest();
            }

            db.Entry(officer).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OfficerExists(id))
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

        // POST: api/Officers
        [ResponseType(typeof(Officer))]
        public IHttpActionResult PostOfficer(Officer officer)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Officers.Add(officer);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = officer.id }, officer);
        }

        // DELETE: api/Officers/5
        [ResponseType(typeof(Officer))]
        public IHttpActionResult DeleteOfficer(int id)
        {
            Officer officer = db.Officers.Find(id);
            if (officer == null)
            {
                return NotFound();
            }

            db.Officers.Remove(officer);
            db.SaveChanges();

            return Ok(officer);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool OfficerExists(int id)
        {
            return db.Officers.Count(e => e.id == id) > 0;
        }
    }
}