using SecurityLab1_Starter.Infrastructure.Abstract;
using SecurityLab1_Starter.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

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
            this.ControllerContext.HttpContext.Response.Cookies.Clear();
            HttpContext.Session.Abandon(); // it will clear the session at the end of request
                return RedirectToAction("Index","Home");
            }

        }
    }
