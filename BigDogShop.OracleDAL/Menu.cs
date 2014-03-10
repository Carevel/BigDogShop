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
            sql.Append("insert into Menu(Id,MenuName,MenuFatherId,Published,PreferedId,Prefered,Link,Created_Date,Creator)");
            sql.Append("values(treemenu_seq.nextval,@MenuFatherId,@Published,@PreferedId,@Prefered,@Link,@Created_Date,@Creator)");
            OleDbParameter[] parms = new OleDbParameter[] {
                new OleDbParameter("@MenuFatherId",OleDbType.Integer),
                new OleDbParameter("@Published",OleDbType.VarChar,20),
                new OleDbParameter("@PreferedId",OleDbType.Integer),
                new OleDbParameter("@Link",OleDbType.VarChar,100),
                new OleDbParameter("@Created_Date",OleDbType.Date),
                new OleDbParameter("@Creator",OleDbType.Date)
            };
            return OracleHelper.ExecuteNonQuery(CommandType.Text, sql.ToString(), parms) > 0;
        }

        /// <summary>
        /// 判断是否有子菜单
        /// </summary>
        /// <param name="id"></param>
        public bool checkChild(int id)
        {
            StringBuilder sql = new StringBuilder();
            sql.Append("select count(*) from Menu where MenuFatherId='" + id + "'");
            return OracleHelper.ExecuteNonQuery(CommandType.Text, sql.ToString(), null) > 0;
        }

        /// <summary>
        /// 根据ID删除菜单
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool Delete(int id)
        {
            StringBuilder sql = new StringBuilder();
            sql.Append("delete from Menu where Id='" + id + "'");
            return OracleHelper.ExecuteNonQuery(CommandType.Text, sql.ToString(), null) > 0;
        }

        public MenuInfo GetById(int id)
        {
            MenuInfo menu = new MenuInfo();
            StringBuilder sql = new StringBuilder();
            sql.Append("Select Menu_Id,Menu_Name,Menu_Father_Id,Published,PreferedId,Prefered");
            return menu;
        }

        public bool Update(MenuInfo menu)
        {
            StringBuilder sql = new StringBuilder();
            sql.Append("insert into Menu(Id,MenuName,MenuFatherId,Published,PreferedId,Prefered,Link,Created_Date,Creator)");
            sql.Append("values(treemenu_seq.nextval,@MenuFatherId,@Published,@PreferedId,@Prefered,@Link,@Created_Date,@Creator)");

            OleDbParameter[] parms = new OleDbParameter[] {
                new OleDbParameter("@MenuFatherId",OleDbType.Integer),
                new OleDbParameter("@Published",OleDbType.VarChar,20),
                new OleDbParameter("@PreferedId",OleDbType.Integer),
                new OleDbParameter("@Link",OleDbType.VarChar,100),
                new OleDbParameter("@Created_Date",OleDbType.Date),
                new OleDbParameter("@Creator",OleDbType.Date)
            };
            return OracleHelper.ExecuteNonQuery(CommandType.Text, sql.ToString(), parms) > 0;
        }

        public DataTable GetPreferedItems()
        {
            StringBuilder sql = new StringBuilder();
            sql.Append("select Id,MenuName,MenuFatherId,Published,PreferedId,Prefered,Link from Menu where Prefered='Y'");
            DataTable dt = OracleHelper.GetDS(sql.ToString()).Tables[0];
            return dt;
        }
        /// <summary>
        /// 获取菜单列表数据集
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public DataTable GetMenuList()
        {
            StringBuilder sql = new StringBuilder();
            sql.Append("select Menu_Id,Menu_Name,Menu_Father_Id,Link_Url from BigDog_Menu");
            DataTable dt = OracleHelper.GetDS(sql.ToString()).Tables[0];
            return dt;
        }
    }
}
