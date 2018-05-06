using API.Models.BrightstarDBModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace API.Controllers
{
    public class BrightstarWorkersController : Controller
    {
        WorkerEntityContext context = new WorkerEntityContext();

        // GET: BrightstarWorkers
        public ActionResult Index()
        {
            var workers = from d in context.Workers
                          select d;
            return View(workers.ToList());
        }

        // GET: BrightstarWorkers/Details/5
        public ActionResult Details(int id)
        {
            var worker = context.Workers.FirstOrDefault(d => d.IdWorker.Equals(id));
            return worker == null ? View("404") : View(worker);
        }

        // GET: BrightstarWorkers/Create
        public ActionResult Create()
        {
            var w = new Worker();
            return View(w);
        }

        // POST: BrightstarWorkers/Create
        [HttpPost]
        public ActionResult Create(Worker worker)
        {
            if (ModelState.IsValid)
            {
                context.Workers.Add(worker);
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }

        // GET: BrightstarWorkers/Edit/5
        public ActionResult Edit(int id)
        {
            var worker = context.Workers.FirstOrDefault(d => d.IdWorker.Equals(id));
            return worker == null ? View("404") : View(worker);
        }

        // POST: BrightstarWorkers/Edit/5
        [HttpPost]
        public ActionResult Edit(Worker worker)
        {
            if (ModelState.IsValid)
            {
                worker.Context = context;
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }

        // GET: BrightstarWorkers/Delete/5
        public ActionResult Delete(int id)
        {
            var worker = context.Workers.Where(d => d.IdWorker.Equals(id)).FirstOrDefault();
            return worker == null ? View("404") : View(worker);
        }

        // POST: BrightstarWorkers/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            var worker = context.Workers.FirstOrDefault(d => d.IdWorker.Equals(id));
            if (worker != null)
            {
                context.DeleteObject(worker);
                context.SaveChanges();
            }
            return RedirectToAction("Index");
        }
    }
}
