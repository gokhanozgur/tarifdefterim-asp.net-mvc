using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TarifDefterim.AuthService.Models;
using TarifDefterim.Model.Option;
using TarifDefterim.Service.Option;
using TarifDefterim.Utility;

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

            model.Password = Cryptography.ToMD5(model.Password);

            if (model.User == null || model.Password == null)
            {
                url = "http://localhost:57210/Home/login";
                return Request.CreateResponse(HttpStatusCode.BadRequest, new { Success = true, RedirectUrl = url });
            }
            if (_appUserService.CheckCredentialsFromWebSerice(model.User, model.Password))
            {
                AppUser u = new AppUser();
                u = _appUserService.FindByUserName(model.User);

                if (u.Role == Role.Admin || u.Role == Role.Cook)
                {
                    url = "http://localhost:57210/Home/Index/" + u.ID;
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
