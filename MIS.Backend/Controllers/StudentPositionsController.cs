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
    public class StudentPositionsController : ApiController
    {
        private MISDbContext db = new MISDbContext();

        // GET: api/StudentPositions
        public IQueryable<StudentPosition> GetStudentPositions()
        {
            return db.StudentPositions;
        }

        // GET: api/StudentPositions/5
        [ResponseType(typeof(StudentPosition))]
        public IHttpActionResult GetStudentPosition(int id)
        {
            StudentPosition studentPosition = db.StudentPositions.Find(id);
            if (studentPosition == null)
            {
                return NotFound();
            }

            return Ok(studentPosition);
        }

        // PUT: api/StudentPositions/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutStudentPosition(int id, StudentPosition studentPosition)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != studentPosition.Id)
            {
                return BadRequest();
            }

            db.Entry(studentPosition).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StudentPositionExists(id))
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

        // POST: api/StudentPositions
        [ResponseType(typeof(StudentPosition))]
        public IHttpActionResult PostStudentPosition(StudentPosition studentPosition)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.StudentPositions.Add(studentPosition);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = studentPosition.Id }, studentPosition);
        }

        // DELETE: api/StudentPositions/5
        [ResponseType(typeof(StudentPosition))]
        public IHttpActionResult DeleteStudentPosition(int id)
        {
            StudentPosition studentPosition = db.StudentPositions.Find(id);
            if (studentPosition == null)
            {
                return NotFound();
            }

            db.StudentPositions.Remove(studentPosition);
            db.SaveChanges();

            return Ok(studentPosition);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool StudentPositionExists(int id)
        {
            return db.StudentPositions.Count(e => e.Id == id) > 0;
        }
    }
}