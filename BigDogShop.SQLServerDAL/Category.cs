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
    public class Category:ICategory
    {

        /// <summary>
        /// 添加一条数据
        /// </summary>
        /// <param name="category"></param>
        /// <returns></returns>
        public bool Add(CategoryInfo category)
        {
            StringBuilder sql = new StringBuilder();
            sql.Append("inser into BigDog_Category (Category_Name,Description,Link_Url)");
            sql.Append("values(@Category_Name,@Description,@Link_Url)");
            SqlParameter[] parms = new SqlParameter[]{
                new SqlParameter("@Category_Name",SqlDbType.NVarChar,50),
                new SqlParameter("@Description",SqlDbType.Int),
                new SqlParameter("@Link_Url",SqlDbType.NVarChar,200)
            };
            parms[0].Value = category.Category_Name;
            parms[1].Value = category.Description;
            parms[2].Value = category.Link_Url;
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
            sql.Append("delete from BigDog_Category where Id=@Id");
            SqlParameter[] parms = new SqlParameter[] {
                new SqlParameter("@Id",SqlDbType.Int)
            };
            parms[0].Value = id;
            return SQLHelper.ExecuteNonQuery(CommandType.Text, sql.ToString(), parms) > 0;
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        /// <param name="category"></param>
        /// <returns></returns>
        public bool Update(CategoryInfo category)
        {
            StringBuilder sql = new StringBuilder();
            sql.Append("update BigDog_Shop set Category_Name=@Category_Name,Description=@Description,Link_Url=@Link_Url where Id=@Id");
            SqlParameter[] parms = new SqlParameter[] { 
                new SqlParameter("@Category_Name",SqlDbType.NVarChar,50),
                new SqlParameter("@Description",SqlDbType.NVarChar,100),
                new SqlParameter("@Link_Url",SqlDbType.NVarChar,200),
                new SqlParameter("@Id",SqlDbType.Int)
            };
            parms[0].Value = category.Category_Name;
            parms[1].Value = category.Description;
            parms[2].Value = category.Link_Url;
            parms[3].Value = category.Id;
            return SQLHelper.ExecuteNonQuery(CommandType.Text, sql.ToString(), parms) > 0;
        }


        /// <summary>
        /// 根据Id获取实体
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public CategoryInfo GetById(int id)
        {
            StringBuilder sql = new StringBuilder();
            sql.Append("select Id,Category_Name,Description,Link_Url from BigDog_Category where Id=@Id");
            SqlParameter[] parms = new SqlParameter[] { 
                new SqlParameter("@Id",SqlDbType.Int)
            };
            parms[0].Value = id;
            CategoryInfo category = new CategoryInfo();
            DataTable dt = SQLHelper.GetDs(sql.ToString()).Tables[0];
            if (dt.Rows.Count > 0)
            {
                category.Id = Convert.ToInt32(dt.Rows[0]["Id"]);
                category.Category_Name = dt.Rows[0]["Category_Name"].ToString();
                category.Link_Url = dt.Rows[0]["Link_Url"].ToString();
                return category;
            }
            return null;
        }

        /// <summary>
        /// 获取数据集
        /// </summary>
        /// <returns></returns>
        public DataTable GetCategoryList()
        {
            StringBuilder sql = new StringBuilder();
            sql.Append("select Id,Type_Id,Category_Name,Link_Url,Description from BigDog_Category");
            DataTable dt = SQLHelper.GetDs(sql.ToString()).Tables[0];
            if (dt.Rows.Count > 0)
            {
                return dt;
            }
            return null;
        }

        /// <summary>
        /// 取得指定类型下的列表
        /// </summary>
        /// <param name="father_id"></param>
        /// <param name="type_id"></param>
        /// <returns></returns>
        public DataTable GetChildList(int father_id,int type_id)
        {
            StringBuilder sql = new StringBuilder();
            sql.Append("select Id,Type_Id,Category_Name,Father_Id,Category_Layer,Link_Url,Description");
            sql.Append(" Seo_Name,Seo_KeyWords,Seo_Description from BigDog_Category");
            sql.Append(" WHERE Father_Id=@Father_Id and Type_Id=@Type_Id");
            SqlParameter[] parms = new SqlParameter[] { 
                new SqlParameter("@Father_Id",SqlDbType.Int),
                new SqlParameter("@Type_Id",SqlDbType.Int)
            };
            parms[0].Value = father_id;
            parms[1].Value = type_id;
   
            return SQLHelper.GetDs(sql.ToString(),parms).Tables[0];
        }

        /// <summary>
        /// 获取数据集
        /// </summary>
        /// <returns></returns>
        public DataTable GetCategoryList(int father_id)
        {
            StringBuilder sql = new StringBuilder();
            sql.Append("select Id,Type_Id,Father_Id,Category_Name,Description,Link_Url from BigDog_Category where Father_Id=@Father_Id");
            SqlParameter[] parms = new SqlParameter[] { 
                new SqlParameter("@Father_Id",SqlDbType.Int)
            };
            parms[0].Value = father_id;
            CategoryInfo category = new CategoryInfo();
            DataTable dt = SQLHelper.GetDs(sql.ToString(),parms).Tables[0];
            if (dt.Rows.Count > 0) 
            {
                return dt;
            }
            return null;
        }
    }
}
