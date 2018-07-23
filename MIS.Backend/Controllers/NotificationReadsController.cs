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
    public class NotificationReadsController : ApiController
    {
        private MISDbContext db = new MISDbContext();

        // GET: api/NotificationReads
        public IQueryable<NotificationRead> GetNotificationReads()
        {
            return db.NotificationReads;
        }

        // GET: api/NotificationReads/5
        [ResponseType(typeof(NotificationRead))]
        public IHttpActionResult GetNotificationRead(int id)
        {
            NotificationRead notificationRead = db.NotificationReads.Find(id);
            if (notificationRead == null)
            {
                return NotFound();
            }

            return Ok(notificationRead);
        }

        // PUT: api/NotificationReads/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutNotificationRead(int id, NotificationRead notificationRead)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != notificationRead.id)
            {
                return BadRequest();
            }

            db.Entry(notificationRead).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!NotificationReadExists(id))
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

        // POST: api/NotificationReads
        [ResponseType(typeof(NotificationRead))]
        public IHttpActionResult PostNotificationRead(NotificationRead notificationRead)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.NotificationReads.Add(notificationRead);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = notificationRead.id }, notificationRead);
        }

        // DELETE: api/NotificationReads/5
        [ResponseType(typeof(NotificationRead))]
        public IHttpActionResult DeleteNotificationRead(int id)
        {
            NotificationRead notificationRead = db.NotificationReads.Find(id);
            if (notificationRead == null)
            {
                return NotFound();
            }

            db.NotificationReads.Remove(notificationRead);
            db.SaveChanges();

            return Ok(notificationRead);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool NotificationReadExists(int id)
        {
            return db.NotificationReads.Count(e => e.id == id) > 0;
        }
    }
}