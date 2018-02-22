using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TarifDefterim.Model.Option;
using TarifDefterim.UI.Authorize;

namespace TarifDefterim.UI.Areas.Admin.Controllers
{
    [Authorize]
    //[UserAuthorize(Role.Admin)]
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}