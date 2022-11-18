using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Event_Hall_Booking_System_MVC.Models;
using System.Data.Entity;

namespace Event_Hall_Booking_System_MVC.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
       public ActionResult Index()
        {
            return View();
        }
       // [HttpPost]
        public ActionResult About()
        {
            return View();
        }
        public ActionResult Gallery()
        {
            return View();
        }
        public ActionResult Contact()
        {
            return View();
        }
        public ActionResult Services()
        {
            return View();
        }
        public ActionResult Registration()
        {
            return View();
        }
        public ActionResult Login()
        {
            return View();
        }
        public ActionResult Booking()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Registration(TblUser tblUser)
        {
            using (EventHallEntities db = new EventHallEntities())
            {
                if (ModelState.IsValid)
                {
                    db.TblUsers.Add(tblUser);
                    db.SaveChanges();
                    ViewBag["Message"] = "Registration Sucessfully";
                    ModelState.Clear();
                }
                return View(tblUser);
            }
        }
        [HttpPost]
        public ActionResult Contact(TblReview tblReview)
        {
            using (EventHallEntities db = new EventHallEntities())
            {
                if (ModelState.IsValid)
                {
                    db.TblReviews.Add(tblReview);
                    db.SaveChanges();
                    ViewBag["Message"] = "Feedback Send Sucessfully";
                    ModelState.Clear();
                }
                return View(tblReview);
            }
        }
        [HttpPost]
        public ActionResult Booking(TblBooking tblBooking)
        {
            using (EventHallEntities db = new EventHallEntities())
            {
                if (ModelState.IsValid)
                {
                    db.TblBookings.Add(tblBooking);
                    db.SaveChanges();
                    ViewBag["Message"] = "Booking Sucessfully";
                    ModelState.Clear();
                }

            }
            return View(tblBooking);
        }
        [HttpPost]
        public ActionResult Login(TblUser tblUser)
        {
            using (EventHallEntities db = new EventHallEntities())
            {
                var obj = db.TblUsers.Where(a => a.email.Equals(tblUser.email) && a.pass.Equals(tblUser.pass)).FirstOrDefault();
                if (obj != null)
                {
                    //Session["UserID"] = obj.UserId.ToString();
                    //Session["UserName"] = obj.email.ToString();
                    return RedirectToAction("Home/Booking");
                }
            }
            return View(tblUser);
        }
    }
}