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
    public class DeansController : ApiController
    {
        private MISDbContext db = new MISDbContext();

        // GET: api/Deans
        public IQueryable<Dean> GetDeans()
        {
            return db.Deans;
        }

        // GET: api/Deans/5
        [ResponseType(typeof(Dean))]
        public IHttpActionResult GetDean(int id)
        {
            Dean dean = db.Deans.Find(id);
            if (dean == null)
            {
                return NotFound();
            }

            return Ok(dean);
        }

        // PUT: api/Deans/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutDean(int id, Dean dean)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != dean.id)
            {
                return BadRequest();
            }

            db.Entry(dean).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DeanExists(id))
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

        // POST: api/Deans
        [ResponseType(typeof(Dean))]
        public IHttpActionResult PostDean(Dean dean)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Deans.Add(dean);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = dean.id }, dean);
        }

        // DELETE: api/Deans/5
        [ResponseType(typeof(Dean))]
        public IHttpActionResult DeleteDean(int id)
        {
            Dean dean = db.Deans.Find(id);
            if (dean == null)
            {
                return NotFound();
            }

            db.Deans.Remove(dean);
            db.SaveChanges();

            return Ok(dean);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool DeanExists(int id)
        {
            return db.Deans.Count(e => e.id == id) > 0;
        }
    }
}