using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LogisticEngine.Controllers
{
    public class EngineController : Controller
    {
        // GET: Engine
        public ActionResult Dashboard()
        {
            return View();
        }
    }
}