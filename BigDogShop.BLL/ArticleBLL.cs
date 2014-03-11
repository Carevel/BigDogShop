using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using BigDogShop.IDAL;
using BigDogShop.Model;
using BigDogShop.DALFactory;

namespace BigDogShop.BLL
{
    public class ArticleBLL
    {
        private static IArticle Dal = Facotry.CreateProduct();
        public bool Add(ArticleInfo article)
        {
            return Dal.Add(article);
        }
        public bool Delete(int id)
        {
            return Dal.Delete(id);
        }
        public bool Update(ArticleInfo article)
        {
            return Dal.Update(article);
        }

        public ArticleInfo GetById(int id)
        {
            return Dal.GetById(id);
        }

        public DataTable GetArticleList(int father_id)
        {
            return Dal.GetArticleList(father_id);
        }

        public DataTable GetArticleList()
        {
            return Dal.GetArticleList();
        }
    }
}
