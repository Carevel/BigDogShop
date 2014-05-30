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
    public class Product : IProduct
    {
        /// <summary>
        /// 添加一条数据
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool Add(ProductInfo model)
        {
            StringBuilder sql = new StringBuilder();
            sql.Append("insert into BigDog_Product(product_id,product_name,product_no,provider_id,product_type_id,product_origin,");
            sql.Append("sales_count,description,rank,price,promote_price,memeber_price,vip_price,stock,product_image_id,extra_property,status)");
            sql.Append("values(@Product_Id,@Product_Name,@Product_No,@Provider_Id,@Product_Type_Id,@Product_Origin,@Salses_Count,@Description,@Rank,@Price,");
            sql.Append("@Promote_Price,@Member_Price,@Vip_Price,@Stock,@Product_Image_Id,@Extra_Property,@Status)");
            SqlParameter[] parms = new SqlParameter[] {
                new SqlParameter("@Product_Name",SqlDbType.NVarChar,50),
                new SqlParameter("@Product_No",SqlDbType.Int),
                new SqlParameter("@Provider_Id",SqlDbType.Int),
                new SqlParameter("@Product_Type_Id",SqlDbType.Int),
                new SqlParameter("@Product_Origin",SqlDbType.NVarChar,200),
                new SqlParameter("@Salses_Count",SqlDbType.Int),
                new SqlParameter("@Rank",SqlDbType.Int),
                new SqlParameter("@Price",SqlDbType.Float),
                new SqlParameter("@Promote_Price",SqlDbType.Float),
                new SqlParameter("@Member_Price",SqlDbType.Float),
                new SqlParameter("@Vip_Price",SqlDbType.Float),
                new SqlParameter("@Stock",SqlDbType.Int),
                new SqlParameter("@Product_Image_Id",SqlDbType.Int),
                new SqlParameter("@Extra_Property_Id",SqlDbType.Int),
                new SqlParameter("@Status",SqlDbType.NVarChar,1)
            };
            parms[0].Value = model.Product_Name;
            parms[1].Value = model.Product_No;
            parms[2].Value = model.Provider_Id;
            parms[3].Value = model.Product_Type_Id;
            parms[4].Value = model.Product_Origin;
            parms[5].Value = model.Sales_Count;
            parms[6].Value = model.Rank;
            parms[7].Value = model.Price;
            parms[8].Value = model.Promote_Price;
            parms[9].Value = model.Member_Price;
            parms[10].Value = model.Vip_Price;
            parms[11].Value = model.Stock;
            parms[12].Value = model.Product_Image_Id;
            parms[13].Value = model.Extra_Property_Id;
            parms[14].Value = model.Status;

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
            sql.Append("delete from BigDog_Product where Id=@Id");
            SqlParameter[] parms = new SqlParameter[] {
                new SqlParameter("@Id",SqlDbType.Int)
            };
            parms[0].Value = id;
            return SQLHelper.ExecuteNonQuery(CommandType.Text, sql.ToString(), parms) > 0;
        }


        /// <summary>
        /// update model
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool Update(ProductInfo model)
        {
            StringBuilder sql = new StringBuilder();
            sql.Append("update BigDog_Product set Product_Name=@Product_Name,Product_No=@Product_No,Provider_Id=@Provider_Id,Product_Type_Id=@Product_Type_Id,");
            sql.Append(" Product_Origin=@Product_Origin,Sales_Count=@Sales_Count,Description=@Description,Rank=@Rank,Price=@Price,Promote_Price=@Promote_Price,Member_Price=@Member_price,");
            sql.Append(" Vip_Price=@Vip_Price,Stock=@Stock,Product_Image_Id=@Product_Image_Id,Extra_Property_Id=@Extra_Property_Id,Status=@Status where Id=@Id");
            SqlParameter[] parms = new SqlParameter[] {
                new SqlParameter("@Product_Name",SqlDbType.NVarChar,50),
                new SqlParameter("@Product_No",SqlDbType.Int),
                new SqlParameter("@Provider_Id",SqlDbType.Int),
                new SqlParameter("@Product_Type_Id",SqlDbType.Int),
                new SqlParameter("@Product_Origin",SqlDbType.NVarChar,200),
                new SqlParameter("@Salses_Count",SqlDbType.Int),
                new SqlParameter("@Rank",SqlDbType.Int),
                new SqlParameter("@Price",SqlDbType.Float),
                new SqlParameter("@Promote_Price",SqlDbType.Float),
                new SqlParameter("@Member_Price",SqlDbType.Float),
                new SqlParameter("@Vip_Price",SqlDbType.Float),
                new SqlParameter("@Stock",SqlDbType.Int),
                new SqlParameter("@Product_Image_Id",SqlDbType.Int),
                new SqlParameter("@Extra_Property_Id",SqlDbType.Int),
                new SqlParameter("@Status",SqlDbType.NVarChar,1),
                new SqlParameter("@Id",SqlDbType.Int)
            };
            parms[0].Value = model.Product_Name;
            parms[1].Value = model.Product_No;
            parms[2].Value = model.Provider_Id;
            parms[3].Value = model.Product_Type_Id;
            parms[4].Value = model.Product_Origin;
            parms[5].Value = model.Sales_Count;
            parms[6].Value = model.Rank;
            parms[7].Value = model.Price;
            parms[8].Value = model.Promote_Price;
            parms[9].Value = model.Member_Price;
            parms[10].Value = model.Vip_Price;
            parms[11].Value = model.Stock;
            parms[12].Value = model.Product_Image_Id;
            parms[13].Value = model.Extra_Property_Id;
            parms[14].Value = model.Status;
            parms[15].Value = model.Id;

            return SQLHelper.ExecuteNonQuery(CommandType.Text, sql.ToString(), parms) > 0;
        }

        /// <summary>
        /// 根据Id获取实体
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ProductInfo GetById(int id)
        {
            StringBuilder sql = new StringBuilder();
            sql.Append("select Product_Name,Product_No,Provider_Id,Product_Type_Id,Product_Origin,Sales_Count,Description");
            sql.Append("Rank,Price,Promote_Price,Member_Price,Vip_Price,Stock,Product_Image_Id,Extra_Property_Id,Status");
            sql.Append(" from BigDog_Product where Id=@Id");
            SqlParameter[] parms = new SqlParameter[] { 
                new SqlParameter("@Id",SqlDbType.Int)
            };
            parms[0].Value = id;
            DataTable dt = SQLHelper.GetDs(sql.ToString(), parms).Tables[0];
            ProductInfo model = new ProductInfo();
            if (dt.Rows.Count > 0)
            {
                model.Id = Convert.ToInt32(dt.Rows[0]["Id"]);
                model.Product_Name = dt.Rows[0]["Product_Name"].ToString();
                model.Product_No = Convert.ToInt32(dt.Rows[0]["Product_No"].ToString());
                model.Provider_Id = Convert.ToInt32(dt.Rows[0]["Provider_Id"].ToString());
                model.Product_Type_Id = Convert.ToInt32(dt.Rows[0]["Product_Type_Id"].ToString());
                model.Product_Origin = dt.Rows[0]["Product_Origin"].ToString();
                model.Sales_Count = Convert.ToInt32(dt.Rows[0]["Salses_Count"]);
                model.Description = dt.Rows[0]["Description"].ToString();
                model.Rank = Convert.ToInt32(dt.Rows[0]["Rank"].ToString());
                model.Price = Convert.ToDecimal(dt.Rows[0]["Price"].ToString());
                model.Promote_Price = Convert.ToDecimal(dt.Rows[0]["Promote_Price"].ToString());
                model.Member_Price = Convert.ToDecimal(dt.Rows[0]["Member_Price"].ToString());
                model.Vip_Price = Convert.ToDecimal(dt.Rows[0]["Vip_Price"].ToString());
                model.Stock = Convert.ToInt32(dt.Rows[0]["Stock"].ToString());
                model.Product_Image_Id = Convert.ToInt32(dt.Rows[0]["Product_Image_Id"].ToString());
                model.Extra_Property_Id = Convert.ToInt32(dt.Rows[0]["Extra_Property_Id"].ToString());
                model.Status = dt.Rows[0]["Status"].ToString();
                return model;
            }
            return null;
        }

        /// <summary>
        /// 根据关键字获取数据集
        /// </summary>
        /// <param name="keywords"></param>
        /// <returns></returns>
        public DataTable GetBySearchKeywords(string keywords)
        {
            //string[] str=keywords.PadRight(' ').Split(new char[]{' '});
            StringBuilder sql = new StringBuilder();
            sql.Append("select Product_Name,Product_No,Provider_Id,Product_Type_Id,Product_Origin,Sales_Count,Description");
            sql.Append("Rank,Price,Promote_Price,Member_Price,Vip_Price,Stock,Product_Image_Id,Extra_Property_Id,Status");
            sql.Append(" from BigDog_Product where Product_Name like '%@Keywords%'");
            SqlParameter[] parms = new SqlParameter[] {
                new SqlParameter("@Keywords",SqlDbType.NVarChar,200)
            };
            parms[0].Value = keywords;
            DataTable dt = SQLHelper.GetDs(sql.ToString()).Tables[0];
            if (dt.Rows.Count > 0)
            {
                return dt;
            }
            return null;
        }

        /// <summary>
        /// 根据类型Id获取产品数据集
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public DataTable GetByCategory(int id)
        {
            StringBuilder sql = new StringBuilder();
            sql.Append("select Product_Name,Product_No,Provider_Id,Product_Type_Id,Product_Origin,Sales_Count,Description");
            sql.Append("Rank,Price,Promote_Price,Member_Price,Vip_Price,Stock,Product_Image_Id,Extra_Property_Id,Status");
            sql.Append(" from BigDog_Product where Product_Type_Id=@Id");
            SqlParameter[] parms = new SqlParameter[] {
                new SqlParameter("@Id",SqlDbType.Int)
            };
            parms[0].Value = id;
            DataTable dt = SQLHelper.GetDs(sql.ToString()).Tables[0];
            if (dt.Rows.Count > 0)
            {
                return dt;
            }
            return null;
        }

        /// <summary>
        /// 获取所有产品
        /// </summary>
        /// <returns></returns>
        public DataTable GetLists()
        {
            StringBuilder sql = new StringBuilder();
            sql.Append(" select Product_Name,Product_No,Provider_Id,Product_Type_Id,Product_Origin,Sales_Count,Description,");
            sql.Append(" Rank,Price,Promote_Price,Member_Price,Vip_Price,Stock,Product_Image_Id,Extra_Property_Id,Status");
            sql.Append(" from BigDog_Product ");
            DataTable dt = SQLHelper.GetDs(sql.ToString()).Tables[0];
            if (dt.Rows.Count > 0)
            {
                return dt;
            }
            return null;
        }
    }
}
