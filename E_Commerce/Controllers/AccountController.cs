using E_Commerce.Models;
using E_Commerce.ViewModel;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using System;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace E_Commerce.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account
        public ActionResult Registeration()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Registeration(Registeration userRegister)//Registeration
        {
            if (ModelState.IsValid == false)
                return View(userRegister);
            try
            {
                //....
                ApplicationDBContext context = new ApplicationDBContext();
                UserStore<ApplicationUser> store =
                    new UserStore<ApplicationUser>(context);
                UserManager<ApplicationUser> usermanager =
                    new UserManager<ApplicationUser>(store);
                //mapping 
                ApplicationUser appUser = new ApplicationUser()
                {
                    UserName = userRegister.UserName,
                    PasswordHash = userRegister.Password,
                    Email = userRegister.Email
                };
                IdentityResult result =
                    usermanager.Create(appUser, appUser.PasswordHash);
                if (result.Succeeded)
                {
                    //create cookie
                    return RedirectToAction("Index", "Department");
                }
                else
                {
                    ModelState.AddModelError("", result.Errors.FirstOrDefault());
                    return View(userRegister);
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex);
                return View(userRegister);
            }
        }
        ///////////////////////////////////////////////////////
        /////login
        public ActionResult Login()
        {
            return View();

        }
        [HttpPost]
        public ActionResult Login(Login userLogin)
        {

            if (ModelState.IsValid == false)
                return View(userLogin);
            ApplicationDBContext context = new ApplicationDBContext();
            UserStore<ApplicationUser> store = new UserStore<ApplicationUser>(context);
            UserManager<ApplicationUser> manger = new UserManager<ApplicationUser>(store);
            ApplicationUser AppUser = manger.Find(userLogin.UserName, userLogin.Password);
            //not found in database
            if (AppUser == null)
            {
                ModelState.AddModelError("", "UerName & Password Not Found");
                return View(userLogin);
            }
            //you have valid user
            else
            {
                //add cookie here
                IAuthenticationManager authManager =
                    HttpContext.GetOwinContext().Authentication;
                SignInManager<ApplicationUser, string> signInManager =
                    new SignInManager<ApplicationUser, string>(manger, authManager);
                signInManager.SignIn(AppUser, true, true);
                return RedirectToAction("index", "Home");
            }
        }
        ///////////////////////////////////////////////////////
        public ActionResult Logout()
        {
            IAuthenticationManager authManager =
                HttpContext.GetOwinContext().Authentication;
            authManager.SignOut(DefaultAuthenticationTypes.ApplicationCookie);
            return View("Login");
        }

    }
}

