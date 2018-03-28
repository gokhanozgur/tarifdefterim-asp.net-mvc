using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TarifDefterim.Core.Enum;
using TarifDefterim.Model.Option;
using TarifDefterim.Service.BaseService;

namespace TarifDefterim.Service.Option
{
    public class AppUserService:MainService<AppUser>
    {

        public AppUser CheckCredentials(string user, string password)
        {
            return GetFirstOrDefault(x => (x.UserName == user || x.Email == user) && (x.Password == password && x.Status != Status.Deleted));
        }

        public bool CheckCredentialsFromWebSerice(string user, string password)
        {
            return Any(x => (x.UserName == user || x.Email == user) && (x.Password == password && x.Status != Status.Deleted));
        }

        public bool IsUserAlreadyTaken(string user)
        {
            return Any(x => x.UserName == user || x.Email == user);
        }

        public AppUser FindByUserName(string userName)
        {
            return GetFirstOrDefault(x => x.UserName == userName);
        }

        public AppUser FindByUserNameOrEmail(string user)
        {
            return GetFirstOrDefault(x => (x.UserName == user || x.Email == user) && x.Status != Status.Deleted);
        }

        public AppUser FindByEmail(string email)
        {
            return GetFirstOrDefault(x => x.Email == email);
        }

        public int GetTotalAppUser()
        {
            return GetActive().Count;
        }

        public AppUser TakeMealCreatetorFullName(string username)
        {

            return GetFirstOrDefault(x => x.UserName == username);

        }

    }
}
