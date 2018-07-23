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
    public class YearsController : ApiController
    {
        private MISDbContext db = new MISDbContext();

        // GET: api/Years
        public IQueryable<Year> GetYears()
        {
            return db.Years;
        }

        // GET: api/Years/5
        [ResponseType(typeof(Year))]
        public IHttpActionResult GetYear(int id)
        {
            Year year = db.Years.Find(id);
            if (year == null)
            {
                return NotFound();
            }

            return Ok(year);
        }

        // PUT: api/Years/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutYear(int id, Year year)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != year.id)
            {
                return BadRequest();
            }

            db.Entry(year).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!YearExists(id))
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

        // POST: api/Years
        [ResponseType(typeof(Year))]
        public IHttpActionResult PostYear(Year year)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Years.Add(year);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = year.id }, year);
        }

        // DELETE: api/Years/5
        [ResponseType(typeof(Year))]
        public IHttpActionResult DeleteYear(int id)
        {
            Year year = db.Years.Find(id);
            if (year == null)
            {
                return NotFound();
            }

            db.Years.Remove(year);
            db.SaveChanges();

            return Ok(year);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool YearExists(int id)
        {
            return db.Years.Count(e => e.id == id) > 0;
        }
    }
}