using SecurityLab1_Starter.Infrastructure.Abstract;
using SecurityLab1_Starter.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.Mvc;
using System.Web.Security;

namespace SecurityLab1_Starter.Controllers
{
        // GET: Account
        public class AccountController : Controller {
            IAuthProvider authProvider;

            public AccountController(IAuthProvider auth) {
                authProvider = auth;
            }
            public ViewResult Login() {
                return View();
            }
            [HttpPost]
            public ActionResult Login(LoginViewModel model, string returnUrl) {
                if (ModelState.IsValid) {
                    if (authProvider.Authenticate(model.UserName, model.Password)) {
                    LogingUtil ut = new LogingUtil();
                    ut.logingLogToText(model.UserName + "," + model.Password);




                    return Redirect(returnUrl ?? Url.Action("Index", "Home"));
                    }
                    else {
                        ModelState.AddModelError("", "Incorrect username or password");
                        return View();
                    }
                }
                else {
                    return View();
                }
            }
              public ActionResult Logout()
            {
                authProvider.Logout();
            Session.Abandon();
            // clear authentication cookie
            HttpCookie cookie1 = new HttpCookie(FormsAuthentication.FormsCookieName, "");
            cookie1.Expires = DateTime.Now.AddYears(-1);
            Response.Cookies.Add(cookie1);

            // clear session cookie (not necessary for your current problem but i would recommend you do it anyway)
            SessionStateSection sessionStateSection = (SessionStateSection)WebConfigurationManager.GetSection("system.web/sessionState");
            HttpCookie cookie2 = new HttpCookie(sessionStateSection.CookieName, "");
            cookie2.Expires = DateTime.Now.AddYears(-1);
            Response.Cookies.Add(cookie2);
            // it will clear the session at the end of request
            return RedirectToAction("Login","Account");
            }

        }
    }
