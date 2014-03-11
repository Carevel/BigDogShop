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
        private static ICategory Dal = Facotry.CreateCategory();

        public static bool Add(CategoryInfo category)
        {
            return Dal.Add(category);
        }

        public static bool Delete(int id)
        {
            return Dal.Delete(id);
        }

        public static bool Update(CategoryInfo category)
        {
            return Dal.Update(category);
        }

        public static CategoryInfo GetById(int id)
        {
            return Dal.GetById(id);
        }

        /// <summary>
        /// 取得特定类型下的子列表
        /// </summary>
        /// <param name="father_id"></param>
        /// <param name="type_id"></param>
        /// <returns></returns>
        public static DataTable GetChildList(int father_id,int type_id)
        {
            return Dal.GetChildList(father_id,type_id);
        }

        /// <summary>
        /// 取得所有的列表
        /// </summary>
        /// <param name="father_id"></param>
        /// <returns></returns>
        public static DataTable GetCategoryList(int father_id)
        {
            return Dal.GetList(father_id);
        }
    }
}
