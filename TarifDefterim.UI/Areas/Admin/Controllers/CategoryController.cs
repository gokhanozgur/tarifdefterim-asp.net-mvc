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
    public class CategoryController : Controller
    {
        CategoryService _categoryService;

        public CategoryController()
        {
            _categoryService = new CategoryService();
        }

        public ActionResult AddCategory()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddCategory(Category data)
        {

            string slug = GenerateSlug.GenerateSlugURL(data.CategoryName);

            bool IsExistSlugName = _categoryService.IsExistSlugName(data.ID, slug);

            if (!IsExistSlugName)
            {
                data.Slug = slug;
            }
            else
            {
                data.Slug = slug + "-" + DateTime.Now.ToShortDateString();
            }

            try
            {

                _categoryService.Add(data);
                TempData["Basarili"] = "Kategori ekleme işlemi başarılı.";
                return RedirectToAction("CategoryList","Category");

            }
            catch (Exception ex)
            {

                TempData["Hata"] = "Kategori ekleme işlemi başarısız.";
                return RedirectToAction("AddCategory", "Category");

            }

        }

        public ActionResult CategoryList()
        {

            List<Category> model = _categoryService.GetAll();

            return View(model);

        }

        public ActionResult UpdateCategory(Guid id)
        {

            Category category = _categoryService.GetByID(id);

            CategoryDTO model = new CategoryDTO();

            model.ID = category.ID;
            model.CategoryName = category.CategoryName;
            model.Description = category.Description;
            model.Status = category.Status;

            return View(model);

        }

        [HttpPost]
        public ActionResult UpdateCategory(CategoryDTO data)
        {

            Category update = _categoryService.GetByID(data.ID);

            update.CategoryName = data.CategoryName;
            update.Description = data.Description;
            update.Status = data.Status;

            try
            {               
                _categoryService.Update(update);

                TempData["Basarili"] = "Kategori güncelleme işlemi başarılı.";
                return RedirectToAction("CategoryList","Category");

            }
            catch (Exception ex)
            {

                TempData["Hata"] = "Kategori güncelleme işlemi başarısız.";
                return RedirectToAction("UpdateCategory", "Category", new { id = data.ID });

            }

        }

        public JsonResult CheckCategoryName(string id)
        {

            bool isValid = _categoryService.IsCategoryAlreadyExist(id);

            return Json(isValid, JsonRequestBehavior.AllowGet);


        }


    }
}