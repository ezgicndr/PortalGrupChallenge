using DataAccessLayer;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PortalGrupChallenge.Controllers
{
    public class HomeController : Controller
    {
        UserRepository userRepository = new UserRepository();
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(LoginViewModel model)
        {
          

            if (ModelState.IsValid)
            {
                DataAccessLayerResult result = userRepository.LoginUser(model);

                if (result.Errors.Count > 0)
                {
                    result.Errors.ForEach(x => ModelState.AddModelError("", x.Message));

                    return View();
                }
                Session["login"] = result.Result;
                return RedirectToAction("Index");
            }


            return View(model);
        }

        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(RegisterViewModel model)
        {

            if (ModelState.IsValid)
            {
                DataAccessLayerResult result = userRepository.RegisterUser(model);

                if (result.Errors.Count > 0)
                {
                    result.Errors.ForEach(x => ModelState.AddModelError("", x.Message));
                    return View();
                }
            }
            return View(model);
        }

        public ActionResult Logout()
        {
            Session.Clear();

            return RedirectToAction("Login");
        }

        public ActionResult AccessDenied()
        {
            return View();
        }
    }
}