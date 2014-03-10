using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using BigDogShop.Model;
using BigDogShop.DALFactory;
using BigDogShop.IDAL;

namespace BigDogShop.BLL
{
    public class CategoryBLL
    {
        private static ICategory categoryDAL = Facotry.CreateCategory();

        public static bool Add(CategoryInfo category)
        {
            return categoryDAL.Add(category);
        }

        public static bool Delete(int id)
        {
            return categoryDAL.Delete(id);
        }

        public static bool Update(CategoryInfo category)
        {
            return categoryDAL.Update(category);
        }

        public static CategoryInfo GetById(int id)
        {
            return categoryDAL.GetById(id);
        }

        /// <summary>
        /// 取得特定类型下的子列表
        /// </summary>
        /// <param name="father_id"></param>
        /// <param name="type_id"></param>
        /// <returns></returns>
        public static DataTable GetChildList(int father_id,int type_id)
        {
            return categoryDAL.GetChildList(father_id,type_id);
        }

        /// <summary>
        /// 取得所有的列表
        /// </summary>
        /// <param name="father_id"></param>
        /// <returns></returns>
        public static DataTable GetCategoryList(int father_id)
        {
            return categoryDAL.GetCategoryList(father_id);
        }
    }
}
