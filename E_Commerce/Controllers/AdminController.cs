using E_Commerce.Models;
using E_Commerce.ViewModel;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace E_Commerce.Controllers
{
    [Authorize(Roles = "admin")]
    public class AdminController : Controller
    {
        // GET: Admin
        public ActionResult Registration()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Registration(Registeration userVM)
        {
            if (ModelState.IsValid == false)
                return View(userVM);
            try
            {
                //....
                ApplicationDBContext context = new ApplicationDBContext();
                UserStore<ApplicationUser> store =
                    new UserStore<ApplicationUser>(context);
                UserManager<ApplicationUser> usermanager = new UserManager<ApplicationUser>(store);
                //UserManager<ApplicationUser> usermanager =
                //  new UserManager<ApplicationUser>(store);
                //mapping 
                ApplicationUser appUser = new ApplicationUser()
                {
                    UserName = userVM.UserName,
                    PasswordHash = userVM.Password,
                    Email = userVM.Email
                };
                IdentityResult result =
                    usermanager.Create(appUser, appUser.PasswordHash);
                if (result.Succeeded)
                {
                    usermanager.AddToRole(appUser.Id, "admin");
                    //create cookie
                    IAuthenticationManager authManager =
                        HttpContext.GetOwinContext().Authentication;
                    SignInManager<ApplicationUser, string> signInManager =
                        new SignInManager<ApplicationUser, string>(usermanager, authManager);
                    signInManager.SignIn(appUser, true, true);
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("", result.Errors.FirstOrDefault());
                    return View(userVM);
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex);
                return View(userVM);
            }
        }
    }
}