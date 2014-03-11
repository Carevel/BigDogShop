using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using BigDogShop.Model;
using BigDogShop.IDAL;
using BigDogShop.DBUtility;

namespace BigDogShop.SQLServerDAL
{
    public class ProductImages : IProductImages
    {
        public bool Add(ProductImageInfo model)
        {
            StringBuilder sql = new StringBuilder();
            sql.Append("insert into BigDog_Product_Images(Product_Image_Id,Category_Id,Image_Url,Link_Url,Description)");
            sql.Append("values(@Product_Image_Id,@Category_Id,@Image_Url,@Link_Url,@Description)");
            SqlParameter[] parms = new SqlParameter[]{
                new SqlParameter("@Product_Image_Id",SqlDbType.Int),
                new SqlParameter("@Category_Id",SqlDbType.Int), 
                new SqlParameter("@Image_Url",SqlDbType.NVarChar,200),
                new SqlParameter("@Link_Url",SqlDbType.NVarChar,200),
                new SqlParameter("@Description",SqlDbType.NVarChar,200)
            };
            parms[0].Value = model.Product_Image_Id;
            parms[1].Value = model.Category_Id;
            parms[2].Value = model.Image_Url;
            parms[3].Value = model.Link_Url;
            parms[4].Value = model.Description;

            return SQLHelper.ExecuteNonQuery(CommandType.Text, sql.ToString(), parms) > 0;
        }

        public bool Delete(int id)
        {
            StringBuilder sql = new StringBuilder();
            sql.Append("delete from BigDog_Product_Images where Id=@Id");
            SqlParameter[] parms = new SqlParameter[] {
                new SqlParameter("@Id",SqlDbType.Int)
            };
            parms[0].Value = id;
            return SQLHelper.ExecuteNonQuery(CommandType.Text, sql.ToString(), parms) > 0;
        }

        public bool Update(ProductImageInfo model)
        {
            StringBuilder sql = new StringBuilder();
            sql.Append("update BigDog_Product_Images set Product_Image_Id=@Product_Image_Id,Category_Id=@Category_Id,Image_Url=@Image_Url,");
            sql.Append(" Link_Url=@Link_Url,Description=@Description where Id=@Id");
            SqlParameter[] parms = new SqlParameter[] {
                new SqlParameter("@Product_Image_Id",SqlDbType.NVarChar,50),
                new SqlParameter("@Category_Id",SqlDbType.Int),
                new SqlParameter("@Image_Url",SqlDbType.Int),
                new SqlParameter("@Link_Url",SqlDbType.Int),
                new SqlParameter("@Description",SqlDbType.NVarChar,200)
              
            };
            parms[0].Value = model.Product_Image_Id;
            parms[1].Value = model.Category_Id;
            parms[2].Value = model.Image_Url;
            parms[3].Value = model.Link_Url;
            parms[4].Value = model.Description;
            parms[5].Value = model.Id;

            return SQLHelper.ExecuteNonQuery(CommandType.Text, sql.ToString(), parms) > 0;
        }

        public ProductImageInfo GetById(int id)
        {
            StringBuilder sql = new StringBuilder();
            sql.Append("select Id,Product_Image_Id,Category_Id,Image_Url,Link_Url,Description from BogDog_Product_Images");
            sql.Append(" where Id=@Id");
            SqlParameter[] parms = new SqlParameter[] {
                new SqlParameter("@Id",SqlDbType.Int)
            };
            parms[0].Value = id;
            DataTable dt = SQLHelper.GetDs(sql.ToString(), parms).Tables[0];
            ProductImageInfo model = new ProductImageInfo();
            if (dt.Rows.Count > 0)
            {
                model.Id = Convert.ToInt32(dt.Rows[0]["Id"]);
                model.Product_Image_Id = Convert.ToInt32(dt.Rows[0]["Product_Image_Id"]);
                model.Category_Id = Convert.ToInt32(dt.Rows[0]["Category_Id"]);
                model.Image_Url = dt.Rows[0]["Image_Url"].ToString();
                model.Link_Url = dt.Rows[0]["Link_Url"].ToString();
                model.Description = dt.Rows[0]["Description"].ToString();

                return model;
            }
            return null;
        }

        public DataTable GetByCategory(int id)
        {
            StringBuilder sql=new StringBuilder()
            sql.Append("select Id,Product_Image_Id,Category_Id,Image_Url,Link_Url,Description from BigDog_Product_Images")
            sql.Append(" where Category_Id=@Category_Id");
            SqlParameter[] parms = new SqlParameter[] {
                new SqlParameter("@Category_Id",SqlDbType.Int)
            };
            parms[0].Value = id;
            DataTable dt=SQLHelper.GetDs(sql.ToString(),parms).Tables[0];
            if(dt.Rows.Count>0)
            {
                return dt;
            }
            else{
                return null;
            }
        }

        public DataTable GetList()
        {
            StringBuilder sql=new StringBuilder();
            sql.Append("select Id,Product_Image_Id,Category_Id,Image_Url,Link_Url,Description from BigDog_Product_Images")
            DataTable dt=SQLHelper.GetDs(sql.ToString()).Tables[0];
            if(dt.Rows.Count>0)
            {
                return dt;
            }
            else{
                return null;
            }
        }
    }
}
