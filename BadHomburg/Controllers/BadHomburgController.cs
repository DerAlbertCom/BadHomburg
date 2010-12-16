using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
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
            var person = new Person();
            person.Anrede = "Herr";
            person.Vorname = "Albert";
            person.Nachname = "Weinert";
            return View(person);
        }

        public ActionResult List()
        {
            var personen = new List<Person> {
                new Person {Anrede = "Herr", Vorname = "Albert", Nachname = "Weinert"},
                new Person {Anrede = "Frau", Vorname = "Heike", Nachname = "Westphal"},
                new Person {Anrede = "Herr", Vorname = "Peer", Nachname = "Teer"},
                new Person {Anrede = "Frau", Vorname = "Claire", Nachname = "Grube"}
            };

            return View(personen);
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
