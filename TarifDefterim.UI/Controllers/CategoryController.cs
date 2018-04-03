using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TarifDefterim.Model.Option;
using TarifDefterim.Service.Option;

namespace TarifDefterim.UI.Controllers
{
    public class CategoryController : Controller
    {

        CategoryService _categoryService;

        public CategoryController()
        {
            _categoryService = new CategoryService();
        }

        [ChildActionOnly]
        public ActionResult GetActiveCategory()
        {

            List<Category> categoryList = _categoryService.GetActive();

            return PartialView("_version_1_Menu_Category_List", categoryList);

        }
        

    }
}