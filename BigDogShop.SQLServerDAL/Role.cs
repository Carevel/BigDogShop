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
    public class Role:IRole
    {
        public bool Add(RoleInfo model)
        {
            StringBuilder sql = new StringBuilder();
            sql.Append("insert into BigDog_Admin_Role(Name,Description) values(@name,@desc)");
            SqlParameter[] parms = new SqlParameter[] { 
                new SqlParameter("@name",SqlDbType.NVarChar,50),
                new SqlParameter("@desc",SqlDbType.NVarChar,200)
            };
            parms[0].Value = model.Name;
            parms[1].Value = model.Description;
            return SQLHelper.ExecuteNonQuery(CommandType.Text, sql.ToString(), parms) > 0;
        }

        public bool Delete(int id)
        {
            StringBuilder sql = new StringBuilder();
            sql.Append("delete from BigDog_Admin_Role where Id=@Id");
            SqlParameter[] parms = new SqlParameter[] { 
                new SqlParameter("@Id",SqlDbType.Int)
            };
            parms[0].Value = id;
            return SQLHelper.ExecuteNonQuery(CommandType.Text, sql.ToString(), parms) > 0;
        }

        public bool Update(RoleInfo model)
        {
            StringBuilder sql = new StringBuilder();
            sql.Append("update BigDog_Admin_Role set Name=@name,Description=@desc where Id=@id");
            SqlParameter[] parms = new SqlParameter[] { 
                new SqlParameter("@name",SqlDbType.NVarChar,50),
                new SqlParameter("@desc",SqlDbType.NVarChar,200),
                new SqlParameter("@id",SqlDbType.Int)
            };
            parms[0].Value = model.Name;
            parms[1].Value = model.Description;
            parms[2].Value = model.Id;
            return SQLHelper.ExecuteNonQuery(CommandType.Text, sql.ToString(), parms) > 0;
        }

        public RoleInfo GetById(int id)
        {
            StringBuilder sql = new StringBuilder();
            sql.Append("select Id,Name,Description from BigDog_Admin_Role where Id=@id");
            SqlParameter[] parms = new SqlParameter[] { 
                new SqlParameter("@Id",SqlDbType.Int)
            };
            parms[0].Value = id;
            RoleInfo model = new RoleInfo();
            DataTable dt = SQLHelper.GetDs(sql.ToString(), parms).Tables[0];
            if (dt.Rows.Count > 0)
            {
                model.Id = Convert.ToInt32(dt.Rows[0]["Id"].ToString());
                model.Name = dt.Rows[0]["Name"].ToString();
                model.Description = dt.Rows[0]["Description"].ToString();
                return model;
            }
            return null;
        }

        public DataTable GetList()
        {
            StringBuilder sql = new StringBuilder();
            sql.Append("select Id,Name,Description from BigDog_Admin_Role ");
            DataTable dt = SQLHelper.GetDs(sql.ToString()).Tables[0];
            if (dt.Rows.Count > 0)
            {
                return dt;
            }
            return null;
        }

        public DataTable GetListByName(string name)
        {
            StringBuilder sql = new StringBuilder();
            sql.Append("select Id,Name,Description from BigDog_Admin_Role ");
            sql.Append("where Name like '%@name' ");
            SqlParameter[] parms = new SqlParameter[] { 
                new SqlParameter("@name",SqlDbType.NVarChar,50)
            };
            parms[0].Value = name;
            DataTable dt = SQLHelper.GetDs(sql.ToString()).Tables[0];
            if (dt.Rows.Count > 0)
            {
                return dt;
            }
            return null;
        }
    }
}
