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
    public class SchoolYearsController : ApiController
    {
        private MISDbContext db = new MISDbContext();

        // GET: api/SchoolYears
        public IQueryable<SchoolYear> GetSchoolYears()
        {
            return db.SchoolYears;
        }

        // GET: api/SchoolYears/5
        [ResponseType(typeof(SchoolYear))]
        public IHttpActionResult GetSchoolYear(int id)
        {
            SchoolYear schoolYear = db.SchoolYears.Find(id);
            if (schoolYear == null)
            {
                return NotFound();
            }

            return Ok(schoolYear);
        }

        // PUT: api/SchoolYears/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutSchoolYear(int id, SchoolYear schoolYear)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != schoolYear.id)
            {
                return BadRequest();
            }

            db.Entry(schoolYear).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SchoolYearExists(id))
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

        // POST: api/SchoolYears
        [ResponseType(typeof(SchoolYear))]
        public IHttpActionResult PostSchoolYear(SchoolYear schoolYear)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.SchoolYears.Add(schoolYear);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = schoolYear.id }, schoolYear);
        }

        // DELETE: api/SchoolYears/5
        [ResponseType(typeof(SchoolYear))]
        public IHttpActionResult DeleteSchoolYear(int id)
        {
            SchoolYear schoolYear = db.SchoolYears.Find(id);
            if (schoolYear == null)
            {
                return NotFound();
            }

            db.SchoolYears.Remove(schoolYear);
            db.SaveChanges();

            return Ok(schoolYear);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool SchoolYearExists(int id)
        {
            return db.SchoolYears.Count(e => e.id == id) > 0;
        }
    }
}