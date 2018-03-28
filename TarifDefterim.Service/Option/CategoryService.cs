using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TarifDefterim.Model.Option;
using TarifDefterim.Service.BaseService;

namespace TarifDefterim.Service.Option
{
    public class CategoryService:MainService<Category>
    {

        public bool IsCategoryAlreadyExist(string categoryName)
        {

            return Any(x => x.CategoryName == categoryName);

        }

        public int GetTotalCategory()
        {
            return GetActive().Count();
        }

    }
}
