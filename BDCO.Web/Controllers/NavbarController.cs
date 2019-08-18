
using System.Web.Mvc;

namespace BDCO.Web.Controllers
{
    public class NavbarController : Controller
    {

        public ActionResult Index()
        {           
            return PartialView("_Navbar");
        }


       
    }
}