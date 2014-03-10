using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using BigDogShop.IDAL;
using BigDogShop.Model;
using BigDogShop.DBUtility;

namespace BigDogShop.SQLServerDAL
{
    public class Service:IService
    {
        /// <summary>
        /// 添加一条数据
        /// </summary>
        /// <param name="service"></param>
        /// <returns></returns>
        public bool Add(ServiceInfo service)
        {
            StringBuilder sql = new StringBuilder();
            sql.Append("inser into BigDog_Service (Service_Name,Father_Id,Description,Service_Url)");
            sql.Append("values(@Service_Name,@Description,@Service_Url)");
            SqlParameter[] parms = new SqlParameter[]{
                new SqlParameter("@Service_Name",SqlDbType.NVarChar,50),
                new SqlParameter("@Description",SqlDbType.Int),
                new SqlParameter("@Service_Url",SqlDbType.NVarChar,200)
            };
            parms[0].Value = service.Service_Name;
            parms[1].Value = service.Father_Id;
            parms[2].Value = service.Description;
            parms[3].Value = service.Service_Url;
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
            sql.Append("delete from BigDog_Service where Id=@Id");
            SqlParameter[] parms = new SqlParameter[] {
                new SqlParameter("@Id",SqlDbType.Int)
            };
            parms[0].Value = id;
            return SQLHelper.ExecuteNonQuery(CommandType.Text, sql.ToString(), parms) > 0;
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        /// <param name="service"></param>
        /// <returns></returns>
        public bool Update(ServiceInfo service)
        {
            StringBuilder sql = new StringBuilder();
            sql.Append("update BigDog_Shop set Service_Name=@Service_Name,Description=@Description,Service_Url=@Service_Url where Id=@Id");
            SqlParameter[] parms = new SqlParameter[] { 
                new SqlParameter("@Service_Name",SqlDbType.NVarChar,50),
                new SqlParameter("@Description",SqlDbType.NVarChar,100),
                new SqlParameter("@Service_Url",SqlDbType.NVarChar,200),
                new SqlParameter("@Id",SqlDbType.Int)
            };
            parms[0].Value = service.Service_Name;
            parms[1].Value = service.Description;
            parms[2].Value = service.Service_Url;
            parms[3].Value = service.Id;
            return SQLHelper.ExecuteNonQuery(CommandType.Text, sql.ToString(), parms) > 0;
        }


        /// <summary>
        /// 根据Id获取实体
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ServiceInfo GetById(int id)
        {
            StringBuilder sql = new StringBuilder();
            sql.Append("select Id,Service_Name,Father_Id,Description,Service_Url from BigDog_Service where Id=@Id");
            SqlParameter[] parms = new SqlParameter[] { 
                new SqlParameter("@Id",SqlDbType.Int)
            };
            parms[0].Value = id;
            ServiceInfo service = new ServiceInfo();
            DataTable dt = SQLHelper.GetDs(sql.ToString(),parms).Tables[0];
            if (dt.Rows.Count > 0)
            {
                service.Id = Convert.ToInt32( dt.Rows[0]["Id"]);
                service.Service_Name = dt.Rows[0]["Service_Name"].ToString();
                service.Service_Url = dt.Rows[0]["Service_Url"].ToString();
                return service;
            }
            return null;    
        }

        /// <summary>
        /// 获取数据集
        /// </summary>
        /// <returns></returns>
        public DataTable GetServiceList()
        {
            StringBuilder sql = new StringBuilder();
            sql.Append("select Id,Service_Name,Father_Id,Description,Service_Url from BigDog_Service");
            ServiceInfo service = new ServiceInfo();
            DataTable dt = SQLHelper.GetDs(sql.ToString()).Tables[0];
            if (dt.Rows.Count > 0)
            {
                return dt;
            }
            return null;    
        }

        /// <summary>
        /// 获取子数据集
        /// </summary>
        /// <returns></returns>
        public DataTable GetServiceList(int father_id)
        {
            StringBuilder sql = new StringBuilder();
            sql.Append("select Id,Service_Name,Father_Id,Description,Service_Url from BigDog_Service where Father_Id='"+father_id+"'");
            //SqlParameter[] parms = new SqlParameter[] { 
            //    new SqlParameter("@Father_Id",SqlDbType.Int)
            //};
            //parms[0].Value = father_id;
            ServiceInfo service = new ServiceInfo();
            DataTable dt = SQLHelper.GetDs(sql.ToString()).Tables[0];
            if (dt.Rows.Count > 0)
            {
                return dt;
            }
            return null;
        }
    }
}
