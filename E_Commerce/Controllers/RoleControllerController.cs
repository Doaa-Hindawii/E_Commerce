using E_Commerce.Models;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace E_Commerce.Controllers
{
    [Authorize(Roles = "admin")]
    public class RoleControllerController : Controller
    {
        // GET: RoleController
        public ActionResult NewRole()
        {
            return View();
        }
        [HttpPost]
        public ActionResult NewRole(string RoleName)
        {
            if (RoleName != null)
            {
                ApplicationDBContext context = new ApplicationDBContext();
                RoleStore<IdentityRole> store = new RoleStore<IdentityRole>(context);
                RoleManager<IdentityRole> roleManger = new RoleManager<IdentityRole>(store);
                IdentityRole role = new IdentityRole();
                role.Name = RoleName;
                IdentityResult result = roleManger.Create(role);
                if (result.Succeeded)
                {
                    ViewData["Status"] = "Add Succss";
                    return View();
                }
                else
                {
                    ViewData["Status"] = "error" + result.Errors.FirstOrDefault();
                    return View();
                }
            }
            ViewData["Status"] = "Role Name Empty";

            return View();
        }
    }
}
