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
    public class StudentLiabilitiesController : ApiController
    {
        private MISDbContext db = new MISDbContext();

        // GET: api/StudentLiabilities
        public IQueryable<StudentLiability> GetStudentLiabilities()
        {
            return db.StudentLiabilities;
        }

        // GET: api/StudentLiabilities/5
        [ResponseType(typeof(StudentLiability))]
        public IHttpActionResult GetStudentLiability(int id)
        {
            StudentLiability studentLiability = db.StudentLiabilities.Find(id);
            if (studentLiability == null)
            {
                return NotFound();
            }

            return Ok(studentLiability);
        }

        // PUT: api/StudentLiabilities/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutStudentLiability(int id, StudentLiability studentLiability)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != studentLiability.id)
            {
                return BadRequest();
            }

            db.Entry(studentLiability).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StudentLiabilityExists(id))
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

        // POST: api/StudentLiabilities
        [ResponseType(typeof(StudentLiability))]
        public IHttpActionResult PostStudentLiability(StudentLiability studentLiability)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.StudentLiabilities.Add(studentLiability);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = studentLiability.id }, studentLiability);
        }

        // DELETE: api/StudentLiabilities/5
        [ResponseType(typeof(StudentLiability))]
        public IHttpActionResult DeleteStudentLiability(int id)
        {
            StudentLiability studentLiability = db.StudentLiabilities.Find(id);
            if (studentLiability == null)
            {
                return NotFound();
            }

            db.StudentLiabilities.Remove(studentLiability);
            db.SaveChanges();

            return Ok(studentLiability);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool StudentLiabilityExists(int id)
        {
            return db.StudentLiabilities.Count(e => e.id == id) > 0;
        }
    }
}