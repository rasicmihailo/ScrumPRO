using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Http;
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
            c = c.GetById(1);


            return Content(c.Name);
        }
    }
}
