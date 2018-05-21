using API.Models.BrightstarDBModels;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;

namespace API.Controllers
{
    public class BrightstarWorkersController : ApiController
    {
        WorkerEntityContext context = new WorkerEntityContext("Type=embedded;StoresDirectory=d:\\brightstardb;StoreName=test");

        // GET: api/BrightstarWorkers
        public IEnumerable<Worker> Get()
        {
            var workers = new List<Worker>();
            foreach (Worker w in context.Workers)
            {
                workers.Add(w);
            }
            return workers;
        }

        // GET: api/BrightstarWorkers/5
        public IHttpActionResult Get(int id)
        {
            var worker = context.Workers.Where(c => c.IdWorker.Equals(id)).FirstOrDefault();
            return Ok(worker);
        }

        // POST: api/BrightstarWorkers
        public IHttpActionResult Post(Worker worker)
        {
            if (worker == null || !ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var w = context.Workers.Create();
            w.IdWorker = worker.IdWorker;
            w.Name = worker.Name;
            w.Surname = worker.Surname;
            w.Age = worker.Age;
            w.Payment = worker.Payment;
            w.Office = worker.Office;
            w.Pesel = worker.Pesel;
            context.Workers.Add(w);

            context.SaveChanges();
            return CreatedAtRoute("DefaultApi", new { id = w.IdWorker }, w);
        }

        // PUT: api/BrightstarWorkers/5
        public IHttpActionResult Put(int id, Worker worker)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (id != worker.IdWorker)
            {
                return BadRequest();
            }
            var w = context.Workers.Where(d => d.IdWorker.Equals(id)).FirstOrDefault();
            w.Name = worker.Name;
            w.Surname = worker.Surname;
            w.Age = worker.Age;
            w.Payment = worker.Payment;
            w.Office = worker.Office;
            w.Pesel = worker.Pesel;
            context.AddOrUpdate(w);
            context.SaveChanges();

            return StatusCode(HttpStatusCode.NoContent);
        }

        // DELETE: api/BrightstarWorkers/5
        public IHttpActionResult Delete(int id)
        {
            var worker = context.Workers.Where(d => d.IdWorker.Equals(id)).FirstOrDefault();
            context.DeleteObject(worker);
            context.SaveChanges();
            return Ok(worker);
        }
    }
}
