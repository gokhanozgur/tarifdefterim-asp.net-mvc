using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TarifDefterim.Model.Option;
using TarifDefterim.Service.Option;

namespace TarifDefterim.UI.Controllers
{
    public class SubscriberController : Controller
    {

        SubscriberService _subscriberService;

        public SubscriberController()
        {
            _subscriberService = new SubscriberService();
        }

        public JsonResult AddSubscriber(string email)
        {

            Subscriber subscriber = new Subscriber();
            subscriber.Email = email;

            try
            {
                _subscriberService.Add(subscriber);
                return Json("Kayıt işlemi başarılı.", JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json("Empty", JsonRequestBehavior.AllowGet);
            }            
        }
    }
}