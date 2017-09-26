using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TalentConnect.Controllers
{
    public class ApplicationController : Controller
    {
        [HttpPost]
        public ActionResult Apply()
        {
            return View();
        }

    }
}
