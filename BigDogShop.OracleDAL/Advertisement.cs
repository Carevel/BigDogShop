using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.OleDb;
using System.Data;
using BigDogShop.IDAL;
using BigDogShop.Model;
using BigDogShop.DBUtility;

namespace BigDogShop
{
    public class Advertisement : IAdvertisement
    {

        /// <summary>
        /// 插入一条广告
        /// </summary>
        /// <param name="ad"></param>
        /// <returns></returns>
        public bool Insert(AdvertisementInfo ad)
        {
            StringBuilder sql = new StringBuilder();
            sql.Append("insert into BigDog_Advertisement(Ad_Id,image_url,title,Link_Url,created_date)values");
            sql.Append("(BigDog_Advertisement_seq.nextval,@Image_Url,@Title,@Link_Url,sysdate)");
            OleDbParameter[] parms = new OleDbParameter[]{
                new OleDbParameter("@Image_Url",OleDbType.VarChar,100),
                new OleDbParameter("@Title",OleDbType.VarChar,50),
                new OleDbParameter("@Link_Url",OleDbType.VarChar,100)
            };
            parms[0].Value = ad.Image_Url;
            parms[1].Value = ad.Title;
            parms[2].Value = ad.Link_Url;
            return OracleHelper.ExecuteNonQuery(CommandType.Text, sql.ToString(), parms) > 0;
        }

        /// <summary>
        /// 删除一条广告
        /// </summary>
        /// <param name="Ad_Id"></param>
        /// <returns></returns>
        public bool Delete(int Ad_Id)
        {
            StringBuilder sql = new StringBuilder();
            sql.Append("delete from BigDog_Advertisement where Ad_Id='" + Ad_Id + "'");
            return OracleHelper.ExecuteNonQuery(CommandType.Text, sql.ToString(), null) > 0;
        }

        /// <summary>
        /// 更新广告实体
        /// </summary>
        /// <param name="ad"></param>
        /// <returns></returns>
        public bool Update(AdvertisementInfo ad)
        {
            StringBuilder sql = new StringBuilder();
            sql.Append("update BigDog_Advertisement set Image_Url=@Image_Url,Title=@Title,Link_Url=@Link_Url,updated_date=sysdate where");
            sql.Append(" Ad_Id=@Ad_Id");
            OleDbParameter[] parms = new OleDbParameter[] {
                 new OleDbParameter("@Image_Url",OleDbType.VarChar,100),
                new OleDbParameter("@Title",OleDbType.VarChar,50),
                new OleDbParameter("@Link_Url",OleDbType.VarChar,100),
                new OleDbParameter("@Ad_Id",OleDbType.Integer)
            };
            return OracleHelper.ExecuteNonQuery(CommandType.Text, sql.ToString(), parms) > 0;
        }


        /// <summary>
        /// 根据Ad_Id获取广告信息
        /// </summary>
        /// <param name="Ad_Id"></param>
        /// <returns></returns>
        public AdvertisementInfo GetById(int Ad_Id)
        {
            AdvertisementInfo ad = new AdvertisementInfo();
            StringBuilder sql = new StringBuilder();
            sql.Append("select Ad_Id,image_url,title,Link_Url from BigDog_Advertisement where Ad_Id='" + Ad_Id + "'");
            DataTable dt = new DataTable();
            dt = OracleHelper.GetDS(sql.ToString()).Tables[0];
            if (dt.Rows.Count > 0)
            {
                ad.Id = Convert.ToInt32(dt.Rows[0][0]);
                ad.Image_Url = dt.Rows[0][1].ToString();
                ad.Title = dt.Rows[0][2].ToString();
                ad.Link_Url = dt.Rows[0][3].ToString();
                return ad;
            }
            else
            {
                ad = null;
                return ad;
            }

        }

        /// <summary>
        /// 关键词搜索
        /// </summary>
        /// <param name="keywords">关键词</param>
        /// <param name="type">类型</param>
        /// <param name="enabled">是否可用</param>
        /// <returns></returns>
        public DataTable GetItemsBySearchCase(string keywords,string type,string enabled)
        {
            StringBuilder sql = new StringBuilder();
            sql.Append("select a.Ad_Id,a.Image_Url,a.Title,a.Link_Url,a.Enabled,b.Meaning from BigDog_Advertisement a,BigDog_Parameters b where a.Type_Id=b.Type_Id");
            if (!string.IsNullOrEmpty(keywords))
            {
                sql.Append(" and a.Title like '%" + keywords + "%'");
            }
            if(!string.IsNullOrEmpty(type))
            {
                sql.Append(" and a.Type_Id='" + type + "'");
            }
            if (!string.IsNullOrEmpty(enabled))
            {
                sql.Append(" and a.Enabled='" + enabled + "'");
            }
            return OracleHelper.GetDS(sql.ToString()).Tables[0];
        }

        /// <summary>
        /// 返回广告数据集
        /// </summary>
        /// <returns></returns>
        public DataTable GetAllAdvertisement()
        {
            StringBuilder sql = new StringBuilder();
            sql.Append("select a.Ad_Id,a.Image_Url,a.Title,a.Link_Url,a.Enabled,b.Meaning from BigDog_Advertisement a,BigDog_Parameters b where a.Type_Id=b.Type_Id");
            return OracleHelper.GetDS(sql.ToString()).Tables[0];
        }


    }

}
