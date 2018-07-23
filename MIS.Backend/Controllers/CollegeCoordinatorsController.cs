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
    public class CollegeCoordinatorsController : ApiController
    {
        private MISDbContext db = new MISDbContext();

        // GET: api/CollegeCoordinators
        public IQueryable<CollegeCoordinator> GetCollegeCoordinators()
        {
            return db.CollegeCoordinators;
        }

        // GET: api/CollegeCoordinators/5
        [ResponseType(typeof(CollegeCoordinator))]
        public IHttpActionResult GetCollegeCoordinator(int id)
        {
            CollegeCoordinator collegeCoordinator = db.CollegeCoordinators.Find(id);
            if (collegeCoordinator == null)
            {
                return NotFound();
            }

            return Ok(collegeCoordinator);
        }

        // PUT: api/CollegeCoordinators/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutCollegeCoordinator(int id, CollegeCoordinator collegeCoordinator)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != collegeCoordinator.Id)
            {
                return BadRequest();
            }

            db.Entry(collegeCoordinator).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CollegeCoordinatorExists(id))
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

        // POST: api/CollegeCoordinators
        [ResponseType(typeof(CollegeCoordinator))]
        public IHttpActionResult PostCollegeCoordinator(CollegeCoordinator collegeCoordinator)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.CollegeCoordinators.Add(collegeCoordinator);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = collegeCoordinator.Id }, collegeCoordinator);
        }

        // DELETE: api/CollegeCoordinators/5
        [ResponseType(typeof(CollegeCoordinator))]
        public IHttpActionResult DeleteCollegeCoordinator(int id)
        {
            CollegeCoordinator collegeCoordinator = db.CollegeCoordinators.Find(id);
            if (collegeCoordinator == null)
            {
                return NotFound();
            }

            db.CollegeCoordinators.Remove(collegeCoordinator);
            db.SaveChanges();

            return Ok(collegeCoordinator);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CollegeCoordinatorExists(int id)
        {
            return db.CollegeCoordinators.Count(e => e.Id == id) > 0;
        }
    }
}