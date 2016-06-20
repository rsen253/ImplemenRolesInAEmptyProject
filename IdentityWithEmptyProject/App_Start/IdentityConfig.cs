using IdentityWithEmptyProject.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using Microsoft.Owin.Security;
namespace IdentityWithEmptyProject
{
    public class ApplicationUserManager : UserManager<CustomeUser>
    {
        public ApplicationUserManager(UserStore<CustomeUser> userStore) : base(userStore)
        {
            
        }

        public static ApplicationUserManager Create(IdentityFactoryOptions<ApplicationUserManager> options,IOwinContext context)
        {
            var userStore = new UserStore<CustomeUser>(context.Get<ApplicationDbContext>());
            return new ApplicationUserManager(userStore);
        }
    }

    public class ApplicationSignInManager : SignInManager<CustomeUser, string>
    {
        public ApplicationSignInManager(ApplicationUserManager userManager, IAuthenticationManager authenticationManager) : base(userManager, authenticationManager) { }

        public static ApplicationSignInManager Create(IdentityFactoryOptions<ApplicationSignInManager> options, IOwinContext context)
        {
            //var userStore = new UserStore<CustomeUser>(context.Get<ApplicationDbContext>());
            return new ApplicationSignInManager(context.Get<ApplicationUserManager>(),context.Authentication);
        }
    }

    public class ApplicationRoleManager : RoleManager<IdentityRole>
    {
        public ApplicationRoleManager(RoleStore<IdentityRole> Store)
            : base(Store)
        {
            
        }

        public static ApplicationRoleManager Create(IOwinContext context)
        {
            var store = new RoleStore<IdentityRole>(context.Get<ApplicationDbContext>());
            return new ApplicationRoleManager(store);
        }
    }

    public class IdentityConfig
    {

    }
}