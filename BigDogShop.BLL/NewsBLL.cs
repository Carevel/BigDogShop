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
        private static INews Dal = Facotry.CreateNews();

        public static bool Add(NewsInfo news)
        {
            return Dal.Add(news);
        }

        public static  bool Delete(int id)
        {
            return Dal.Delete(id);
        }

        public static  bool Update(NewsInfo news)
        {
            return Dal.Update(news);
        }

        public static NewsInfo GetById(int id)
        {
            return Dal.GetById(id);
        }

        public static DataTable GetNewsList(int father_id)
        {
            return Dal.GetNewsList(father_id);
        }

        public static DataTable GetNewsList()
        {
            return Dal.GetNewsList();
        }
    }
}
