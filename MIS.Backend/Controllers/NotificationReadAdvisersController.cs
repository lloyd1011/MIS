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
    public class NotificationReadAdvisersController : ApiController
    {
        private MISDbContext db = new MISDbContext();

        // GET: api/NotificationReadAdvisers
        public IQueryable<NotificationReadAdviser> GetNotificationReadAdvisers()
        {
            return db.NotificationReadAdvisers;
        }

        // GET: api/NotificationReadAdvisers/5
        [ResponseType(typeof(NotificationReadAdviser))]
        public IHttpActionResult GetNotificationReadAdviser(int id)
        {
            NotificationReadAdviser notificationReadAdviser = db.NotificationReadAdvisers.Find(id);
            if (notificationReadAdviser == null)
            {
                return NotFound();
            }

            return Ok(notificationReadAdviser);
        }

        // PUT: api/NotificationReadAdvisers/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutNotificationReadAdviser(int id, NotificationReadAdviser notificationReadAdviser)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != notificationReadAdviser.Id)
            {
                return BadRequest();
            }

            db.Entry(notificationReadAdviser).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!NotificationReadAdviserExists(id))
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

        // POST: api/NotificationReadAdvisers
        [ResponseType(typeof(NotificationReadAdviser))]
        public IHttpActionResult PostNotificationReadAdviser(NotificationReadAdviser notificationReadAdviser)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.NotificationReadAdvisers.Add(notificationReadAdviser);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = notificationReadAdviser.Id }, notificationReadAdviser);
        }

        // DELETE: api/NotificationReadAdvisers/5
        [ResponseType(typeof(NotificationReadAdviser))]
        public IHttpActionResult DeleteNotificationReadAdviser(int id)
        {
            NotificationReadAdviser notificationReadAdviser = db.NotificationReadAdvisers.Find(id);
            if (notificationReadAdviser == null)
            {
                return NotFound();
            }

            db.NotificationReadAdvisers.Remove(notificationReadAdviser);
            db.SaveChanges();

            return Ok(notificationReadAdviser);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool NotificationReadAdviserExists(int id)
        {
            return db.NotificationReadAdvisers.Count(e => e.Id == id) > 0;
        }
    }
}