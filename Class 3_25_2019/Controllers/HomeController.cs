using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PeopleDatabase;

namespace Class_3_25_2019.Controllers
{
    public class HomeController : Controller
    {
        PeopleManager mng = new PeopleManager(Properties.Settings.Default.ConStr);

        public ActionResult Index()
        {
            IEnumerable<Person> people = mng.GetPeople();
            return View(people);
        }

        public ActionResult AddPeopleView()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddPeople(List<Person> people)
        {
            people.ForEach((p) =>
            {
                mng.AddPerson(p);
            });
            return Redirect("/");
        }
    }
}