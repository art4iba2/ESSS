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
            model.age = "";


            return View(model);
        }

        [HttpPost]
        public RedirectToRouteResult PostMethod(student model)
        {
            HttpCookie cookie = new HttpCookie("name", model.name);
            HttpCookie cookie1 = new HttpCookie("age", model.age);
            Response.Cookies.Add(cookie);
            Response.Cookies.Add(cookie1);
            return RedirectToRoute("Show");
        }

        public ActionResult Show()
        {
            HttpCookie cookie = Request.Cookies["name"];
            HttpCookie cookie1 = Request.Cookies["age"];
            string show = cookie != null ? cookie.Value : null;
            string show1 = cookie1 != null ? cookie1.Value : null;
            ViewBag.show = show;
            ViewBag.show1 = show1;
            return View();
        }
    }
}