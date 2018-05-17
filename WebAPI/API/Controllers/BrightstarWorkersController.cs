using API.Models.BrightstarDBModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace API.Controllers
{
    public class BrightstarWorkersController : ApiController
    {
        WorkerEntityContext context = new WorkerEntityContext("Type=embedded;StoresDirectory=a:\\brightstardb;StoreName=test");

        // GET: api/BrightstarWorkers
        public IEnumerable<string> Get()
        {
            List<string> workers = new List<string>();
            foreach (Worker w in context.Workers)
            {
                string s = w.IdWorker + " " + w.Name + " " + w.Surname;
                workers.Add(s);
            }
            return workers;
        }

        // GET: api/BrightstarWorkers/5
        public string Get(int id)
        {
            return context.Workers.Where(c => c.IdWorker.Equals(id)).FirstOrDefault().ToString();
        }

        // POST: api/BrightstarWorkers
        public string Post(Worker worker)
        {
            if (worker != null)
            {
                Worker w = new Worker();
                w.IdWorker = worker.IdWorker;
                w.Name = worker.Name;
                w.Surname = worker.Surname;
                w.Age = worker.Age;
                w.Payment = worker.Payment;
                w.Office = worker.Office;
                w.Pesel = worker.Pesel;
                context.Workers.Add(w);
                context.SaveChanges();
                return "OK";
            }
            else
            {
                return "Empty flag";
            }
        }

        // PUT: api/BrightstarWorkers/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/BrightstarWorkers/5
        public void Delete(int id)
        {
        }
    }
}
