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
    public class AdviserNotificationsController : ApiController
    {
        private MISDbContext db = new MISDbContext();

        // GET: api/AdviserNotifications
        public IQueryable<AdviserNotification> GetAdviserNotifications()
        {
            return db.AdviserNotifications;
        }

        // GET: api/AdviserNotifications/5
        [ResponseType(typeof(AdviserNotification))]
        public IHttpActionResult GetAdviserNotification(int id)
        {
            AdviserNotification adviserNotification = db.AdviserNotifications.Find(id);
            if (adviserNotification == null)
            {
                return NotFound();
            }

            return Ok(adviserNotification);
        }

        // PUT: api/AdviserNotifications/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutAdviserNotification(int id, AdviserNotification adviserNotification)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != adviserNotification.id)
            {
                return BadRequest();
            }

            db.Entry(adviserNotification).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AdviserNotificationExists(id))
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

        // POST: api/AdviserNotifications
        [ResponseType(typeof(AdviserNotification))]
        public IHttpActionResult PostAdviserNotification(AdviserNotification adviserNotification)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.AdviserNotifications.Add(adviserNotification);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = adviserNotification.id }, adviserNotification);
        }

        // DELETE: api/AdviserNotifications/5
        [ResponseType(typeof(AdviserNotification))]
        public IHttpActionResult DeleteAdviserNotification(int id)
        {
            AdviserNotification adviserNotification = db.AdviserNotifications.Find(id);
            if (adviserNotification == null)
            {
                return NotFound();
            }

            db.AdviserNotifications.Remove(adviserNotification);
            db.SaveChanges();

            return Ok(adviserNotification);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool AdviserNotificationExists(int id)
        {
            return db.AdviserNotifications.Count(e => e.id == id) > 0;
        }
    }
}