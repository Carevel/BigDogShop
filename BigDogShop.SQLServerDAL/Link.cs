using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using BigDogShop.DBUtility;
using BigDogShop.Model;
using BigDogShop.IDAL;

namespace BigDogShop.SQLServerDAL
{
    public class Link:ILink
    {
        /// <summary>
        /// 添加一条数据
        /// </summary>
        /// <param name="link"></param>
        /// <returns></returns>
        public bool Add(LinkInfo link)
        {
            StringBuilder sql = new StringBuilder();
            sql.Append("inser into BigDog_Link (Link_Name,Description,Link_Url)");
            sql.Append("values(@Link_Name,@Description,@Link_Url)");
            SqlParameter[] parms = new SqlParameter[]{
                new SqlParameter("@Link_Name",SqlDbType.NVarChar,50),
                new SqlParameter("@Description",SqlDbType.Int),
                new SqlParameter("@Link_Url",SqlDbType.NVarChar,200)
            };
            parms[0].Value = link.Link_Name;
            parms[1].Value = link.Description;
            parms[2].Value = link.Link_Url;
            return SQLHelper.ExecuteNonQuery(CommandType.Text, sql.ToString(), parms) > 0;
        }

        /// <summary>
        /// 根据Id删除一条数据
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool Delete(int id)
        {
            StringBuilder sql = new StringBuilder();
            sql.Append("delete from BigDog_Link where Id=@Id");
            SqlParameter[] parms = new SqlParameter[] {
                new SqlParameter("@Id",SqlDbType.Int)
            };
            parms[0].Value = id;
            return SQLHelper.ExecuteNonQuery(CommandType.Text, sql.ToString(), parms) > 0;
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        /// <param name="link"></param>
        /// <returns></returns>
        public bool Update(LinkInfo link)
        {
            StringBuilder sql = new StringBuilder();
            sql.Append("update BigDog_Shop set Link_Name=@Link_Name,Description=@Description,Link_Url=@Link_Url where Id=@Id");
            SqlParameter[] parms = new SqlParameter[] { 
                new SqlParameter("@Link_Name",SqlDbType.NVarChar,50),
                new SqlParameter("@Description",SqlDbType.NVarChar,100),
                new SqlParameter("@Link_Url",SqlDbType.NVarChar,200),
                new SqlParameter("@Id",SqlDbType.Int)
            };
            parms[0].Value = link.Link_Name;
            parms[1].Value = link.Description;
            parms[2].Value = link.Link_Url;
            parms[3].Value = link.Id;
            return SQLHelper.ExecuteNonQuery(CommandType.Text, sql.ToString(), parms) > 0;
        }


        /// <summary>
        /// 根据Id获取实体
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public LinkInfo GetById(int id)
        {
            StringBuilder sql = new StringBuilder();
            sql.Append("select Id,Link_Name,Description,Link_Url from BigDog_Link where Id=@Id");
            SqlParameter[] parms = new SqlParameter[] { 
                new SqlParameter("@Id",SqlDbType.Int)
            };
            parms[0].Value = id;
            LinkInfo link = new LinkInfo();
            DataTable dt = SQLHelper.GetDs(sql.ToString(),parms).Tables[0];
            if (dt.Rows.Count > 0)
            {
                link.Id = Convert.ToInt32(dt.Rows[0]["Id"]);
                link.Link_Name = dt.Rows[0]["Link_Name"].ToString();
                link.Link_Url = dt.Rows[0]["Link_Url"].ToString();
                return link;
            }
            return null;
        }

        /// <summary>
        /// 获取数据集
        /// </summary>
        /// <returns></returns>
        public DataTable GetLinkList()
        {
            StringBuilder sql = new StringBuilder();
            sql.Append("select Id,Link_Name,Link_Url,Description from BigDog_Link");
            DataTable dt = SQLHelper.GetDs(sql.ToString()).Tables[0];
            if (dt.Rows.Count > 0)
            {
                return dt;
            }
            return null;
        }

        /// <summary>
        /// 获取子数据集
        /// </summary>
        /// <returns></returns>
        public DataTable GetLinkList(int father_id)
        {
            StringBuilder sql = new StringBuilder();
            sql.Append("select Id,Link_Name,Description,Link_Url from BigDog_Link where Father_Id=@Father_Id");
            SqlParameter[] parms = new SqlParameter[] { 
                new SqlParameter("@Father_Id",SqlDbType.Int)
            };
            parms[0].Value = father_id;          
            DataTable dt = SQLHelper.GetDs(sql.ToString(), parms).Tables[0];
            if (dt.Rows.Count > 0)
            {
                return dt;
            }
            return null;
        }
    }
}
