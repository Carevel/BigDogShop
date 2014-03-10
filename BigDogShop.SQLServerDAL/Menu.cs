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
    public class Menu : IMenu
    {
        /// <summary>
        /// 添加菜单
        /// </summary>
        /// <param name="menu"></param>
        /// <returns></returns>
        public bool Add(MenuInfo menu)
        {
            StringBuilder sql = new StringBuilder();
            sql.Append("insert into BigDog_Menu(Menu_Name,Father_Id,Link_Url)");
            sql.Append("values(@Menu_Name,@Father_Id,@Link_Url)");
            SqlParameter[] parms = new SqlParameter[] {
                new SqlParameter("@Menu_Name",SqlDbType.NVarChar,50),
                new SqlParameter("@Father_Id",SqlDbType.Int),
                new SqlParameter("@Link_Url",SqlDbType.NVarChar,200),
            };
            return SQLHelper.ExecuteNonQuery(CommandType.Text, sql.ToString(), parms) > 0;
        }

        /// <summary>
        /// 根据ID删除菜单
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool Delete(int id)
        {
            StringBuilder sql = new StringBuilder();
            sql.Append("delete from BigDog_Menu where Id=@Id");
            SqlParameter[] parms = new SqlParameter[] { 
                new SqlParameter("@Id",SqlDbType.Int)
            };
            parms[0].Value = id;
            return SQLHelper.ExecuteNonQuery(CommandType.Text, sql.ToString(), parms) > 0;
        }

        /// <summary>
        /// 更新菜单实体
        /// </summary>
        /// <param name="menu"></param>
        /// <returns></returns>
        public bool Update(MenuInfo menu)
        {
            StringBuilder sql = new StringBuilder();
            sql.Append("upate BigDog_Menu set Menu_Name=@Menu_Name,Father_Id=@Father_Id,Link_Url=@Link_Url,Description=@Description");
            sql.Append(" where Id=@Id");
            SqlParameter[] parms = new SqlParameter[] {
                new SqlParameter("@Menu_Name",SqlDbType.Int), 
                new SqlParameter("@Father_Id",SqlDbType.VarChar,100),
                new SqlParameter("@Link_Url",SqlDbType.Date),
                new SqlParameter("@Description",SqlDbType.Date)
            };
            parms[0].Value = menu.Menu_Name;
            parms[1].Value = menu.Father_Id;
            parms[2].Value = menu.Link_Url;
            parms[3].Value = menu.Description;
            return SQLHelper.ExecuteNonQuery(CommandType.Text, sql.ToString(), parms) > 0;
        }

        /// <summary>
        ///根据Id获取菜单实体
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public MenuInfo GetById(int id)
        {
            MenuInfo menu = new MenuInfo();
            StringBuilder sql = new StringBuilder();
            sql.Append("select Id,Menu_Name,Father_Id,Link_Url,Description from BigDog_Menu");
            sql.Append(" where Id=@Id");
            SqlParameter[] parms = new SqlParameter[] { 
                new SqlParameter("@Id",SqlDbType.Int)
            };
            parms[0].Value = id;
            DataTable dt = new DataTable();
            dt = SQLHelper.GetDs(sql.ToString(),parms).Tables[0];
            if (dt.Rows.Count > 0)
            {
                menu.Id = Convert.ToInt32(dt.Rows[0]["Id"]);
                menu.Menu_Name = dt.Rows[0]["Menu_Name"].ToString();
                menu.Father_Id = Convert.ToInt32(dt.Rows[0]["Father_Id"].ToString());
                menu.Link_Url = dt.Rows[0]["Link_Url"].ToString();
                menu.Description = dt.Rows[0]["Description"].ToString();
                return menu;
            }
            return null;
        }

        /// <summary>
        /// 获取菜单列表数据集
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public DataTable GetMenuList()
        {
            StringBuilder sql = new StringBuilder();
            sql.Append("select Id,Menu_Name,Father_Id,Link_Url from BigDog_Menu");
            DataTable dt = SQLHelper.GetDs(sql.ToString()).Tables[0];
            return dt;
        }
    }
}
