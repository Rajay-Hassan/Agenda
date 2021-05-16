using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using mvc.Models.data;
using PagedList.Mvc;
using PagedList;


namespace mvc.Controllers
{
    public class customersController : Controller
    {
        agendaEntities1 dbobj = new agendaEntities1();
        // GET: customer
        public ActionResult Customers()
        {
            return View();
             
            //return View(dbobj.customers.Where(x => x.lastname.Contains(search) || search == null).ToList());
        }
        //
        [HttpGet]
        public ActionResult AddCustomer()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddCustomer(customers customers)
        {
            if (ModelState.IsValid)
            {
                dbobj.customers.Add(customers);
                dbobj.SaveChanges();
                ModelState.Clear();
                ViewBag.Message = "";

            }
            return View("addcustomer");

        }

        [HttpGet] 
        public ActionResult ListCustomers(string search, int? i)      
        {
            //List<customers> listcust = dbobj.customers.ToList();
            return View(dbobj.customers.Where(x => x.lastname.Contains(search) || search == null).ToList().OrderBy(x => x.lastname).ToPagedList(i??1,3));
        }


        [HttpGet]
        public ActionResult ProfilCustomer(int id)
        {
            try
            {
                return View(dbobj.customers.Where(x => x.idCustomer == id).FirstOrDefault());
            }
            catch
            {
                return View("ProfilCustomer");
            }
        }

        //

        [HttpGet]
        public ActionResult Edit(int id)
        {
            try
            {
                return View(dbobj.customers.Where(x => x.idCustomer == id).FirstOrDefault());
            }
            catch
            {
                return View("Edit");
            }

        }
           
        [HttpPost]
        public ActionResult Edit(int id,customers customers)

        {
            try
            {

                dbobj.Entry(customers).State = System.Data.Entity.EntityState.Modified;
                dbobj.SaveChanges();
                return RedirectToAction("ListCustomers");

            }
            catch
            {
                return View();

            } 
        }


        //
        [HttpGet]
        public ActionResult Delete (int id)
        {
            try
            {
                return View(dbobj.customers.Where(x => x.idCustomer == id).FirstOrDefault());
            }
            catch
            {
                return View("Delete");
            }

        }
        [HttpPost]
        public ActionResult Delete(int id, customers customers)

        {
            try
            {
                dbobj.Entry(customers).State = System.Data.Entity.EntityState.Deleted;
                dbobj.SaveChanges();
                return RedirectToAction("ListCustomers");
            }

            catch
            {
                return View();

            }

        }

        //
        


    }
 }