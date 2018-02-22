using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TarifDefterim.Model.Option;
using TarifDefterim.Service.Option;

namespace TarifDefterim.UI.Authorize
{
    public class UserCurrentInfo
    {

        AppUserService _appUserService = new AppUserService();

        public AppUser GetCurrentUserInfo()
        {

            //string userName = HttpContext.Current.Request.Cookies["User"].Value;
            //AppUser UserInfo = _appUserService.FindByUserName(userName);

            AppUser UserInfo = _appUserService.FindByUserName(HttpContext.Current.User.Identity.Name);


            return UserInfo;

        }

    }
}