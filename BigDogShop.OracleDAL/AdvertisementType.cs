using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.OleDb;
using BigDogShop.IDAL;
using BigDogShop.Model;
using BigDogShop.DBUtility;
namespace BigDogShop
{
    public class AdvertisementType : IAdvertisementType
    {
        public bool Add(AdvertisementTypeInfo ad_Type)
        {
            StringBuilder sql = new StringBuilder();
            sql.Append(" insert into BigDog_Advertisement_Type(Ad_Id,Type_Name,Created_Date,Creator)");
            sql.Append(" values(@Ad_Id,@Type_Name,@Created_Date,@Creator)");
            OleDbParameter[] parms = new OleDbParameter[] {
                new OleDbParameter("@Ad_Id",OleDbType.Integer),
                new OleDbParameter("@Type_Name",OleDbType.VarChar,50),
                new OleDbParameter("@Created_Date",OleDbType.Date),
                new OleDbParameter("@Creator",OleDbType.VarChar,50)
            };
            return OracleHelper.ExecuteNonQuery(CommandType.Text, sql.ToString(), parms) > 0;
        }

        public bool Delete(int id)
        {
            StringBuilder sql = new StringBuilder();
            sql.Append("delete from BigDog_Advertisement_Type where Ad_Id='" + id + "'");
            return OracleHelper.ExecuteNonQuery(CommandType.Text, sql.ToString(), null) > 0;
        }

        public bool Update(AdvertisementTypeInfo ad_Type)
        {
            StringBuilder sql = new StringBuilder();
            sql.Append(" update BigDog_Advertisement_Type");
            return true;
        }

        public AdvertisementTypeInfo GetById(int id)
        {
            AdvertisementTypeInfo ad_type = new AdvertisementTypeInfo();
            return ad_type;
        }

        public DataTable GetByCategory(string category)
        {
            DataTable dt = new DataTable();
            return dt;
        }

        public DataTable GetAllItems()
        {
            DataTable dt = new DataTable();
            return dt;
        }
    }
}
