using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using mvc.Models.data;


namespace mvc.Controllers
{
    public class appointmentsController : Controller

    {
        agendaEntities1 dbobj = new agendaEntities1();

        // GET: appointments
        public ActionResult Index()
        {
            return View();
        }

        //
        [HttpGet]
        public ActionResult indexApp(int?idBroker)
        {
            ViewBag.idBroker = new SelectList(dbobj.brokers, "idBroker", "lastname");
            ViewBag.idCustomer = new SelectList(dbobj.customers, "idCustomer", "lastname");
            return View();
        }

        [HttpPost] 
        [ValidateAntiForgeryToken]
        public ActionResult indexApp(appointments appointments)
        {
            if (ModelState.IsValid)
            {
                dbobj.appointments.Add(appointments);
                dbobj.SaveChanges();
                ViewBag.Message = "";

            }
            ViewBag.idBroker = new SelectList(dbobj.brokers, "idBroker", "lastname");
            ViewBag.idCustomer = new SelectList(dbobj.customers, "idCustomer", "lastname");
            return View("indexApp");

        }



    }
}