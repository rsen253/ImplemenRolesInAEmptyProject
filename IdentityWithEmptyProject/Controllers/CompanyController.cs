using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IdentityWithEmptyProject.Controllers
{
    [Authorize]
    public class CompanyController : Controller
    {
        // GET: Company
        public ActionResult Index()
        {
            return View();
        }
        
        [AllowAnonymous]
        public ActionResult EmployeeList()
        {
            if (User.Identity.IsAuthenticated)
            {
                return Content("Private Employee List");
            }
            return Content("Public Employee list");
        }
    }
}