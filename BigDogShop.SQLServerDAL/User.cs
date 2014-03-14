using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using BigDogShop.DBUtility;
using BigDogShop.IDAL;
using BigDogShop.Model;

namespace BigDogShop.SQLServerDAL
{
    public class User : IUser
    {
        /// <summary>
        /// 判断用户名是存在
        /// </summary>
        /// <param name="user_name"></param>
        /// <returns></returns>
        public bool Exists(string user_name)
        {
            StringBuilder sql = new StringBuilder();
            sql.Append("select count(1) from BigDog_User where User_Name=@User_Name");
            SqlParameter[] parms = new SqlParameter[] {
                new SqlParameter("@User_Name",SqlDbType.NVarChar,50)
            };
            return SQLHelper.ExecuteNonQuery(CommandType.Text, sql.ToString(), parms) > 0;
        }

        /// <summary>
        /// 根据用户名密码获取用户信息
        /// </summary>
        /// <param name="user_name"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public UserInfo GetUserInfo(string user_name, string password)
        {
            StringBuilder sql = new StringBuilder();
            sql.Append("select Id,User_Name,Password,Nick_Name,Real_Name,Score,User_Photo_Url,Birthday,Income,Marry_Status,");
            sql.Append(" E_Mail,Phone_Number,User_Type,Hobby,Address,School_Type,School,Department,Enrolled_Date,Company_Name,");
            sql.Append(" Worked_Begin_Date,Status from BigDog_User where User_Name=@User_Name and Password=@Password");
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

        /// <summary>
        /// 用户注册
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public bool Register(UserInfo user)
        {
            StringBuilder sql = new StringBuilder();
            sql.Append("insert into BigDog_User (User_Name,Password,E_Mail,User_Type,CreatedDate,Creator)values(@User_Name,@Password,@E_Mail,@User_Type,@CreatedDate,@Creator)");
            SqlParameter[] parms = new SqlParameter[] {
                new SqlParameter("@User_Name",SqlDbType.NVarChar,20),
                new SqlParameter("@Password",SqlDbType.NVarChar,20),
                new SqlParameter("@E_Mail",SqlDbType.NVarChar,20),
                new SqlParameter("@User_Type",SqlDbType.Int),
                new SqlParameter("@CreatedDate",SqlDbType.DateTime),
                new SqlParameter("@Creator",SqlDbType.NVarChar,20)
            };
            parms[0].Value = user.User_Name;
            parms[1].Value = user.Password;
            parms[2].Value = user.E_Mail;
            parms[3].Value = user.User_Type;
            parms[4].Value = user.Created_Date;
            parms[5].Value = user.Created_By;
            return SQLHelper.ExecuteNonQuery(CommandType.Text, sql.ToString(), parms) > 0;
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public bool Update(UserInfo user)
        {
            StringBuilder sql = new StringBuilder();
            sql.Append("update BigDog_User set Nick_Name=@Nick_Name,Password=@Password,Real_Name=@Real_Name,Score=@Score,User_Photo_Url=@User_Photo_Url,");
            sql.Append("Birthday=@Birthday,Income=@Income,Marry_Status=@Marry_Status,E_Mail=@E_Mail,Phone_Number=@Phone_Number,Hobby=@Hobby,");
            sql.Append("Address=@Address,School_Type=@School_Type,School=@School,Department=@Department,Enrolled_Date=@Enrolled_Date,");
            sql.Append("Company_Name=@Company_Name,Worked_Begin_Date=@Worked_Begin_Date,Status=@Status ");
            sql.Append("where Id=@Id");
            SqlParameter[] parms = new SqlParameter[] {
                    new SqlParameter("@Nick_Name",SqlDbType.NVarChar,20),
                    new SqlParameter("@Password",SqlDbType.NVarChar,20),
                    new SqlParameter("@Real_Name",SqlDbType.NVarChar,20),
                    new SqlParameter("@Score",SqlDbType.Int),
                    new SqlParameter("@User_Photo_Url",SqlDbType.NVarChar,50),
                    new SqlParameter("@Birthday",SqlDbType.DateTime),
                    new SqlParameter("@Income",SqlDbType.NVarChar,20),
                    new SqlParameter("@Marry_Status",SqlDbType.NVarChar,20),
                    new SqlParameter("@E_Mail",SqlDbType.NVarChar,20),
                    new SqlParameter("@Phone_Number",SqlDbType.NVarChar,20),
                    new SqlParameter("@Hobby",SqlDbType.NVarChar,20),
                    new SqlParameter("@Address",SqlDbType.NVarChar,20),
                    new SqlParameter("@School_Type",SqlDbType.NVarChar,20),
                    new SqlParameter("@School",SqlDbType.NVarChar,20),
                    new SqlParameter("@Department",SqlDbType.NVarChar,20),
                    new SqlParameter("@Enrolled_Date",SqlDbType.NVarChar,20),
                    new SqlParameter("@Company_Name",SqlDbType.NVarChar,20),
                    new SqlParameter("@Worked_Begin_Date",SqlDbType.NVarChar,20),
                    new SqlParameter("@Status",SqlDbType.NVarChar,20),
                    new SqlParameter("@Id",SqlDbType.Int)
            };
            parms[0].Value = user.Nick_Name;
            parms[1].Value = user.Password;
            parms[2].Value = user.Real_Name;
            parms[3].Value = user.Score;
            parms[4].Value = user.User_Photo_Url;
            parms[5].Value = user.Birthday;
            parms[6].Value = user.Income;
            parms[7].Value = user.Marry_Status;
            parms[8].Value = user.E_Mail;
            parms[9].Value = user.Phone_Number;
            parms[10].Value = user.Hobby;
            parms[11].Value = user.Address;
            parms[12].Value = user.School_Type;
            parms[13].Value = user.School;
            parms[14].Value = user.Department;
            parms[15].Value = user.Enrolled_Date;
            parms[16].Value = user.Company_Name;
            parms[17].Value = user.Worked_Begin_Time;
            parms[19].Value = user.Status;
            parms[20].Value = user.Id;
            return SQLHelper.ExecuteNonQuery(CommandType.Text, sql.ToString(), parms) > 0;
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool Delete(int id)
        {
            StringBuilder sql = new StringBuilder();
            sql.Append("delete from BigDog_User where Id=@Id");
            SqlParameter[] parms = new SqlParameter[] { 
                new SqlParameter("@Id",SqlDbType.Int)
            };
            parms[0].Value = id;
            return SQLHelper.ExecuteNonQuery(CommandType.Text, sql.ToString(), parms) > 0;
        }

        /// <summary>
        /// 根据Id获取实体
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public UserInfo GetById(int id)
        {
            UserInfo user = new UserInfo();
            StringBuilder sql = new StringBuilder();
            sql.Append("select Id,User_Name,Password,Nick_Name,Real_Name,Score,User_Photo_Url,Birthday,Income,Marry_Status,");
            sql.Append(" E_Mail,Phone_Number,User_Type,Hobby,Address,School_Type,School,Department,Enrolled_Date,Company_Name,");
            sql.Append(" Worked_Begin_Date,Status from BigDog_User where Id='" + id + "'");
            DataTable dt = new DataTable();
            dt = SQLHelper.GetDs(sql.ToString()).Tables[0];
            if (dt.Rows.Count > 0)
            {
                user.Id = Convert.ToInt32(dt.Rows[0]["Id"].ToString());
                user.User_Name = dt.Rows[0][1].ToString();
                user.Password = dt.Rows[0][2].ToString();
                user.Nick_Name = dt.Rows[0][3].ToString();
                user.Real_Name = dt.Rows[0][4].ToString();
                user.Score = Convert.ToInt32(dt.Rows[0][5].ToString());
                user.User_Photo_Url = dt.Rows[0][6].ToString();
                //user.Birthday =  Convert.ToDateTime(dt.Rows[0][7]) == null ? null : dt.Rows[0][7];
                user.Income = dt.Rows[0][8].ToString();
                user.Marry_Status = dt.Rows[0][9].ToString();
                user.E_Mail = dt.Rows[0][10].ToString();
                user.Phone_Number = dt.Rows[0][11].ToString();
                //user.User_Type =dt.Rows[0][12]==null? 0 : Convert.ToInt32( dt.Rows[0][12].ToString());
                user.Hobby = dt.Rows[0][13].ToString();
                user.Address = dt.Rows[0][14].ToString();
                user.School_Type = dt.Rows[0][15].ToString();
                user.School = dt.Rows[0][16].ToString();
                user.Department = dt.Rows[0][17].ToString();
                user.Enrolled_Date = dt.Rows[0][18].ToString();
                user.Company_Name = dt.Rows[0][19].ToString();
                user.Worked_Begin_Time = dt.Rows[0][20].ToString();
                user.Status = dt.Rows[0][21].ToString();
                return user;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// 获取所有数据
        /// </summary>
        /// <returns></returns>
        public DataTable GetList()
        {
            StringBuilder sql = new StringBuilder();
            sql.Append("select Id,User_Name,Password,Nick_Name,Real_Name,Score,User_Photo_Url,Birthday,Income,Marry_Status,");
            sql.Append(" E_Mail,Phone_Number,User_Type,Hobby,Address,School_Type,School,Department,Enrolled_Date,Company_Name,");
            sql.Append(" Worked_Begin_Date,Status from BigDog_User");
            DataTable dt = SQLHelper.GetDs(sql.ToString()).Tables[0];
            if (dt.Rows.Count > 0)
            {
                return dt;
            }
            return null;
        }

        /// <summary>
        /// 根据用户类型获取数据
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public DataTable GetList(string type)
        {
            StringBuilder sql = new StringBuilder();
            sql.Append("select Id,User_Name,Password,Nick_Name,Real_Name,Score,User_Photo_Url,Birthday,Income,Marry_Status,");
            sql.Append(" E_Mail,Phone_Number,User_Type,Hobby,Address,School_Type,School,Department,Enrolled_Date,Company_Name,");
            sql.Append(" Worked_Begin_Date,Status from BigDog_User where User_Type='N'");
            DataTable dt = SQLHelper.GetDs(sql.ToString()).Tables[0];
            if (dt.Rows.Count > 0)
            {
                return dt;
            }
            return null;
        }
    }
}
