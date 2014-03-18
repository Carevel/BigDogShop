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
            sql.Append("insert into BigDog_Admin (Role_Id,Role_Type,User_Name,Real_Name,Password,E_Mail)");
            sql.Append(" values(1,1,@User_Name,@Real_Name,@Password,@E_Mail)");
            SqlParameter[] parms = new SqlParameter[] {
                new SqlParameter("@User_Name",SqlDbType.NVarChar,50),
                new SqlParameter("@Real_Name",SqlDbType.NVarChar,50),
                new SqlParameter("@Password",SqlDbType.NVarChar,50),
                new SqlParameter("@E_Mail",SqlDbType.NVarChar,50)
            };
            parms[0].Value = admin.User_Name;
            parms[1].Value = admin.Real_Name;
            parms[2].Value = admin.Password;
            parms[3].Value = admin.E_Mail;
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
            sql.Append("update BigDog_Admin set Role_Id=@Role_Id,Role_Type=@Role_Type,User_Name=@User_Name,");
            sql.Append("Real_Name=@Real_Name,Password=@Password,User_Photo_Url=@User_Photo_Url,");
            sql.Append("E_Mail=@E_Mail,Is_Lock='@Is_Lock,Update_Date=@Update_Date,Updated_By=@Updated_By where Id=@Id");
            SqlParameter[] parms = new SqlParameter[] {
                new SqlParameter("@Role_Id",SqlDbType.Int),
                new SqlParameter("@Role_Type",SqlDbType.Int),
                new SqlParameter("@User_Name",SqlDbType.NVarChar,50),
                new SqlParameter("@Real_Name",SqlDbType.NVarChar,50),
                new SqlParameter("@Password",SqlDbType.NVarChar,50),
                new SqlParameter("@User_Photo_Url",SqlDbType.NVarChar,50),
                new SqlParameter("@E_Mail",SqlDbType.NVarChar,50),
                new SqlParameter("@Is_Lock",SqlDbType.NVarChar,1),
                new SqlParameter("@Update_Date",SqlDbType.DateTime),
                new SqlParameter("@Updated_By",SqlDbType.NVarChar,50)
            };
            parms[0].Value = admin.Role_Id;
            parms[1].Value = admin.Role_Type;
            parms[2].Value = admin.User_Name;
            parms[3].Value = admin.Real_Name;
            parms[5].Value = admin.Password;
            parms[6].Value = admin.User_Photo_Url;
            parms[7].Value = admin.E_Mail;
            parms[8].Value = admin.Is_Lock;
            parms[9].Value = admin.Updated_Date;
            parms[10].Value = admin.Updated_By;
            parms[11].Value = admin.Id;
            return SQLHelper.ExecuteNonQuery(CommandType.Text, sql.ToString(), parms) > 0;
        }

        /// <summary>
        /// 删除记录
        /// </summary>
        /// <param name="usernames"></param>
        /// <returns></returns>
        public bool Delete(string usernames)
        {
            StringBuilder sql = new StringBuilder();
            SqlTransaction trans=new SqlTransaction();
            bool success = true;
            string[] names = usernames.Split(new char[] { ',' });
            for (int i = 0; i < names.Length; i++)
            {
                sql.Append("delete from BigDog_Admin where Id=@Id");
                SqlParameter[] parms = new SqlParameter[] {
                new SqlParameter("@Id",SqlDbType.NVarChar,50)             
                };
                SQLHelper.ExecuteNonQuery(trans, CommandType.Text, sql.ToString(), parms);
                
            }
            try
            {
                trans.Commit();
                return true;
            }
            catch (Exception ex)
            {
                trans.Rollback();
                return false;
            }
                      
        }

        /// <summary>
        /// 根据Id获取信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public AdminInfo GetById(int id)
        {
            StringBuilder sql = new StringBuilder();
            sql.Append("select Role_Id,Role_Type,User_Name,Real_Name,Password,User_Photo_Url,E_Mail,Is_Lock from BigDog_Admin where id='" + id + "'");
            AdminInfo admin = new AdminInfo();
            DataTable dt = new DataTable();
            dt = SQLHelper.GetDs(sql.ToString()).Tables[0];
            if (dt.Rows.Count > 0)
            {
                admin.Role_Id = Convert.ToInt32(dt.Rows[0]["Role_Id"].ToString());
                admin.Role_Type = Convert.ToInt32(dt.Rows[0]["Role_Type"].ToString());
                admin.User_Name = dt.Rows[0]["User_Name"].ToString();
                admin.Real_Name = dt.Rows[0]["Real_Name"].ToString();
                admin.Password = dt.Rows[0]["Password"].ToString();
                admin.User_Photo_Url = dt.Rows[0]["User_Photo_Url"].ToString();
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
            sql.Append("select Id,Role_Id,Role_Type,User_Name,Real_Name,Password,User_Photo_Url,E_Mail,Is_Lock from BigDog_Admin ");
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
            sql.Append("delete from BigDog_Admin ");
            return SQLHelper.GetDs(sql.ToString()).Tables[0];
        }

        public DataTable GetList(string name = "")
        {
            StringBuilder sql = new StringBuilder();
            sql.Append("delete from BigDog_Admin where 1=1 ");
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