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
    public class News : INews
    {
        /// <summary>
        /// 添加新聞
        /// </summary>
        /// <param name="news"></param>
        /// <returns></returns>
        public bool Add(NewsInfo news)
        {
            StringBuilder sql = new StringBuilder();
            sql.Append("insert into BigDog_News(Title,Type_Id,Father_Id,Image_Url,Link_Url)");
            sql.Append("values(@Title,@Type_Id,@Father_Id@Image_Url,@Link_Url)");
            SqlParameter[] parms = new SqlParameter[] {
                new SqlParameter("@Title",SqlDbType.NVarChar,50),
                new SqlParameter("@Type_Id",SqlDbType.NVarChar,50),
                new SqlParameter("@Father_Id",SqlDbType.Int),
                new SqlParameter("@Image_Url",SqlDbType.NVarChar,200),
                new SqlParameter("@Link_Url",SqlDbType.NVarChar,200)
            };
            return SQLHelper.ExecuteNonQuery(CommandType.Text, sql.ToString(), parms) > 0;
        }

        /// <summary>
        /// 根据ID删除新聞
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool Delete(int id)
        {
            StringBuilder sql = new StringBuilder();
            sql.Append("delete from BigDog_News where Id=@Id");
            SqlParameter[] parms = new SqlParameter[] { 
                new SqlParameter("@Id",SqlDbType.Int)
            };
            parms[0].Value = id;
            return SQLHelper.ExecuteNonQuery(CommandType.Text, sql.ToString(), parms) > 0;
        }

        /// <summary>
        /// 更新新聞实体
        /// </summary>
        /// <param name="news"></param>
        /// <returns></returns>
        public bool Update(NewsInfo news)
        {
            StringBuilder sql = new StringBuilder();
            sql.Append("upate BigDog_News set Title=@Title,Father_Id=@Father_Id,Image_Url=@Image_Url,Link_Url=@Link_Url,Description=@Description");
            sql.Append(" where Id=@Id");
            SqlParameter[] parms = new SqlParameter[] {
                new SqlParameter("@Title",SqlDbType.NVarChar,100), 
                new SqlParameter("@Father_Id",SqlDbType.Int),
                new SqlParameter("@Image_Url",SqlDbType.VarChar,200),
                new SqlParameter("@Link_Url",SqlDbType.Date),
                new SqlParameter("@Description",SqlDbType.Date)
            };
            parms[0].Value = news.Title;
            parms[1].Value = news.Father_Id;
            parms[2].Value = news.Link_Url;
            parms[3].Value = news.Description;
            return SQLHelper.ExecuteNonQuery(CommandType.Text, sql.ToString(), parms) > 0;
        }

        /// <summary>
        ///根据Id获取菜单实体
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public NewsInfo GetById(int id)
        {
            NewsInfo news = new NewsInfo();
            StringBuilder sql = new StringBuilder();
            sql.Append("select Id,Title,Father_Id,Image_Url,Link_Url,Description from BigDog_News");
            sql.Append(" where Id=@Id");
            SqlParameter[] parms = new SqlParameter[] { 
                new SqlParameter("@Id",SqlDbType.Int)
            };
            parms[0].Value = id;
            DataTable dt = new DataTable();
            dt = SQLHelper.GetDs(sql.ToString(), parms).Tables[0];
            if (dt.Rows.Count > 0)
            {
                news.Id = Convert.ToInt32(dt.Rows[0]["Id"]);
                news.Title = dt.Rows[0]["Title"].ToString();
                news.Father_Id = Convert.ToInt32(dt.Rows[0]["Father_Id"].ToString());
                news.Image_Url = dt.Rows[0]["Image_Url"].ToString();
                news.Link_Url = dt.Rows[0]["Link_Url"].ToString();
                news.Description = dt.Rows[0]["Description"].ToString();
                return news;
            }
            return null;
        }

        public DataTable GetNewsList(int father_id)
        {
            StringBuilder sql = new StringBuilder();
            sql.Append("select Id,Title,Type_Id,Father_Id,Description,Image_Url,Link_Url from BigDog_News where Father_Id=@Father_Id");
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
        public DataTable GetNewsList()
        {
            StringBuilder sql = new StringBuilder();
            sql.Append("select Id,Title,Type_Id,Father_Id,Description,Image_Url,Link_Url from BigDog_News");
            DataTable dt = SQLHelper.GetDs(sql.ToString()).Tables[0];
            return dt;
        }
    }
}
