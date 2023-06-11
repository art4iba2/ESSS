using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication15.Models;
namespace WebApplication15.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            student model = new student();
            model.name = " ";


            return View(model);
        }

        [HttpPost]
        public ActionResult PostMethod(student model)
        {
            HttpCookie cookie = new HttpCookie("name", model.name);
            Response.Cookies.Add(cookie);

            return RedirectToAction("Show");
        }

        public ActionResult Show()
        {
            HttpCookie cookie = Request.Cookies["name"];
            string show = cookie != null ? cookie.Value : null;

            ViewBag.show = show;

            return View();
        }
    }
}