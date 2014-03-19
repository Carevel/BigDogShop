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
    public class Operate : IOperate
    {
        /// <summary>
        /// 判断是否存在本条记录
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool Exists(int id)
        {
            StringBuilder sql = new StringBuilder();

            sql.Append("select count(1) from BigDog_Admin_Operate where Id=@Id ");
            SqlParameter[] parms = new SqlParameter[] {
                new SqlParameter("@Id",SqlDbType.NVarChar,50)             
            };
            return SQLHelper.ExecuteNonQuery(CommandType.Text, sql.ToString(), parms) > 0;
        }

        /// <summary>
        /// 判断用户名是否存在
        /// </summary>
        /// <param name="operate_Name"></param>
        /// <returns></returns>
        public bool Exists(string operate_Name)
        {
            StringBuilder sql = new StringBuilder();
            sql.Append("select count(1) from BigDog_Admin_Operate where Operate_Name=@Operate_Name ");
            SqlParameter[] parms = new SqlParameter[] {
                new SqlParameter("@Operate_Name",SqlDbType.NVarChar,50)             
            };
            parms[0].Value = operate_Name;
            return SQLHelper.ExecuteNonQuery(CommandType.Text, sql.ToString(), parms) > 0;
        }

        /// <summary>
        /// 添加操作
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool Add(OperateInfo model)
        {
            StringBuilder sql = new StringBuilder();
            sql.Append("insert into BigDog_Admin_Operate (Id,Operate_Name,Key_Code,Menu_Id,Enabled,Sort_Id)");
            sql.Append(" values(@Id,@Operate_Name,@Key_Code,@Menu_Id,@Enabled,@Sort_Id)");
            SqlParameter[] parms = new SqlParameter[] {
                new SqlParameter("@Id",SqlDbType.NVarChar,50),
                new SqlParameter("@Operate_Name",SqlDbType.NVarChar,50),
                new SqlParameter("@Key_Code",SqlDbType.NVarChar,50),
                new SqlParameter("@Menu_Id",SqlDbType.NVarChar,50),
                new SqlParameter("@Enabled",SqlDbType.NVarChar,50),
                new SqlParameter("@Sort_Id",SqlDbType.NVarChar,50)
            };
            parms[0].Value = model.Id;
            parms[1].Value = model.Operate_Name;
            parms[2].Value = model.Key_Code;
            parms[3].Value = model.Menu_Id;
            parms[4].Value = model.Enabled;
            parms[5].Value = model.Sort_Id;
            return SQLHelper.ExecuteNonQuery(CommandType.Text, sql.ToString(), parms) > 0;
        }


        /// <summary>
        /// 更新记录
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool Update(OperateInfo model)
        {
            StringBuilder sql = new StringBuilder();
            sql.Append("update BigDog_Admin_Operate set Operate_Name=@Operate_Name,Key_Code=@Key_Code,");
            sql.Append("Menu_Id=@Menu_Id,Enabled=@Enabled,Sort_Id=@Sort_Id,,Update_Date=@Update_Date");
            sql.Append(" where Id=@Id");
            SqlParameter[] parms = new SqlParameter[] {
                new SqlParameter("@Operate_Name",SqlDbType.NVarChar,50),
                new SqlParameter("@Key_Code",SqlDbType.NVarChar,50),
                new SqlParameter("@Menu_Id",SqlDbType.NVarChar,50),
                new SqlParameter("@Enabled",SqlDbType.NVarChar,50),
                new SqlParameter("@Sort_Id",SqlDbType.NVarChar,50),
                new SqlParameter("@Update_Date",SqlDbType.DateTime),
                new SqlParameter("@Id",SqlDbType.NVarChar,50)             
            };
            parms[0].Value = model.Operate_Name;
            parms[1].Value = model.Key_Code;
            parms[2].Value = model.Menu_Id;
            parms[3].Value = model.Enabled;
            parms[5].Value = model.Sort_Id;
            parms[6].Value = model.Updated_Date;
            parms[7].Value = model.Id;
            return SQLHelper.ExecuteNonQuery(CommandType.Text, sql.ToString(), parms) > 0;
        }

        /// <summary>
        /// 删除记录(string类型id)
        /// </summary>
        /// <param name="ids"></param>
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
                    sql.Append("delete from BigDog_Admin_Operate where Id=@Id");
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
        public OperateInfo GetById(int id)
        {
            StringBuilder sql = new StringBuilder();
            sql.Append("select Id,Operate_Name,Key_Code,Menu_Id,Sort_Id,Enabled,Created_Date from BigDog_Admin_Operate where id='" + id + "'");
            OperateInfo model = new OperateInfo();
            DataTable dt = new DataTable();
            dt = SQLHelper.GetDs(sql.ToString()).Tables[0];
            if (dt.Rows.Count > 0)
            {
                model.Id = Convert.ToInt32(dt.Rows[0]["Role_Id"].ToString());
                model.Operate_Name = dt.Rows[0]["Role_Type"].ToString();
                model.Key_Code = dt.Rows[0]["User_Name"].ToString();
                model.Menu_Id = dt.Rows[0]["Real_Name"].ToString();
                model.Sort_Id = Convert.ToInt32(dt.Rows[0]["Password"].ToString());
                model.Created_Date = Convert.ToDateTime(dt.Rows[0]["Created_Date"].ToString());
                model.Enabled = dt.Rows[0]["Enabled"].ToString();
                return model;
            }
            else
            {
                return null;
            }

        }

        /// <summary>
        /// 根据操作名称获取信息
        /// </summary>
        /// <param name="user_name"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public OperateInfo GetModel(string operate_Name)
        {
            StringBuilder sql = new StringBuilder();
            sql.Append("select count(1) from BigDog_Admin_Operate where Operate_Name=@Operate_Name ");
            SqlParameter[] parms = new SqlParameter[] {
                new SqlParameter("@Operate_Name",SqlDbType.NVarChar,50)             
            };
            parms[0].Value = operate_Name;
            OperateInfo model = new OperateInfo();
            DataTable dt = SQLHelper.GetDs(sql.ToString(), parms).Tables[0];
            if (dt.Rows.Count > 0)
            {
                model.Id = Convert.ToInt32(dt.Rows[0]["Id"]);
                model.Operate_Name = dt.Rows[0]["Operate_Name"].ToString();
                model.Key_Code = dt.Rows[0]["Key_Code"].ToString();
                model.Menu_Id = dt.Rows[0]["Menu_Id"].ToString();
                model.Enabled = dt.Rows[0]["Enabled"].ToString();
                model.Sort_Id = Convert.ToInt32(dt.Rows[0]["Sort_Id"].ToString());
                return model;
            }

            return null;
        }

        public DataTable GetList(string name = "")
        {
            StringBuilder sql = new StringBuilder();
            sql.Append("select Id,Operate_Name,Key_Code,Menu_Id,Enabled,Sort_Id from BigDog_Admin_Operate where 1=1 ");
            if (name != "")
            {
                sql.Append(" and User_Name like '%@name%'");
            }
            SqlParameter[] parms = new SqlParameter[] {
                new SqlParameter("@name",SqlDbType.NVarChar,50)             
            };
           
            return SQLHelper.GetDs(sql.ToString(), parms).Tables[0];
        }
    }
}
