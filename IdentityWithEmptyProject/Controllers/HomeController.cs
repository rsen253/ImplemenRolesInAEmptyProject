using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using System.Threading.Tasks;
using IdentityWithEmptyProject.Models;
using Microsoft.AspNet.Identity.Owin;

namespace IdentityWithEmptyProject.Controllers
{
    public class HomeController : BaseController
    {
        // GET: Home
        public async Task<ActionResult> Index()
        {
            var email = "rsen253@gmail.com";
            var password = "Rahul@123";
            var user = await UserManager.FindByEmailAsync(email);
            var roles = ApplicationRoleManager.Create(HttpContext.GetOwinContext());
            if (!await roles.RoleExistsAsync(SecurityRoles.Admin))
            {
                await roles.CreateAsync(new IdentityRole { Name = SecurityRoles.Admin });
            }
            if (!await roles.RoleExistsAsync(SecurityRoles.It))
            {
                await roles.CreateAsync(new IdentityRole { Name = SecurityRoles.It });
            }
            if (!await roles.RoleExistsAsync(SecurityRoles.Accounting))
            {
                await roles.CreateAsync(new IdentityRole { Name = SecurityRoles.Accounting });
            }
            if (user == null)
            {
                user = new CustomeUser
                {
                    UserName = email,
                    Email = email,
                    FirstName = "Super",
                    LastName = "Admin"
                };
                await UserManager.CreateAsync(user, password);
            }
            else
            {
                //var result = await SignInManager.PasswordSignInAsync(user.UserName,password,true,false);
                //if (result == SignInStatus.Success)
                //{
                //    return Content("Hello, " + user.FirstName + " " + user.LastName);
                //}
                //user.FirstName = "Super";
                //user.LastName = "Admin";

                //await manager.UpdateAsync(user);

                await UserManager.AddToRoleAsync(user.Id,SecurityRoles.Admin);
            }
            return Content("Hello World!!");
        }

        public async Task<ActionResult> Login()
        {
            var email = "rsen253@gmail.com";
            var user = await UserManager.FindByEmailAsync(email);
            await SignInManager.SignInAsync(user,true,true);
            return RedirectToAction("Index");
        }

        public async Task<ActionResult> Logout()
        {
            HttpContext.GetOwinContext().Authentication.SignOut();
            return RedirectToAction("Index");
        }
    }
}