using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TarifDefterim.Service.Option;

namespace TarifDefterim.UI.Areas.Admin.Controllers
{
    public class CommentController : Controller
    {

        CommentService _commentService;
        MealService _mealService;

        public CommentController()
        {
            _commentService = new CommentService();
            _mealService = new MealService();
        }

        public JsonResult AddComment(string Slug,string UserComment)
        {
            return Json("",JsonRequestBehavior.AllowGet);
        }

        public JsonResult ListComment()
        {
            return Json("", JsonRequestBehavior.AllowGet);
        }
    }
}