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
    public class Right:IRight
    {
        public bool Add(RightInfo model)
        {
            StringBuilder sql = new StringBuilder();
            sql.Append("insert into BigDog_Admin_Right(Id,Right_Id,Role_Id,Description) values(@Id,@Right_Id,@Role_Id,@desc)");
            SqlParameter[] parms = new SqlParameter[] { 
                new SqlParameter("@Id",SqlDbType.NVarChar,50),
                new SqlParameter("@Right_Id",SqlDbType.NVarChar,50),
                new SqlParameter("@Role_Id",SqlDbType.NVarChar,200),
                new SqlParameter("@desc",SqlDbType.NVarChar,200)
            };
            parms[0].Value = model.Id;
            parms[1].Value = model.Right_Id;
            parms[2].Value = model.Role_Id;
            parms[3].Value = model.Description;
            return SQLHelper.ExecuteNonQuery(CommandType.Text, sql.ToString(), parms) > 0;
        }

        /// <summary>
        /// 支持批量删除
        /// </summary>
        /// <param name="ids">string类型字符串，用","隔开</param>
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
                    sql.Append("delete from BigDog_Admin_Right where Id=@Id");
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

        public bool Update(RightInfo model)
        {
            StringBuilder sql = new StringBuilder();
            sql.Append("update BigDog_Admin_Right set Right_Id=@Right_Id,Role_Id=@Role_Id,Description=@Description where Id=@id");
            SqlParameter[] parms = new SqlParameter[] { 
                new SqlParameter("@Right_Id",SqlDbType.NVarChar,50),
                new SqlParameter("@Role_Id",SqlDbType.NVarChar,200),
                new SqlParameter("@Description",SqlDbType.NVarChar,50),
                new SqlParameter("@Id",SqlDbType.NVarChar,50)
            };
            parms[0].Value = model.Right_Id;
            parms[1].Value = model.Role_Id;
            parms[2].Value = model.Description;
            parms[3].Value = model.Id;
            return SQLHelper.ExecuteNonQuery(CommandType.Text, sql.ToString(), parms) > 0;
        }

        public RightInfo GetById(string id)
        {
            StringBuilder sql = new StringBuilder();
            sql.Append("select Id,Right_Id,Role_Id,Description from BigDog_Admin_Right where Id=@Id");
            SqlParameter[] parms = new SqlParameter[] { 
                new SqlParameter("@Id",SqlDbType.Int)
            };
            parms[0].Value = id;
            RightInfo model = new RightInfo();
            DataTable dt = SQLHelper.GetDs(sql.ToString(), parms).Tables[0];
            if (dt.Rows.Count > 0)
            {
                model.Id = dt.Rows[0]["Id"].ToString();
                model.Right_Id = dt.Rows[0]["Right_Id"].ToString();
                model.Role_Id = dt.Rows[0]["Role_Id"].ToString();
                model.Description = dt.Rows[0]["Description"].ToString();
                return model;
            }
            return null;
        }

        public DataTable GetList(string name = "")
        {
            StringBuilder sql = new StringBuilder();
            DataTable dt = new DataTable();
            sql.Append("select Id,Right_Id,Role_Id,Description,Created_Date from BigDog_Admin_Right ");
            if (name != "")
            {
                sql.Append("where Right_Id like '%@name%' ");
                SqlParameter[] parms = new SqlParameter[] { 
                    new SqlParameter("@name",SqlDbType.NVarChar,50)
                };
                parms[0].Value = name;
                dt = SQLHelper.GetDs(sql.ToString(), parms).Tables[0];
            }
            else
            {
                dt = SQLHelper.GetDs(sql.ToString()).Tables[0];
            }

            if (dt.Rows.Count > 0)
            {
                return dt;
            }
            return null;
        }

    }
}
