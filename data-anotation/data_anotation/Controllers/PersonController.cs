using data_anotation.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace data_anotation.Controllers
{
    [Authorize]
    public class PersonController : Controller
    {
        [AllowAnonymous]
        public ActionResult Person()
        {
            return View();
        }

        [AllowAnonymous]
        [HttpGet]
        public JsonResult Create(Person modal)
        {
            if (!ModelState.IsValid)
                return Json(new { text = "error" }, JsonRequestBehavior.AllowGet);
            return Json(new { text = "success" }, JsonRequestBehavior.AllowGet);
        }
    }
}