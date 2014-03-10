using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using BigDogShop.Model;

namespace BigDogShop.IDAL
{
    public interface IArticle
    {
        bool Add(ArticleInfo article);
        bool Delete(int id);
        bool Update(ArticleInfo article);
        ArticleInfo GetById(int id);
        DataTable GetArticleList(int father_id);
        DataTable GetArticleList();
    }
}
