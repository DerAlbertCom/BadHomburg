using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BadHomburg.Data;
using BadHomburg.Models;

namespace BadHomburg.Controllers
{
    public class BadHomburgController : Controller
    {
        //
        // GET: /BadHomburg/

        public ActionResult Index(string id, string foo)
        {
            ViewBag.Message = id;
            ViewBag.Foo = foo;
            return View();
        }

        public ActionResult List()
        {
            using (var dbContext = new BadHomburgDbContext()) {
                var personen = dbContext.Personen.ToList();
                return View(personen);
            }
        }

        public ActionResult Details(int id)
        {
            using (var dbContext = new BadHomburgDbContext()) {
                var person = dbContext.Personen.Where(p => p.Id == id).Single();
                return View(person);
            }
        }

        public ActionResult Create()
        {
            var person = new Person();
            return View(person);
        }

        [HttpPost]
        public ActionResult Create(Person person)
        {
            if (ModelState.IsValid) {
                using (var dbContext = new BadHomburgDbContext()) {
                    dbContext.Personen.Add(person);
                    dbContext.SaveChanges();
                    return RedirectToAction("Details", new {person.Id});
                }
            }
            return View(person);
        }

        public ActionResult Edit(int id)
        {
            using (var dbContext = new BadHomburgDbContext())
            {
                var person = dbContext.Personen.Where(p => p.Id == id).Single();
                return View(person);
            }
        }

        [HttpPost]
        public ActionResult Edit(int id, Person person)
        {
            if (ModelState.IsValid)
            {
                using (var dbContext = new BadHomburgDbContext()) {
                    var oldPerson = dbContext.Personen.Single(p => p.Id == id);
                    oldPerson.CopyFrom(person);
                    dbContext.SaveChanges();
                    return RedirectToAction("Details", new { id });
                }
            }
            return View(person);
        }

    }
}
