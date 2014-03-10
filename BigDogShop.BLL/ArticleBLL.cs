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
        private static IArticle ArticleDAL = Facotry.CreateArticle();
        public bool Add(ArticleInfo article)
        {
            return ArticleDAL.Add(article);
        }
        public bool Delete(int id)
        {
            return ArticleDAL.Delete(id);
        }
        public bool Update(ArticleInfo article)
        {
            return ArticleDAL.Update(article);
        }

        public ArticleInfo GetById(int id)
        {
            return ArticleDAL.GetById(id);
        }

        public DataTable GetArticleList(int father_id)
        {
            return ArticleDAL.GetArticleList(father_id);
        }

        public DataTable GetArticleList()
        {
            return ArticleDAL.GetArticleList();
        }
    }
}
