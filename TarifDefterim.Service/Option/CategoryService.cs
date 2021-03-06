﻿using System;
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

        public bool IsExistSlugName(Guid id, string slug)
        {
            List<Category> IsExist = GetByExp(x => x.ID == id && x.Slug == slug);

            if (IsExist.Count > 0)
                return true;
            else
                return false;

        }

        public Category GetCategoryIdBySlug(string slug)
        {
            Category category = GetFirstOrDefault(x => x.Slug == slug);
            return category;
        }

    }
}
