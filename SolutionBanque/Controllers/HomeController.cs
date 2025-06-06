using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using SolutionBanque.Models;

namespace SolutionBanque.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View("Create");
        }

        [HttpPost]
        public ActionResult Index(CompteBanquaire cb)
        {
            if (ModelState.IsValid)
                return View("Details", cb); //Page qui affiche le compte créé
            else
                return View("Create", cb);
        }
    }
}
