using IdentityWithEmptyProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IdentityWithEmptyProject.Controllers
{
    [Authorize(Roles = "accounting,it")]
    public class AccountingController : Controller
    {
        // GET: Accounting
        public ActionResult Index()
        {
            return Content("Welcome to acounting");
        }
    }
}