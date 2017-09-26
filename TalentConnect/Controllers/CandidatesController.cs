using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TalentConnect.Controllers
{
    public class CandidatesController : Controller
    {
        // GET: Candidate
        public ActionResult Index()
        {
            return View();
        }
    }
}