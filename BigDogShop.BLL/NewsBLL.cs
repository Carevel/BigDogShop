using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using BigDogShop.DALFactory;
using BigDogShop.IDAL;
using BigDogShop.Model;

namespace BigDogShop.BLL
{
    public class NewsBLL
    {
        private static INews NewsDAL = Facotry.CreateNews();

        public static bool Add(NewsInfo news)
        {
            return NewsDAL.Add(news);
        }

        public static  bool Delete(int id)
        {
            return NewsDAL.Delete(id);
        }

        public static  bool Update(NewsInfo news)
        {
            return NewsDAL.Update(news);
        }

        public static NewsInfo GetById(int id)
        {
            return NewsDAL.GetById(id);
        }

        public static DataTable GetNewsList(int father_id)
        {
            return NewsDAL.GetNewsList(father_id);
        }

        public static DataTable GetNewsList()
        {
            return NewsDAL.GetNewsList();
        }
    }
}
