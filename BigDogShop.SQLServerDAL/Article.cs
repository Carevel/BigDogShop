using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using BigDogShop.Model;
using BigDogShop.IDAL;
using BigDogShop.DBUtility;

namespace BigDogShop.SQLServerDAL
{
    public class Article:IArticle
    {
        /// <summary>
        /// 添加文章
        /// </summary>
        /// <param name="article"></param>
        /// <returns></returns>
        public bool Add(ArticleInfo article)
        {
            StringBuilder sql = new StringBuilder();
            sql.Append("insert into BigDog_Article(Title,Type_Id,Father_Id,Image_Url,Content,Description,Enabled)");
            sql.Append("values(@Title,@Type_Id,@Father_Id@Image_Url,@Content,@Description,@Enabled)");
            SqlParameter[] parms = new SqlParameter[] {
                new SqlParameter("@Title",SqlDbType.NVarChar,50),
                new SqlParameter("@Type_Id",SqlDbType.Int),
                new SqlParameter("@Father_Id",SqlDbType.Int),
                new SqlParameter("@Image_Url",SqlDbType.NVarChar,200),
                new SqlParameter("@Content",SqlDbType.NVarChar,4000),
                new SqlParameter("@Description",SqlDbType.NVarChar,200),
                new SqlParameter("@Enabled",SqlDbType.NVarChar,1)
            };
            parms[0].Value = article.Title;
            parms[1].Value = article.Type_Id;
            parms[2].Value = article.Father_Id;
            parms[3].Value = article.Image_Url;
            parms[4].Value = article.Content;
            parms[5].Value = article.Description;
            parms[6].Value = article.Enabled;
            return SQLHelper.ExecuteNonQuery(CommandType.Text, sql.ToString(), parms) > 0;
        }

        /// <summary>
        /// 根据ID删除文章
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool Delete(int id)
        {
            StringBuilder sql = new StringBuilder();
            sql.Append("delete from BigDog_Article where Id=@Id");
            SqlParameter[] parms = new SqlParameter[] { 
                new SqlParameter("@Id",SqlDbType.Int)
            };
            parms[0].Value = id;
            return SQLHelper.ExecuteNonQuery(CommandType.Text, sql.ToString(), parms) > 0;
        }

        /// <summary>
        /// 更新文章实体
        /// </summary>
        /// <param name="article"></param>
        /// <returns></returns>
        public bool Update(ArticleInfo article)
        {
            StringBuilder sql = new StringBuilder();
            sql.Append("upate BigDog_Article set Title=@Title,Father_Id=@Father_Id,Image_Url=@Image_Url,Content=@Content,Description=@Description,Enabled=@Enabled");
            sql.Append(" where Id=@Id");
            SqlParameter[] parms = new SqlParameter[] {
                new SqlParameter("@Title",SqlDbType.NVarChar,100), 
                new SqlParameter("@Father_Id",SqlDbType.Int),
                new SqlParameter("@Image_Url",SqlDbType.VarChar,200),
                new SqlParameter("@Content",SqlDbType.VarChar,200),
                new SqlParameter("@Description",SqlDbType.VarChar,200),
                new SqlParameter("@Enabled",SqlDbType.Date)
            };
            parms[0].Value = article.Title;
            parms[1].Value = article.Father_Id;
            parms[2].Value = article.Image_Url;
            parms[3].Value = article.Content;
            parms[4].Value = article.Description;
            parms[5].Value = article.Enabled;
            return SQLHelper.ExecuteNonQuery(CommandType.Text, sql.ToString(), parms) > 0;
        }

        /// <summary>
        ///根据Id获取文章实体
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ArticleInfo GetById(int id)
        {
            ArticleInfo article = new ArticleInfo();
            StringBuilder sql = new StringBuilder();
            sql.Append("select Id,Type_Id,Title,Father_Id,Content,Image_Url,Description,Enabled from BigDog_Article");
            sql.Append(" where Id=@Id");
            SqlParameter[] parms = new SqlParameter[] { 
                new SqlParameter("@Id",SqlDbType.Int)
            };
            parms[0].Value = id;
            DataTable dt = new DataTable();
            dt = SQLHelper.GetDs(sql.ToString(), parms).Tables[0];
            if (dt.Rows.Count > 0)
            {
                article.Id = Convert.ToInt32(dt.Rows[0]["Id"]);
                article.Title = dt.Rows[0]["Title"].ToString();
                article.Father_Id = Convert.ToInt32(dt.Rows[0]["Father_Id"].ToString());
                article.Image_Url = dt.Rows[0]["Image_Url"].ToString();
                article.Enabled = dt.Rows[0]["Enabled"].ToString();
                article.Content = dt.Rows[0]["Content"].ToString();
                article.Description = dt.Rows[0]["Description"].ToString();
                return article;
            }
            return null;
        }

        public DataTable GetArticleList(int father_id)
        {
            StringBuilder sql = new StringBuilder();
            sql.Append("select Id,Type_Id,Title,Father_Id,Content,Image_Url,Description,Enabled from BigDog_Article where Father_Id=@Father_Id");
            SqlParameter[] parms = new SqlParameter[] { 
                new SqlParameter("@Father_Id",SqlDbType.Int)
            };
            DataTable dt = SQLHelper.GetDs(sql.ToString(), parms).Tables[0];
            return dt;
        }
        /// <summary>
        /// 获取菜单列表数据集
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public DataTable GetArticleList()
        {
            StringBuilder sql = new StringBuilder();
            sql.Append("select Id,Type_Id,Title,Father_Id,Content,Image_Url,Description,Enabled from BigDog_Article");
            DataTable dt = SQLHelper.GetDs(sql.ToString()).Tables[0];
            return dt;
        }
    }
}
