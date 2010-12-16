using System;
using System.Collections.Generic;
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

        public ActionResult Details(int id=0)
        {
            using (var dbContext = new BadHomburgDbContext()) {
                var person = dbContext.Personen.Where(p => p.Id == id).Single();
                return View(person);
            }
        }

        public ActionResult List()
        {
            using (var dbContext = new BadHomburgDbContext()) {
                var personen = dbContext.Personen.ToList();
                return View(personen);
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
            return View(person);
        }
    }
}
