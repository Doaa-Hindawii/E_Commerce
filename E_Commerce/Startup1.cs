using Microsoft.AspNet.Identity;
using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
using Owin;
using System;
using System.Threading.Tasks;

[assembly: OwinStartup(typeof(E_Commerce.Startup1))]

namespace E_Commerce
{
    public class Startup1
    {
        public void Configuration(IAppBuilder app)
        {
            // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=316888
            app.UseCookieAuthentication(new CookieAuthenticationOptions()
            {
                //name
                AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,

                //lifetime
                ExpireTimeSpan = TimeSpan.FromDays(1),
                //action

                LoginPath = new PathString("/Account/Login")
            });//when not found cookie
            }
    }
}
