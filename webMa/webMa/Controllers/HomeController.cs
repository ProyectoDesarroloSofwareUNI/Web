using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace webMa.Controllers
{
  public class HomeController : Controller
  {
    public ActionResult Login()
    {
      return View();
    }


    public ActionResult Menu()
    {
      ViewBag.Message = "Your contact page.";

      return View();
    }
    public ActionResult Menu_Administrador()
    {
      ViewBag.Message = "Your contact page.";

      return View();
    }
    
  }
}
