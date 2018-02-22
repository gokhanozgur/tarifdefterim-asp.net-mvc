using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using TarifDefterim.Model.Option;
using TarifDefterim.Service.Option;
using TarifDefterim.UI.Areas.Admin.Models;
using TarifDefterim.UI.Authorize;
using TarifDefterim.Utility;

namespace TarifDefterim.UI.Areas.Admin.Controllers
{
    public class AccountController : Controller
    {
        AppUserService _appUserService;

        public AccountController()
        {
            _appUserService = new AppUserService();
        }
        
        public ActionResult Login()
        {
            //    if (errorıd != null && errorıd == 403)
            //    {
            //        viewbag.message = "bu sayfaya erişim yetkiniz bulunmamaktadır.";
            //    }

            if (User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index","Home");
            }

            return View();
        }

        [HttpPost,ValidateAntiForgeryToken]
        public ActionResult Login(LoginVM data)
        {

            if (ModelState.IsValid)
            {

                AppUser user = _appUserService.CheckCredentials(data.User, Cryptography.ToMD5(data.Password));

                if (user != null)
                {
                    FormsAuthentication.SetAuthCookie(user.UserName, true);
                    //HttpCookie UserCookie = new HttpCookie("User",user.UserName);
                    //HttpContext.Response.Cookies.Add(UserCookie);

                    //ViewBag.UserFullName = user.Name;
                    
                    
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ViewBag.Message = "Bu kullanıcı sistemde kayıtlı değildir.";
                    return View();
                }
                
            }

            return View();
        }

        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index","Home");
        }      


    }
}