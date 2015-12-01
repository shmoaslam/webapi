using BusinessEntities;
using BusinessServices.interfaces;
using BusinessServices.services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApp.Controllers
{
    public class AccoutController : Controller
    {

        private readonly IUserServices _userServices;
        #region Public Constructor

        /// <summary>
        /// Public constructor to initialize user service instance
        /// </summary>
        public AccoutController()
        {
            _userServices = new UserServices();
        }
        #endregion

        [HttpGet]
        public ActionResult Login()
        {
            return View(new UserEntity());
        }
        [HttpPost]
        public ActionResult Login(UserEntity userData)
        {
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public ActionResult Register()
        {
            return View(new UserEntity());
        }

        [HttpPost]
        public ActionResult Register(UserEntity userData)
        {
            return RedirectToAction("Index", "Home");
        }
    }
}