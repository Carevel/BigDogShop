using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using BigDogShop.Model;
using BigDogShop.IDAL;
using BigDogShop.DBUtility;
using System.Data.SqlClient;

namespace BigDogShop.SQLServerDAL
{
    public class Role : IRole
    {
        public bool Add(RoleInfo model)
        {
            StringBuilder sql = new StringBuilder();
            sql.Append("insert into BigDog_Admin_Role(Id,Name,Description) values(@id,@name,@desc)");
            SqlParameter[] parms = new SqlParameter[] { 
                new SqlParameter("@id",SqlDbType.NVarChar,50),
                new SqlParameter("@name",SqlDbType.NVarChar,50),
                new SqlParameter("@desc",SqlDbType.NVarChar,200)
            };
            parms[0].Value = model.Id;
            parms[1].Value = model.Name;
            parms[2].Value = model.Description;
            try
            {
                return SQLHelper.ExecuteNonQuery(CommandType.Text, sql.ToString(), parms) > 0;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally { }

        }

        /// <summary>
        /// 支持批量删除
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public string Delete(string id)
        {
            StringBuilder sql = new StringBuilder();
            StringBuilder json = new StringBuilder();
            bool success = true ;
            string[] arr = id.Split(new char[] { ',' });
            for (var i = 0; i < arr.Length; i++)
            {
                sql.Append("delete from BigDog_Admin_Role where Id in (@Id)");
                SqlParameter[] parms = new SqlParameter[] { 
                    new SqlParameter("@Id",SqlDbType.NVarChar,50)
                };
                parms[0].Value = arr[i];
                success = SQLHelper.ExecuteNonQuery(SQLHelper.ConnString, CommandType.Text, sql.ToString(), parms) > 0;
                if (!success)
                {
                    json.Append("[");
                    json.Append("{\"success\":\"" + success + "\"}");
                    json.Append("]");
                    return json.ToString();
                }
            }

            //bool success= SQLHelper.ExecuteNonQuery(CommandType.Text, sql.ToString(), parms) > 0;
            
            json.Append("[");
            json.Append("{\"success\":\"" + success + "\"}");
            json.Append("]");
            return json.ToString();
        }

        public bool Update(RoleInfo model)
        {
            StringBuilder sql = new StringBuilder();
            sql.Append("update BigDog_Admin_Role set Name=@name,Description=@desc where Id=@id");
            SqlParameter[] parms = new SqlParameter[] { 
                new SqlParameter("@name",SqlDbType.NVarChar,50),
                new SqlParameter("@desc",SqlDbType.NVarChar,200),
                new SqlParameter("@id",SqlDbType.NVarChar,50)
            };
            parms[0].Value = model.Name;
            parms[1].Value = model.Description;
            parms[2].Value = model.Id;
            return SQLHelper.ExecuteNonQuery(CommandType.Text, sql.ToString(), parms) > 0;
        }

        //public RoleInfo GetById(int id)
        //{
        //    StringBuilder sql = new StringBuilder();
        //    sql.Append("select Id,Name,Description from BigDog_Admin_Role where Id=@id");
        //    SqlParameter[] parms = new SqlParameter[] { 
        //        new SqlParameter("@Id",SqlDbType.Int)
        //    };
        //    parms[0].Value = id;
        //    RoleInfo model = new RoleInfo();
        //    DataTable dt = SQLHelper.GetDs(sql.ToString(), parms).Tables[0];
        //    if (dt.Rows.Count > 0)
        //    {
        //        model.Id = Convert.ToInt32(dt.Rows[0]["Id"].ToString());
        //        model.Name = dt.Rows[0]["Name"].ToString();
        //        model.Description = dt.Rows[0]["Description"].ToString();
        //        return model;
        //    }
        //    return null;
        //}
        public string GetById(string id)
        {
            StringBuilder sql = new StringBuilder();
            sql.Append("select Id,Name,Description,Created_Date from BigDog_Admin_Role where Id=@id");
            SqlParameter[] parms = new SqlParameter[] { 
                new SqlParameter("@Id",SqlDbType.NVarChar,50)
            };
            parms[0].Value = id;
            RoleInfo model = new RoleInfo();
            DataTable dt = SQLHelper.GetDs(sql.ToString(), parms).Tables[0];
            StringBuilder json = new StringBuilder();
            if (dt.Rows.Count > 0)
            {
                json.Append("[");
                foreach (DataRow dr in dt.Rows)
                {
                    json.Append("{\"Id\":\"" + dr["Id"].ToString() + "\"");
                    json.Append(",\"Name\":\"" + dr["Name"].ToString() + "\"");
                    json.Append(",\"Description\":\"" + dr["Description"].ToString() + "\"");
                    json.Append(",\"Created_Date\":\"" + dr["Created_Date"].ToString() + "\"");
                    json.Append("},");
                }
                json.Remove(json.Length - 1, 1);
                json.Append("]");
                return json.ToString();
            }
            return null;
        }
        //public DataTable GetList()
        //{
        //    StringBuilder sql = new StringBuilder();
        //    sql.Append("select Id,Name,Description from BigDog_Admin_Role ");
        //    DataTable dt = SQLHelper.GetDs(sql.ToString()).Tables[0];
        //    if (dt.Rows.Count > 0)
        //    {
        //        return dt;
        //    }
        //    return null;
        //}

        public string GetList()
        {
            StringBuilder sql = new StringBuilder();
            sql.Append("select Id,Name,Description from BigDog_Admin_Role ");
            DataTable dt = SQLHelper.GetDs(sql.ToString()).Tables[0];
            StringBuilder json = new StringBuilder();
            if (dt.Rows.Count > 0)
            {
                json.Append("[");
                foreach (DataRow dr in dt.Rows)
                {
                    json.Append("{\"Id\":\"" + dr["Id"].ToString() + "\"");
                    json.Append(",\"Name\":\"" + dr["Name"].ToString() + "\"");
                    json.Append(",\"Description\":\"" + dr["Description"].ToString() + "\"");
                    json.Append(",\"Created_Date\":\"" + dr["Created_Date"].ToString() + "\"");
                    json.Append("},");
                }
                json.Remove(json.Length - 1, 1);
                json.Append("]");
                return json.ToString();
            }
            return "";
        }

        //public DataTable GetListByName(string name)
        //{
        //    StringBuilder sql = new StringBuilder();
        //    sql.Append("select Id,Name,Description from BigDog_Admin_Role ");
        //    sql.Append("where Name like '%@name' ");
        //    SqlParameter[] parms = new SqlParameter[] { 
        //        new SqlParameter("@name",SqlDbType.NVarChar,50)
        //    };
        //    parms[0].Value = name;
        //    DataTable dt = SQLHelper.GetDs(sql.ToString()).Tables[0];
        //    if (dt.Rows.Count > 0)
        //    {
        //        return dt;
        //    }
        //    return null;
        //}

        public string GetListByName(string name)
        {
            StringBuilder sql = new StringBuilder();
            sql.Append("select Id,Name,Description from BigDog_Admin_Role ");
            sql.Append("where Name like '%@name' ");
            SqlParameter[] parms = new SqlParameter[] { 
                new SqlParameter("@name",SqlDbType.NVarChar,50)
            };
            parms[0].Value = name;
            DataTable dt = SQLHelper.GetDs(sql.ToString()).Tables[0];
            StringBuilder json = new StringBuilder();
            if (dt.Rows.Count > 0)
            {
                json.Append("[");
                foreach (DataRow dr in dt.Rows)
                {
                    json.Append("{\"Id\":\"" + dr["Id"].ToString() + "\"");
                    json.Append(",\"Name\":\"" + dr["Name"].ToString() + "\"");
                    json.Append(",\"Description\":\"" + dr["Description"].ToString() + "\"");
                    json.Append(",\"Created_Date\":\"" + dr["Created_Date"].ToString() + "\"");
                    json.Append("},");
                }
                json.Remove(json.Length - 1, 1);
                json.Append("]");
                return json.ToString();
            }
            return "";
        }
    }
}
