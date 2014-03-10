using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using BigDogShop.IDAL;
using BigDogShop.Model;
using BigDogShop.DBUtility;


namespace BigDogShop.OracleDAL
{
    public class User : IDAL.IUser
    {

        /// <summary>
        /// 判断用户名是否存在
        /// </summary>
        /// <param name="user_name"></param>
        /// <returns></returns>
        public bool Exists(string user_name)
        {
            StringBuilder sql = new StringBuilder();

            sql.Append("select Id from BigDog_User where User_Name=? and Password=?");
            OleDbParameter[] parms = new OleDbParameter[] {
                    new OleDbParameter(":User_Name",OleDbType.VarChar,20)
                };
            parms[0].Value = user_name;
            sql.Append("select count(1) from Users where User_Name=@User_Name");
            return OracleHelper.ExecuteNonQuery(CommandType.Text, sql.ToString(), parms) > 0;
        }

        /// <summary>
        /// 检测邮件是否注册过
        /// </summary>
        /// <param name="E_Mail"></param>
        /// <returns></returns>
        public bool CheckEmail(string E_Mail)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.Append(" select count(1) from BigDog_User where E_Mail='" + E_Mail + "'");
                return OracleHelper.ExeSQL(sql.ToString()) > 0;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        /// <summary>
        /// 根据用户名密码获取用户信息
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public UserInfo GetUserInfo(string user_name, string password)
        {
            UserInfo user = new UserInfo();
            StringBuilder sql = new StringBuilder();
            sql.Append("select Id,User_Name,Password,Nick_Name,Real_Name,Score,User_Photo_Url,Birthday,Income,Marry_Status,");
            sql.Append(" E_Mail,Phone_Number,User_Type,Hobby,Address,School_Type,School,Department,EnrollDate,Company_Name,");
            sql.Append(" WorkingTime,Status from Users where user_name='" + user_name + "' and password='" + password + "'");
            DataTable dt = OracleHelper.GetDS(sql.ToString()).Tables[0];
            try
            {
                if (dt.Rows.Count > 0)
                {
                    user.Id = Convert.ToInt32(dt.Rows[0]["Id"].ToString());
                    user.User_Name = dt.Rows[0]["User_Name"].ToString();
                    user.E_Mail = dt.Rows[0]["E_Mail"].ToString();
                    user.Hobby = dt.Rows[0]["Hobby"].ToString();
                    user.Nick_Name = dt.Rows[0]["Nick_Name"].ToString();
                    user.User_Photo_Url = dt.Rows[0]["User_Photo_Url"].ToString();
                    user.Phone_Number = dt.Rows[0]["Phone_Number"].ToString();
                    user.Address = dt.Rows[0]["Address"].ToString();
                    user.Score = Convert.ToInt32(dt.Rows[0]["Score"].ToString());
                    user.Income = dt.Rows[0]["Income"].ToString();
                    user.Birthday = Convert.ToDateTime(dt.Rows[0]["Birthday"].ToString());
                    user.User_Name = dt.Rows[0][""].ToString();
                    user.School = dt.Rows[0][""].ToString();
                    user.User_Type = Convert.ToInt32(dt.Rows[0][""].ToString());
                    user.Real_Name = dt.Rows[0][""].ToString();
                    user.Status = dt.Rows[0][""].ToString();
                }
                else
                {
                    user = null;
                    return user;
                }
            }
            catch (OleDbException ex)
            {
                user = null;
                throw new Exception(ex.Message);
            }
            return user;
        }

        /// <summary>
        /// 根据userId获取user实体对象
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public UserInfo GetById(int userId)
        {
            UserInfo user = new UserInfo();
            StringBuilder sql = new StringBuilder();
            sql.Append("select Id,User_Name,Password,Nick_Name,Real_Name,Score,User_Photo_Url,Birthday,Income,Marry_Status,");
            sql.Append(" E_Mail,Phone_Number,User_Type,Hobby,Address,School_Type,School,Department,Enrolled_Date,Company_Name,");
            sql.Append(" Worked_Time_Begin,Worked_Time_End,Status from BigDog_User where Id='" + userId + "'");
            DataTable dt = OracleHelper.GetDS(sql.ToString()).Tables[0];
            try
            {
                if (dt.Rows.Count > 0)
                {
                    user.Id = Convert.ToInt32(dt.Rows[0][0].ToString());
                    user.User_Name = dt.Rows[0][1].ToString();
                    user.Password = dt.Rows[0][2].ToString();
                    user.Nick_Name = dt.Rows[0][3].ToString();
                    user.Real_Name = dt.Rows[0][4].ToString();
                    user.User_Photo_Url = dt.Rows[0][5].ToString();
                    //user.Birthday = Convert.ToDateTime( dt.Rows[0][6].ToString());
                    user.Income = dt.Rows[0][7].ToString();
                    user.Score = Convert.ToInt32(dt.Rows[0][8].ToString());
                    user.Income = dt.Rows[0][9].ToString();
                    user.E_Mail = dt.Rows[0][10].ToString();
                    user.Phone_Number = dt.Rows[0][11].ToString();
                    //user.Birthday = Convert.ToDateTime( dt.Rows[0][12].ToString());
                    user.User_Type = Convert.ToInt32(dt.Rows[0][12].ToString());
                    user.School = dt.Rows[0][14].ToString();
                    user.Address = dt.Rows[0][15].ToString();
                    user.School_Type = dt.Rows[0][16].ToString();
                    user.School = dt.Rows[0][17].ToString();
                    user.Department = dt.Rows[0][18].ToString();
                    //user.Enrolled_Date = dt.Rows[0][27].ToString();
                    user.Company_Name = dt.Rows[0][20].ToString();

                    user.Status = dt.Rows[0][21].ToString();
                }
            }
            catch (OleDbException ex)
            {
                user = null;
                throw new Exception(ex.Message);
            }
            return user;
        }

        /// <summary>
        /// 用户注册
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public bool Register(UserInfo user)
        {
            using (OleDbConnection conn = new OleDbConnection(OracleHelper.ConnString))
            {

                conn.Open();
                OleDbCommand cmd = new OleDbCommand();
                cmd.Connection = conn;
                OleDbTransaction trans = conn.BeginTransaction();
                cmd.Transaction = trans;
                try
                {
                    StringBuilder sql = new StringBuilder();
                    sql.Append("insert into BigDog_User(Id,E_Mail,user_name,Password) values(BigDog_User_seq.nextval,'" + user.E_Mail + "','" + user.Password + "','" + user.Real_Name + "')");
                    cmd.Parameters.Clear();
                    cmd.CommandText = sql.ToString();
                    int n1 = cmd.ExecuteNonQuery();

                    string key = Guid.NewGuid().ToString();
                    string param2 = string.Format("{0}|||{0}|{1}", user.E_Mail, key);
                    StringBuilder mailSql = new StringBuilder();
                    mailSql.Append("insert into common_mail_notice(mail_id,mail_info_id,params,mailed,mailed_date,creator,creation_date)");
                    mailSql.AppendFormat(" values(common_mail_notice_seq.nextval,'3','{0}','N',sysdate,'sys',sysdate)", param2);//3，用户注册，4修改密码
                    cmd.Parameters.Clear();
                    cmd.CommandText = mailSql.ToString();
                    int n2 = cmd.ExecuteNonQuery();
                    if (n1 > 0 && n2 > 0)
                    {
                        trans.Commit();
                        return true;
                    }
                    else
                    {
                        trans.Rollback();
                        return false;
                    }
                }
                catch (Exception ex)
                {
                    return false;
                    throw new Exception(ex.Message);
                }
            }

        }

        /// <summary>
        /// 修改密码
        /// </summary>
        /// <param name="user"></param>
        /// <param name="emailCode">E_Mail密码</param>
        /// <returns></returns>
        public bool UpdatePwd(UserInfo user)
        {
            StringBuilder sqlStr = new StringBuilder();
            sqlStr.Append("update BigDog_User set Password='" + user.Password + "' where Id='" + user.Id + "'");
            return OracleHelper.ExeSQL(sqlStr.ToString()) > 0;

        }


        /// <summary>
        /// 密码找回
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public bool GetPassword(UserInfo user)
        {
            return true;
        }
        /// <summary>
        /// 更新user对象
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public bool Update(UserInfo user)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                string[] param = new string[] { user.Password, user.Nick_Name, user.User_Photo_Url, user.Hobby, user.E_Mail, user.Phone_Number, user.Address, user.Hobby };
                sql.AppendFormat("update BigDog_User set user_name='{0}',nick_name='{1}',real_name='{2}',hobby='{3}',E_Mail='{4}',Phone_Number='{5}',address='{6}',updated_date=sysdate,Hobby='{7}' where Id='" + user.Id + "'", param);
                return OracleHelper.ExeSQL(sql.ToString()) > 0;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        /// <summary>
        /// 根据userId删除一个user对象
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public bool Delete(int userId)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.Append("delete from BigDog_User where Id='" + userId + "'");
                return OracleHelper.ExeSQL(sql.ToString()) > 0;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public List<UserInfo> GetAllUsers()
        {
            List<UserInfo> list = new List<UserInfo>();
            return list;
        }
        /// <summary>
        /// 获取用户状态
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public List<UserInfo> GetUserById(int userId)
        {
            List<UserInfo> list = new List<UserInfo>();
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.Append("select update_status,update_type from BigDog_User where Id='" + userId + "'");
                DataTable dt = OracleHelper.GetDS(sql.ToString()).Tables[0];
                //list.Add(dt.Rows[0][0].ToString());
                //list.Add(dt.Rows[0][1].ToString());
                return list;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
