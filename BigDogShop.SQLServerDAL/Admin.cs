using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using BigDogShop.DBUtility;
using BigDogShop.IDAL;
using BigDogShop.Model;

namespace BigDogShop.SQLServerDAL
{
    public class Admin : IAdmin
    {
        /// <summary>
        /// 判断是否存在本条记录
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool Exists(int id)
        {
            StringBuilder sql = new StringBuilder();

            sql.Append("select count(1) from BigDog_Admin where Id=@Id ");
            SqlParameter[] parms = new SqlParameter[] {
                new SqlParameter("@Id",SqlDbType.NVarChar,50)             
            };
            return SQLHelper.ExecuteNonQuery(CommandType.Text, sql.ToString(), parms) > 0;
        }

        /// <summary>
        /// 判断用户名是否存在
        /// </summary>
        /// <param name="user_name"></param>
        /// <returns></returns>
        public bool Exists(string user_name)
        {
            StringBuilder sql = new StringBuilder();
            sql.Append("select count(1) from BigDog_Admin where User_Name=@User_Name ");
            SqlParameter[] parms = new SqlParameter[] {
                new SqlParameter("@User_Name",SqlDbType.NVarChar,50)             
            };
            parms[0].Value = user_name;
            return SQLHelper.ExecuteNonQuery(CommandType.Text, sql.ToString(), parms) > 0;
        }

        /// <summary>
        /// 添加一条信息
        /// </summary>
        /// <param name="admin"></param>
        /// <returns></returns>
        public bool Add(AdminInfo admin)
        {
            StringBuilder sql = new StringBuilder();
            sql.Append("insert into BigDog_Admin (User_Name,Password,E_Mail)");
            sql.Append(" values(@User_Name,@Password,@E_Mail)");
            SqlParameter[] parms = new SqlParameter[] {
                new SqlParameter("@User_Name",SqlDbType.NVarChar,50),
                new SqlParameter("@Password",SqlDbType.NVarChar,50),
                new SqlParameter("@E_Mail",SqlDbType.NVarChar,50)
            };
            parms[0].Value = admin.User_Name;
            parms[1].Value = admin.Password;
            parms[2].Value = admin.E_Mail;
            return SQLHelper.ExecuteNonQuery(CommandType.Text, sql.ToString(), parms) > 0;
        }

        /// <summary>
        /// 更新记录
        /// </summary>
        /// <param name="admin"></param>
        /// <returns></returns>
        public bool Update(AdminInfo admin)
        {
            StringBuilder sql = new StringBuilder();
            sql.Append("update BigDog_Admin set User_Name=@User_Name,");
            sql.Append("Real_Name=@Real_Name,Password=@Password,User_Photo_Url=@User_Photo_Url,");
            sql.Append("E_Mail=@E_Mail,Is_Lock=@Is_Lock,Update_Date=@Update_Date,Updated_By=@Updated_By where Id=@Id");
            SqlParameter[] parms = new SqlParameter[] {
                new SqlParameter("@User_Name",SqlDbType.NVarChar,50),
                new SqlParameter("@Real_Name",SqlDbType.NVarChar,50),
                new SqlParameter("@Password",SqlDbType.NVarChar,50),
                new SqlParameter("@User_Photo_Url",SqlDbType.NVarChar,50),
                new SqlParameter("@E_Mail",SqlDbType.NVarChar,50),
                new SqlParameter("@Is_Lock",SqlDbType.NVarChar,1),
                new SqlParameter("@Update_Date",SqlDbType.DateTime),
                new SqlParameter("@Updated_By",SqlDbType.NVarChar,50)
            };
            parms[0].Value = admin.User_Name;
            parms[1].Value = admin.Real_Name;
            parms[2].Value = admin.Password;
            parms[3].Value = admin.User_Photo_Url;
            parms[4].Value = admin.E_Mail;
            parms[5].Value = admin.Is_Lock;
            parms[6].Value = admin.Updated_Date;
            parms[7].Value = admin.Updated_By;
            parms[8].Value = admin.Id;
            return SQLHelper.ExecuteNonQuery(CommandType.Text, sql.ToString(), parms) > 0;
        }

        /// <summary>
        /// 删除记录(string类型id)
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool Delete(string id)
        {
            bool result = true;
            StringBuilder sql = new StringBuilder();
            SqlConnection conn = new SqlConnection(SQLHelper.ConnString);
            conn.Open();
            SqlTransaction trans = conn.BeginTransaction();
            string[] idArr = id.Split(new char[] { ',' });
            try
            {
                for (int i = 0; i < idArr.Length; i++)
                {
                    sql.Append("delete from BigDog_Admin where Id=@Id");
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

        /// <summary>
        /// 根据Id获取信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public AdminInfo GetById(int id)
        {
            StringBuilder sql = new StringBuilder();
            sql.Append("select User_Name,Real_Name,Password,User_Photo_Url,E_Mail,Is_Lock from BigDog_Admin where id='" + id + "'");
            AdminInfo admin = new AdminInfo();
            DataTable dt = new DataTable();
            dt = SQLHelper.GetDs(sql.ToString()).Tables[0];
            if (dt.Rows.Count > 0)
            {
                admin.User_Name = dt.Rows[0]["User_Name"].ToString();
                admin.Real_Name = dt.Rows[0]["Real_Name"].ToString();
                admin.Password = dt.Rows[0]["Password"].ToString();
                admin.User_Photo_Url = dt.Rows[0]["User_Photo_Url"].ToString();
                admin.E_Mail = dt.Rows[0]["E_Mail"].ToString();
                admin.Is_Lock = dt.Rows[0]["Is_Lock"].ToString();
                return admin;
            }
            else
            {
                return null;
            }

        }

        /// <summary>
        /// 根据用户名密码获取信息
        /// </summary>
        /// <param name="user_name"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public AdminInfo GetModel(string user_name, string password)
        {
            StringBuilder sql = new StringBuilder();
            sql.Append("select Id,User_Name,Real_Name,Password,User_Photo_Url,E_Mail,Is_Lock from BigDog_Admin ");
            sql.Append("where User_Name=@User_Name and Password=@Password");
            SqlParameter[] parms = new SqlParameter[] {
                new SqlParameter("@User_Name",SqlDbType.NVarChar,50),
                new SqlParameter("@Password",SqlDbType.NVarChar,50)
            };
            parms[0].Value = user_name;
            parms[1].Value = password;
            object val = SQLHelper.ExecuteScalar(CommandType.Text, sql.ToString(), parms);
            if (val != null)
            {
                return GetById(Convert.ToInt32(val));
            }
            return null;
        }


        public DataTable GetList()
        {
            StringBuilder sql = new StringBuilder();
            sql.Append("select *  from BigDog_Admin ");
            return SQLHelper.GetDs(sql.ToString()).Tables[0];
        }

        public DataTable GetList(string name = "")
        {
            StringBuilder sql = new StringBuilder();
            sql.Append("select *  from BigDog_Admin where 1=1 ");
            if (name != "")
            {
                sql.Append(" and User_Name like '%" + name + "%'");
            }
            SqlParameter[] parms = new SqlParameter[] {
                new SqlParameter("@Id",SqlDbType.NVarChar,50)             
            };
            return SQLHelper.GetDs(sql.ToString(), parms).Tables[0];
        }
    }
}