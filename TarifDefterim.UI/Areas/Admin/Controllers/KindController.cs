using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TarifDefterim.Model.Option;
using TarifDefterim.Service.Option;
using TarifDefterim.UI.Areas.Admin.Models.DTO;
using TarifDefterim.UI.Authorize;

namespace TarifDefterim.UI.Areas.Admin.Controllers
{
    [UserAuthorize(Role.Admin)]
    public class KindController : Controller
    {

        KindService _kindService;

        public KindController()
        {

            _kindService = new KindService();

        }

        public ActionResult AddKind()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddKind(Kind data)
        {
            try
            {
                _kindService.Add(data);
                TempData["Basarili"] = "Gıda türü ekleme işlemi başarılı.";
                return RedirectToAction("KindList", "Kind");
            }
            catch (Exception ex)
            {
                TempData["hata"] = "Gıda türü ekleme işlemi başarısız.";
                return RedirectToAction("AddKind", "Kind");
            }

        }

        public ActionResult KindList()
        {
            List<Kind> model = _kindService.GetAll();

            return View(model);
        }

        public ActionResult UpdateKind(Guid id)
        {

            Kind kind = _kindService.GetByID(id);

            KindDTO model = new KindDTO();


            model.ID = kind.ID;
            model.Name = kind.Name;
            model.Description = kind.Description;
            model.Status = kind.Status;

            return View(model);
        }

        [HttpPost]
        public ActionResult UpdateKind(KindDTO data)
        {

            Kind update = _kindService.GetByID(data.ID);

            update.Name = data.Name;
            update.Description = data.Description;
            update.Status = data.Status;

            try
            {

                _kindService.Update(update);
                TempData["Basarili"] = "Gıda türü güncelleme işlemi başarılı.";
                return RedirectToAction("KindList", "Kind");

            }
            catch (Exception ex)
            {
                TempData["Hata"] = "Gıda türü güncelleme işlemi başarısız.";
                return RedirectToAction("UpdateKind", "Kind", new { id = data.ID });
            }

            
        }


        public JsonResult CheckKindName(string id)
        {

            bool isExist = _kindService.IsKindAlreadyExist(id);

            return Json(isExist, JsonRequestBehavior.AllowGet);

        }

    }
}