using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using mvc.Models.data;



namespace mvc.Controllers
{
    public class HomeController : Controller
    {
        agendaEntities1 dbobj = new agendaEntities1();

        // GET: Home
        public ActionResult Index()
        {
            var Appointment = dbobj.appointments.ToList();
            return View(Appointment);

        }
        
        
        public ActionResult DeleteRdv(int id)
        {
            //var appointments = dbobj.appointments.Where(x => x.idAppointment == 15).FirstOrDefault();
            appointments a = dbobj.appointments.Find(id);
            dbobj.appointments.Remove(a);
            dbobj.SaveChanges();
            return RedirectToAction("Index");

        }

    }
}