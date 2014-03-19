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
            return SQLHelper.ExecuteNonQuery(CommandType.Text, sql.ToString(), parms) > 0;
        }

        /// <summary>
        /// 支持批量删除
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool Delete(string ids)
        {
            bool result = true;
            StringBuilder sql = new StringBuilder();
            SqlConnection conn = new SqlConnection(SQLHelper.ConnString);
            conn.Open();
            SqlTransaction trans = conn.BeginTransaction();
            string[] idArr = ids.Split(new char[] { ',' });
            try
            {
                for (int i = 0; i < idArr.Length; i++)
                {
                    sql.Append("delete from BigDog_Admin_Role where Id=@Id");
                    SqlParameter[] parms = new SqlParameter[] {
                            new SqlParameter("@Id",SqlDbType.NVarChar,50)             
                        };
                    parms[0].Value = idArr[i];
                    SQLHelper.ExecuteNonQuery(trans, CommandType.Text, sql.ToString(), parms);
                    sql.Clear();
                }
                trans.Commit();
            }
            catch (Exception e)
            {
                trans.Rollback();
                result = false;
                throw new ApplicationException(e.Message);

            }
            finally
            {
                conn.Close();
            }
            return result;
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

        public RoleInfo GetById(string id)
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
                model.Id = dt.Rows[0]["Id"].ToString();
                model.Name = dt.Rows[0]["Name"].ToString();
                model.Description = dt.Rows[0]["Description"].ToString();
                return model;
            }
            return null;
        }

        public DataTable GetList(string name="")
        {
            StringBuilder sql = new StringBuilder();
            DataTable dt = new DataTable();
            sql.Append("select Id,Name,Description from BigDog_Admin_Role ");
            if (name != "")
            {
                sql.Append("where Name like '%@name%' ");
                SqlParameter[] parms = new SqlParameter[] { 
                new SqlParameter("@name",SqlDbType.NVarChar,50)
                };
                dt = SQLHelper.GetDs(sql.ToString(),parms).Tables[0];
            }
             dt = SQLHelper.GetDs(sql.ToString()).Tables[0];
            if (dt.Rows.Count > 0)
            {
                return dt;
            }
            return null;
        }

       
    }
}
