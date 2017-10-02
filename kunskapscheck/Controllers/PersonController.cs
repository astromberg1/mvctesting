using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace kunskapscheck.Controllers
    {
    public class PersonController : Controller
        {
        public static List<Person> adressbook = new List<Person>() {
             new Person() { id = Guid.NewGuid(), Namn = "Anders Svensson", Adress = "Sördergatan", Telefon = "112123", Uppdaterad =DateTime.Now },
             new Person() { id = Guid.NewGuid(), Namn = "Carl Persson", Adress = "Persgatan 2", Telefon = "999999" , Uppdaterad =DateTime.Now}

        };
        public ActionResult GetAll()
            {
            return PartialView("_Adressboken", adressbook);
            }
        [HttpGet]
        public ActionResult Create()
            {
            Thread.Sleep(1500);
            var model = new Person();
            model.Namn = "Anders Persson";
            model.Telefon = "12312312";
            model.Adress = "Persgatan 77";
            return PartialView(model);
            }

        [HttpPost]
        public ActionResult Create(Person model)
            {
            Thread.Sleep(1000);
            model.id = Guid.NewGuid();
            model.Uppdaterad = DateTime.Now;
            adressbook.Add(model);
            return PartialView("_Adressboken", adressbook);
            }
        [HttpPost]
        public ActionResult Delete(string id)
            {
            var postID = Guid.Parse(id);
            var postToRemove = adressbook.Find(x => x.id == postID);
            adressbook.Remove(postToRemove);
            return PartialView("_Adressboken", adressbook);
            }


        public ActionResult Edit(string id)
            {
            //Thread.Sleep(1000);
            var userID = Guid.Parse(id);
            var postToEdit = adressbook.Find(x => x.id == userID);

            return PartialView(postToEdit);
            }

        [HttpPost]
        public ActionResult Edit(Person model)
            {
            var userID = model.id;
            var personToEdit = adressbook.Find(x => x.id == userID);
            personToEdit.Namn = model.Namn;
            personToEdit.Adress = model.Adress;
            personToEdit.Telefon = model.Telefon;
            personToEdit.Uppdaterad = DateTime.Now;
            return PartialView("_Adressboken", adressbook);

            }




        [HttpGet]
        public ActionResult Getperson(Guid Id)
            {

            var model = from p in adressbook where (Id == p.id) select p;

            Person pers = model.FirstOrDefault();
            if (pers == null)
                {
                if (adressbook.Count > 0)
                    pers = adressbook[0];
                else
                    pers = null;
                }

            return PartialView("_rad", pers);
            }

        [HttpGet]
        public ActionResult Getfirstperson()
            {



            Person pers;
            
                
                if (adressbook.Count > 0)
                    pers = adressbook[0];
                else
                    pers = null;
                

            return PartialView("_rad", pers);
            }


        }
    }
