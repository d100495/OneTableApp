using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using API.Models.MsSqlModels;

namespace API.Controllers
{
    public class WorkersController : ApiController
    {
        private WorkersDatabase db = new WorkersDatabase();

        // GET: api/Workers
        public IQueryable<Workers> GetWorkers()
        {
            return db.Workers;
        }

        // GET: api/Workers/5
        [ResponseType(typeof(Workers))]
        public async Task<IHttpActionResult> GetWorkers(int id)
        {
            Workers workers = await db.Workers.FindAsync(id);
            if (workers == null)
            {
                return NotFound();
            }

            return Ok(workers);
        }

        // PUT: api/Workers/5
        [HttpPut]
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutWorkers(int id, Workers workers)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != workers.IdWorker)
            {
                return BadRequest();
            }

            db.Entry(workers).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!WorkersExists(id))
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

        // POST: api/Workers
        [ResponseType(typeof(Workers))]
        public async Task<IHttpActionResult> PostWorkers(Workers workers)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Workers.Add(workers);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = workers.IdWorker }, workers);
        }

        // DELETE: api/Workers/5
        [ResponseType(typeof(Workers))]
        public async Task<IHttpActionResult> DeleteWorkers(int id)
        {
            Workers workers = await db.Workers.FindAsync(id);
            if (workers == null)
            {
                return NotFound();
            }

            db.Workers.Remove(workers);
            await db.SaveChangesAsync();

            return Ok(workers);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool WorkersExists(int id)
        {
            return db.Workers.Count(e => e.IdWorker == id) > 0;
        }
    }
}