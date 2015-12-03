using BusinessEntities;
using BusinessServices.interfaces;
using BusinessServices.services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace WebApplication.Controllers
{
    public class AccountController : Controller
    {

        private readonly IUserServices _userServices;
        #region Public Constructor

        /// <summary>
        /// Public constructor to initialize user service instance
        /// </summary>
        public AccountController()
        {
            _userServices = new UserServices();
        }
        #endregion

        [HttpGet]
        public ActionResult Login()
        {
            return View(new LoginEntity());
        }
        [HttpPost]
        public ActionResult Login(LoginEntity userData, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var user = _userServices.GetAllUsers().Any(x=>x.Email == userData.Email && x.Password == userData.Password);

                    if(user)
                    {
                        FormsAuthentication.SetAuthCookie(userData.Email, false);
                        if (Url.IsLocalUrl(returnUrl) && returnUrl.Length > 1 && returnUrl.StartsWith("/") && !returnUrl.StartsWith("//") && !returnUrl.StartsWith("/\\"))
                        {
                            return Redirect(returnUrl);
                        }
                        else
                        {
                            return RedirectToAction("Index", "Home");
                        }
                    }
                    else
                    {
                        ModelState.AddModelError("", "Incorrect login cerendtial provided!");
                    }
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", "Incorrect login cerendtial provided!");
                }
            }
            return View();
        }

        public ActionResult LogOff()
        {
            FormsAuthentication.SignOut();
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
            if (ModelState.IsValid)
            {
                try
                {
                    long userId = _userServices.CreateUser(userData);
                    if(userId != 0)
                    {
                        return RedirectToAction("Index", "Home");
                    }
                    else
                    {
                        ModelState.AddModelError("", "Error occur while creating user!");
                    }

                }
                catch (Exception EX)
                {
                    ModelState.AddModelError("", "Error occur while creating user!");
                }

            }
            return View();
        }
    }
}