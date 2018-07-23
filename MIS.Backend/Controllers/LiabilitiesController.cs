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
    public class LiabilitiesController : ApiController
    {
        private MISDbContext db = new MISDbContext();

        // GET: api/Liabilities
        public IQueryable<Liability> GetLiabilities()
        {
            return db.Liabilities;
        }

        // GET: api/Liabilities/5
        [ResponseType(typeof(Liability))]
        public IHttpActionResult GetLiability(int id)
        {
            Liability liability = db.Liabilities.Find(id);
            if (liability == null)
            {
                return NotFound();
            }

            return Ok(liability);
        }

        // PUT: api/Liabilities/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutLiability(int id, Liability liability)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != liability.id)
            {
                return BadRequest();
            }

            db.Entry(liability).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LiabilityExists(id))
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

        // POST: api/Liabilities
        [ResponseType(typeof(Liability))]
        public IHttpActionResult PostLiability(Liability liability)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Liabilities.Add(liability);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = liability.id }, liability);
        }

        // DELETE: api/Liabilities/5
        [ResponseType(typeof(Liability))]
        public IHttpActionResult DeleteLiability(int id)
        {
            Liability liability = db.Liabilities.Find(id);
            if (liability == null)
            {
                return NotFound();
            }

            db.Liabilities.Remove(liability);
            db.SaveChanges();

            return Ok(liability);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool LiabilityExists(int id)
        {
            return db.Liabilities.Count(e => e.id == id) > 0;
        }
    }
}