using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TarifDefterim.Model.Option;
using TarifDefterim.Service.Option;
using TarifDefterim.UI.Areas.Admin.Models.DTO;
using TarifDefterim.UI.Authorize;
using TarifDefterim.Utility;

namespace TarifDefterim.UI.Areas.Admin.Controllers
{

    [UserAuthorize(Role.Admin)]
    public class AppUserController : Controller
    {
        AppUserService _appUserService;

        public AppUserController()
        {
            _appUserService = new AppUserService();
        }        

        public ActionResult AddUser()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddUser(AppUser data,HttpPostedFileBase Image)
        {
            data.Password = Cryptography.ToMD5(data.Password);
            data.Name = data.Name.ToUpper().Trim();
            data.LastName = data.LastName.ToUpper().Trim();
            data.UserName = data.UserName.ToLower().Trim();
            data.Email = data.Email;                   

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
                _appUserService.Add(data);
                TempData["Basarili"] = "Kullanıcı sisteme eklendi.";
                return RedirectToAction("AppUserList", "AppUser");
            }
            catch (Exception ex)
            {
                TempData["Hata"] = "Kullanıcı ekleme esnasında bir hata oluştu.";
                return RedirectToAction("AddUser", "AppUser");
            }

            
        }

        public ActionResult AppUserList()
        {

            List<AppUser> model = _appUserService.GetAll();

            return View(model);

        }
        
        public ActionResult UpdateUser(Guid id)
        {

            AppUser user = _appUserService.GetByID(id);

            AppUserDTO model = new AppUserDTO();

            model.ID = user.ID;
            model.Name = user.Name;
            model.LastName = user.LastName;
            model.UserName = user.UserName;
            model.Email = user.Email;
            model.Address = user.Address;
            model.PhoneNumber = user.PhoneNumber;
            model.Birthdate = user.Birthdate;
            model.UserImage = user.UserImage;
            model.XSmallUserImage = user.XSmallUserImage;
            model.CruptedUserImage = user.CruptedUserImage;
            model.Role = user.Role;
            model.Status = user.Status;


            return View(model);
            
        }

        [HttpPost]
        public ActionResult UpdateUser(AppUserDTO data,HttpPostedFileBase Image)
        {

            List<string> UploadedImagePaths = new List<string>();

            UploadedImagePaths = ImageUploader.UploadSingleImage(ImageUploader.OriginalProfileImagePath, Image, 1);            
            
            data.UserImage = UploadedImagePaths[0];


            AppUser update = _appUserService.GetByID(data.ID);

            if (data.UserImage == "0" || data.UserImage == "1" || data.UserImage == "2")
            {

                if (update.UserImage == null || update.UserImage == ImageUploader.DefaultProfileImagePath)
                {
                    update.UserImage = ImageUploader.DefaultProfileImagePath;
                    update.XSmallUserImage = ImageUploader.DefaultXSmallProfileImage;
                    update.CruptedUserImage = ImageUploader.DefaulCruptedProfileImage;
                }
                else
                {
                    update.UserImage = update.UserImage;
                    update.XSmallUserImage = update.XSmallUserImage;
                    update.CruptedUserImage = update.CruptedUserImage;
                }

            }
            else
            {
                update.UserImage = UploadedImagePaths[0];
                update.XSmallUserImage = UploadedImagePaths[1];
                update.CruptedUserImage = UploadedImagePaths[2];
            }

            update.Name = data.Name.ToUpper().Trim();
            update.LastName = data.LastName.ToUpper().Trim();
            update.UserName = data.UserName.ToLower().Trim();
            update.Email = data.Email;
            update.Address = data.Address;
            update.PhoneNumber = data.PhoneNumber;
            update.Birthdate = data.Birthdate;
            update.Role = data.Role;
            update.Status = data.Status;

            try
            {
                _appUserService.Update(update);
                TempData["Basarili"] = "Kullanıcı güncellendi.";
                return RedirectToAction("AppUserList", "AppUser", new { id = update.ID });
            }
            catch (Exception ex)
            {
                TempData["Hata"] = "Kullanıcı güncelleme esnasında bir hata oluştu. - " + ex.Message;
                return RedirectToAction("UpdateUser", "AppUser", new { id = update.ID });

            }


        }

        public AppUser UserInfo()
        {

            UserCurrentInfo userInfo = new UserCurrentInfo();

            AppUser user = userInfo.GetCurrentUserInfo();

            return user;

        }
        
        public JsonResult CheckUserName(string id)
        {

            bool isValid = _appUserService.IsUserAlreadyTaken(id);

            return Json(isValid, JsonRequestBehavior.AllowGet);


        }

    }
}