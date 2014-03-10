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
    public class Advertisement
    {
        /// <summary>
        /// 增加一个广告
        /// </summary>
        /// <param name="ad"></param>
        /// <returns></returns>
        public bool Insert(AdvertisementInfo ad)
        {
            StringBuilder sql = new StringBuilder();
            sql.Append("insert into [Advertisement](Title,AdImgUrl,LinkUrl,CreatedDate,CreatedBy)");
            sql.Append("values(@Title,@AdImgUrl,@LinkUrl,@CreatedDate,@CreatedBy)");
            SqlParameter[] parms = new SqlParameter[] {
                new SqlParameter("@Title",SqlDbType.NVarChar,50),
                new SqlParameter("@AdImgUrl",SqlDbType.NVarChar,100),
                new SqlParameter("@LinkUrl",SqlDbType.NVarChar,100),
                new SqlParameter("@CreatedDate",SqlDbType.DateTime),
                new SqlParameter("@CreatedBy",SqlDbType.NVarChar,20)
            };
            parms[0].Value = ad.Title;
            parms[1].Value = ad.Image_Url;
            parms[2].Value = ad.Link_Url;
            parms[3].Value = ad.Created_Date;
            parms[4].Value = ad.Created_By;
            int val = SQLHelper.ExecuteNonQuery(CommandType.Text, sql.ToString(), parms);
            return val > 0;
        }

        /// <summary>
        /// 根据id删除广告
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool Delete(int id)
        {
            StringBuilder sql = new StringBuilder();
            sql.Append("delete from [Advertisement] where id=@Id");
            SqlParameter[] parms = new SqlParameter[]{ 
                new SqlParameter("@Id",SqlDbType.Int)
            };
            parms[0].Value = id;
            return SQLHelper.ExecuteNonQuery(CommandType.Text, sql.ToString(), parms) > 0;
        }

        /// <summary>
        /// 更新广告实体
        /// </summary>
        /// <param name="ad"></param>
        /// <returns></returns>
        public bool Update(AdvertisementInfo ad)
        {
            StringBuilder sql = new StringBuilder();
            sql.Append("update [Advertisement] set Title=@Title and AdImgUrl=@AdImgUrl and LinkUrl=@LinkUrl and UpdatedDate=@UpdatedDate and UpdatedBy=@UpdatedBy");
            sql.Append(" where Id=@Id");
            SqlParameter[] parms = new SqlParameter[] {
                new SqlParameter("@Title",SqlDbType.NVarChar,50),
                new SqlParameter("@AdImgUrl",SqlDbType.NVarChar,100),
                new SqlParameter("@LinkUrl",SqlDbType.NVarChar,100),
                new SqlParameter("@UpdatedDate",SqlDbType.DateTime),
                new SqlParameter("@UpdatedBy",SqlDbType.NVarChar,20)
            };
            parms[0].Value = ad.Title;
            parms[1].Value = ad.Image_Url;
            parms[2].Value = ad.Link_Url;
            parms[3].Value = ad.Updated_Date;
            parms[4].Value = ad.Updated_By;
            int val = SQLHelper.ExecuteNonQuery(CommandType.Text, sql.ToString(), parms);
            return val > 0;
        }

        /// <summary>
        /// 获取所有广告
        /// </summary>
        /// <returns></returns>
        //public IList<AdvertisementInfo> GetAllAdvertisement()
        //{
        //    IList<AdvertisementInfo> items = new List<AdvertisementInfo>();
        //    StringBuilder sql = new StringBuilder();
        //    sql.Append("select Id,Title,AdImgUrl,LinkUrl from [Advertisement] ");
        //    SqlDataReader dr = SQLHelper.ExecuteReader(CommandType.Text, sql.ToString(), null);
        //    while (dr.Read())
        //    {
        //        AdvertisementInfo item = new AdvertisementInfo(dr.GetString(1), dr.GetString(2), dr.GetString(3));
        //        items.Add(item);
        //    }
        //    return items;
        //}
    }
}
