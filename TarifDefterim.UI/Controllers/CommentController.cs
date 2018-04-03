using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TarifDefterim.Core.Enum;
using TarifDefterim.Model.Option;
using TarifDefterim.Service.Option;

namespace TarifDefterim.UI.Controllers
{
    public class CommentController : Controller
    {
        CommentService _commentService;
        MealService _mealService;
        AppUserService _appUserService;

        public CommentController()
        {
            _commentService = new CommentService();
            _mealService = new MealService();
            _appUserService = new AppUserService();
        }

        public JsonResult AddComment(string Slug, string UserComment)
        {

            Meal meal = _mealService.GetMealDetail(Slug);

            Comment comment = new Comment();
            comment.UserComment = UserComment;
            comment.MealID = meal.ID;

            AppUser user = _appUserService.FindByUserName(User.Identity.Name);
            comment.AppUserID = user.ID;


            try
            {
                _commentService.Add(comment);
                return Json("Yorumunuz eklendi.", JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json("Yorumunuz eklenemedi.", JsonRequestBehavior.AllowGet);
            }

        }

        public JsonResult GetAddedComment(string slug)
        {

            Meal meal = _mealService.GetMealDetail(slug);

            Comment comment = _commentService.GetLastOrDefault(x => x.MealID == meal.ID && x.Status == Status.Active);

            return Json(new {
                CruptedUserImage = comment.AppUser.CruptedUserImage,
                UserName = comment.AppUser.UserName,
                CreatedDate = comment.CreatedDate.ToString(),
                UserComment = comment.UserComment
            },JsonRequestBehavior.AllowGet);
        }
    }
}