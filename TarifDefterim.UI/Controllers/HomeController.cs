using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using TarifDefterim.Model.Option;
using TarifDefterim.Service.Option;
using TarifDefterim.UI.Models.VM;
using TarifDefterim.Utility;

namespace TarifDefterim.UI.Controllers
{
    public class HomeController : Controller
    {

        AppUserService _appUserService;
        public HomeController()
        {
            _appUserService = new AppUserService();
        }

        public ActionResult Login()
        {
            return View();
        }

        public ActionResult Index(Guid? id)
        {
            //ID API üzerinden gönderiliyor. Eğer boş ise authentication yapmıyoruz.
            if (id != null)
            {
                AppUser user = _appUserService.GetByID((Guid)id);
                FormsAuthentication.SetAuthCookie(user.UserName, true);

                if (user.Role == Role.Admin || user.Role == Role.Cook) return Redirect("/Admin/Home/Index");
                else if (user.Role == Role.Member)
                {
                    return View();
                }
            }
            else if(User.Identity.IsAuthenticated)
            {
                AppUser user = _appUserService.FindByUserName(User.Identity.Name);

                if (user.Role == Role.Admin || user.Role == Role.Cook) return Redirect("/Admin/Home/Index");
                else if (user.Role == Role.Member) return View();
            }


            return View();

        }

        public RedirectResult Logout()
        {
            FormsAuthentication.SignOut();
            return Redirect("/Home/Index");
        }

        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(UserRegisterVM data, HttpPostedFileBase Image)
        {
            AppUser newUser = new AppUser();

            newUser.Name = data.Name.Trim().ToUpper();
            newUser.LastName = data.LastName.Trim().ToUpper();
            newUser.UserName = data.UserName.Trim();
            newUser.Email = data.Email;
            newUser.Password = Cryptography.ToMD5(data.Password);

            newUser.Role = Role.Member;

            List<string> UploadedImagePaths = new List<string>();

            UploadedImagePaths = ImageUploader.UploadSingleImage(ImageUploader.OriginalProfileImagePath, Image, 1);

            data.UserImage = UploadedImagePaths[0];

            if (data.UserImage == "0" || data.UserImage == "1" || data.UserImage == "2")
            {
                data.UserImage = ImageUploader.DefaultProfileImagePath;
                data.XSmallUserImage = ImageUploader.DefaultXSmallProfileImage;
                data.CruptedUserImage = ImageUploader.DefaulCruptedProfileImage;
            }
            else
            {
                data.XSmallUserImage = UploadedImagePaths[1];
                data.CruptedUserImage = UploadedImagePaths[2];
            }


            try
            {
                _appUserService.Add(newUser);

                ViewBag.SuccessMessage = "Kayıt işlemi başarılı.";

                FormsAuthentication.SetAuthCookie(newUser.UserName, true);

                return RedirectToAction("Index", "Home", new { newUser.ID });
            }
            catch (Exception ex)
            {
                ViewBag.Message = "Kayıt işlemi sırasında bir hata meydana geldi.";

                return RedirectToAction("Register", "Home");
            }


        }

        public JsonResult CheckUserNameFromRegisterForm(string username)
        {
            bool isValid = _appUserService.IsUserAlreadyTaken(username);

            return Json(isValid, JsonRequestBehavior.AllowGet);
        }

        public JsonResult CheckEMailFromRegisterForm(string email)
        {
            bool isValid = _appUserService.IsUserAlreadyTaken(email);

            return Json(isValid, JsonRequestBehavior.AllowGet);
        }

    }
}