using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using mvc.Models.data;

namespace mvc.Controllers
{
    public class brokersController : Controller

    {
        agendaEntities1 dbobj = new agendaEntities1();

        // GET: brokers
        public ActionResult Brokers()
        {
            return View();
        }

        //
        [HttpGet]
        public ActionResult Addbroker()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Addbroker(brokers brokers)
        {
            if (ModelState.IsValid)
            {
                dbobj.brokers.Add(brokers);
                dbobj.SaveChanges();
                ModelState.Clear();
                ViewBag.Message = "";

            }
            return View("addbroker");

        }
        //
        public ActionResult ListBrokers()

        {
            var brokers = dbobj.brokers.ToList();
            return View(brokers);
           
        }

        //
        [HttpGet]
        public ActionResult ProfilBroker(int? id)
        {
            try
            {
                return View(dbobj.brokers.Where(x => x.idBroker == id).FirstOrDefault());
            }
            catch
            {
                return View("ProfilBroker");
            }
        }


        //Modifier

         [HttpGet]

        public ActionResult Edit(int id)
        {
            try
            {
                return View(dbobj.brokers.Where(x => x.idBroker == id).FirstOrDefault());
            }
            catch
            {
                return View();
            }

        }
        [HttpPost]
        public ActionResult Edit(int id, brokers brokers)

        {
            try
            {
                dbobj.Entry(brokers).State = System.Data.Entity.EntityState.Modified;
                dbobj.SaveChanges();
                return RedirectToAction("listbrokers");

            }
            catch
            {
                return View();
            }

        }

        [HttpGet]
        public ActionResult BrokerAppointment(int?idBroker)
        {
            
            return RedirectToAction("indexApp", "appointments",new { idBroker = idBroker });

        }




    }

}