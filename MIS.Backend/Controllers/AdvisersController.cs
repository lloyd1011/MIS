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
    public class AdvisersController : ApiController
    {
        private MISDbContext db = new MISDbContext();

        // GET: api/Advisers
        public IQueryable<Adviser> GetAdvisers()
        {
            return db.Advisers;
        }

        // GET: api/Advisers/5
        [ResponseType(typeof(Adviser))]
        public IHttpActionResult GetAdviser(int id)
        {
            Adviser adviser = db.Advisers.Find(id);
            if (adviser == null)
            {
                return NotFound();
            }

            return Ok(adviser);
        }

        // PUT: api/Advisers/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutAdviser(int id, Adviser adviser)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != adviser.id)
            {
                return BadRequest();
            }

            db.Entry(adviser).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AdviserExists(id))
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

        // POST: api/Advisers
        [ResponseType(typeof(Adviser))]
        public IHttpActionResult PostAdviser(Adviser adviser)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Advisers.Add(adviser);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = adviser.id }, adviser);
        }

        // DELETE: api/Advisers/5
        [ResponseType(typeof(Adviser))]
        public IHttpActionResult DeleteAdviser(int id)
        {
            Adviser adviser = db.Advisers.Find(id);
            if (adviser == null)
            {
                return NotFound();
            }

            db.Advisers.Remove(adviser);
            db.SaveChanges();

            return Ok(adviser);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool AdviserExists(int id)
        {
            return db.Advisers.Count(e => e.id == id) > 0;
        }
    }
}