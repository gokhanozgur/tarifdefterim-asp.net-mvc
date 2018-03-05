using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TarifDefterim.AuthService.Models;
using TarifDefterim.Model.Option;
using TarifDefterim.Service.Option;

namespace TarifDefterim.AuthService.Controllers
{
    public class AuthController : ApiController
    {

        AppUserService _appUserService;

        public AuthController()
        {
            _appUserService = new AppUserService();
        }

        [HttpPost]
        //[EnableCors(origins: "*", headers: "*", methods: "*")]
        public HttpResponseMessage Login(Credentials model)
        {
            var url = "";
            if (model.User == null || model.Password == null)
            {
                url = "http://localhost:57210/Home/login";
                return Request.CreateResponse(HttpStatusCode.BadRequest, new { Success = true, RedirectUrl = url });
            }
            if (_appUserService.CheckCredentialsFromWebSerice(model.User, model.Password))
            {
                AppUser p = new AppUser();
                p = _appUserService.FindByUserName(model.User);

                if (p.Role == Role.Admin || p.Role == Role.Member)
                {
                    url = "http://localhost:57210/Home/Index/" + p.ID;
                    return Request.CreateResponse(HttpStatusCode.OK, new { Success = true, RedirectUrl = url });
                }
                else
                {
                    url = "http://localhost:57210/Home/Index";
                    return Request.CreateResponse(HttpStatusCode.Unauthorized, new { Success = true, RedirectUrl = url });
                }
            }
            url = "http://localhost:57210/Home/login";
            return Request.CreateResponse(HttpStatusCode.BadRequest, new { Success = true, RedirectUrl = url });
        }

        [HttpGet]
        public HttpResponseMessage Logout()
        {
            var newUrl = "http://localhost:57210/Home/logout";
            return Request.CreateResponse(HttpStatusCode.OK, new { Success = true, RedirectUrl = newUrl });
        }

    }
}
