using DataAccessLayer;
using Entities;
using PortalGrupChallenge.Filter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace PortalGrupChallenge.Controllers
{

    public class UserController : Controller
    {
        UserRepository userRepository = new UserRepository();

        [AuthAdmin]
        public ActionResult Index()
        {
            return View();
        }
        [AuthAdmin]
        public ActionResult List()
        {
            List<User> userList = userRepository.List();
            return View(userList);
        }
        [AuthAdmin]
        public ActionResult Create()
        {
            return View();
        }
        [AuthAdmin]
        [HttpPost]
        public ActionResult Create(User model)
        {
            if (ModelState.IsValid)
            {
                userRepository.Insert(model);
                return RedirectToAction("List");
            }

            return View(model);
        }

        public ActionResult Details(int id)
        {
            User user = userRepository.Find(id);
            return View(user);
        }

        public ActionResult Edit(int id)
        {
            User user = userRepository.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }

            return View(user);
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(User user)
        {
            DataAccessLayerResult result = userRepository.UpdateUser(user);

            if (ModelState.IsValid)
            {
                userRepository.Update(user);
                return RedirectToAction("List", "User");
            }
            return View(user);
        }

        public ActionResult ShowProfile()
        {
            User user = Session["login"] as User;

            DataAccessLayerResult res = userRepository.GetUserById(user.Id);
            
            return View(res.Result);
        }

        public ActionResult DeleteProfile(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = userRepository.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        [HttpPost, ActionName("DeleteProfile")]
        public ActionResult DeleteConfirmed(int id)
        {
            userRepository.Delete(id);
            return RedirectToAction("List");
        }
    }
}