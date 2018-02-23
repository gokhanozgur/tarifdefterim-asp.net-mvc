using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TarifDefterim.Service.Option;

namespace TarifDefterim.UI.Areas.Admin.Controllers
{
    public class AssignedCategoryController : Controller
    {

        AssignedCategoryService _assignedCategory;

        public AssignedCategoryController()
        {
            _assignedCategory = new AssignedCategoryService();
        }

        public ActionResult Index()
        {
            return View();
        }

    }
}