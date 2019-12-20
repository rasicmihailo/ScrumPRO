using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ScrumPRO.DTO;

namespace ScrumPRO.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";

            return View();
        }

        public ActionResult Test()
        {
            var c = new DTOCompany();
            c = c.GetById(2);
           
            return Content(c.Name);
        }
    }
}
