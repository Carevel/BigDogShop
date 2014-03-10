using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Xml;
using System.Collections;
using System.Web.UI.WebControls;
using System.Web;
using System.IO;
using System.Web.UI.HtmlControls;

namespace BigDogShop.DBUtility
{
    public class SQLHelper
    {
        /// <summary>
        /// 連接字符串
        /// </summary>
        public static string ConnString = ConfigurationManager.ConnectionStrings["SQL_Link"].ConnectionString;
        private static Hashtable parmCache = Hashtable.Synchronized(new Hashtable());
        public static SqlDataAdapter rdr;

        public static object GetCValue(string sql, int i)
        {
            object va = SQLHelper.ExecuteScalar(SQLHelper.ConnString, CommandType.Text, sql, null);
            return va;

        }

        #region 执行简单的SQL语句

        /// <summary>
        /// 执行SQL语句,返回受影响的行数
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public static int ExeSQL(string sql)
        {
            using (SqlConnection conn = new SqlConnection(ConnString))
            {
                SqlCommand cmd = new SqlCommand(sql, conn);
                conn.Open();
                int val = 0;
                try
                {
                    val = cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    conn.Close();
                    val = -1;
                    throw new Exception(ex.Message);
                }
                finally
                {
                    conn.Close();
                }
                return val;
            }
        }

        /// 执行简单的Sql语句,返回DataSet
        /// </summary>
        /// <param name="connectionString"></param>
        /// <param name="SQLString"></param>
        /// <returns></returns>
        public static DataSet Query(string connectionString, string SQLString)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                DataSet ds = new DataSet();
                try
                {
                    connection.Open();
                    SqlDataAdapter command = new SqlDataAdapter(SQLString, connection);
                    command.Fill(ds, "ds");
                }
                catch (SqlException ex)
                {
                    throw new Exception(ex.Message);
                }
                finally
                {
                    if (connection.State != ConnectionState.Closed)
                    {
                        connection.Close();
                    }
                }
                return ds;
            }
        }

        /// <summary>
        /// 执行简单的Sql语句,返回DataSet
        /// </summary>
        /// <param name="SQLString"></param>
        /// <returns></returns>
        public static DataSet GetDs(string SQLString)
        {
            using (SqlConnection connection = new SqlConnection(ConnString))
            {
                DataSet ds = new DataSet();
                try
                {
                    connection.Open();
                    SqlDataAdapter command = new SqlDataAdapter(SQLString, connection);
                    command.Fill(ds, "ds");
                }
                catch (SqlException ex)
                {
                    ds = null;
                    throw new Exception(ex.Message);
                }
                finally
                {
                    if (connection.State != ConnectionState.Closed)
                    {
                        connection.Close();
                    }
                }
                return ds;
            }
        }

        #endregion

        #region 执行带参数的Sql语句

        /// <summary>
        /// 針對需要賦值的SQL語句進行參數初始化
        /// </summary>
        /// <param name="cmd"></param>
        /// <param name="conn"></param>
        /// <param name="trans"></param>
        /// <param name="cmdType"></param>
        /// <param name="cmdText"></param>
        /// <param name="commandParameters"></param>
        public static void PrepareCommand(SqlCommand cmd, SqlConnection conn, SqlTransaction trans, CommandType cmdType, string cmdText, SqlParameter[] commandParameters)
        {

            if (conn.State != ConnectionState.Open)
            {
                conn.Open();
            }
            cmd.Connection = conn;
            cmd.CommandText = cmdText;
            cmd.CommandType = cmdType;
            if (trans != null)
                cmd.Transaction = trans;
            if (commandParameters != null)
            {
                foreach (SqlParameter parm in commandParameters)
                {
                    cmd.Parameters.Add(parm);
                }
            }
        }

        /// <summary>
        /// 針對需要賦值的SQL語句進行參數初始化
        /// </summary>
        /// <param name="cmd"></param>
        /// <param name="cmdType"></param>
        /// <param name="cmdText"></param>
        /// <param name="commandParameters"></param>
        public static void PrepareCommand(SqlCommand cmd, CommandType cmdType, string cmdText, SqlParameter[] commandParameters)
        {
            cmd.Parameters.Clear();
            cmd.CommandText = cmdText;
            cmd.CommandType = cmdType;
            if (commandParameters != null)
            {
                foreach (SqlParameter parm in commandParameters)
                {
                    cmd.Parameters.Add(parm);
                }
            }
        }

        /// <summary>
        /// 執行SQL語句，返回所影響的資料列數。
        /// </summary>
        /// <param name="connectionString">數據連接字符</param>
        /// <param name="cmdType">操作的類型</param>
        /// <param name="cmdText">SQL語句</param>
        /// <param name="commandParameters">參數列表</param>
        /// <returns></returns>
        public static int ExecuteNonQuery(string connectionString, CommandType cmdType, string cmdText, params SqlParameter[] commandParameters)
        {
            SqlCommand cmd = new SqlCommand();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                PrepareCommand(cmd, connection, null, cmdType, cmdText, commandParameters);
                string aa = cmd.CommandText;
                int val = cmd.ExecuteNonQuery();
                cmd.Parameters.Clear();
                return val;
            }
        }

        /// <summary>
        /// 執行SQL語句，返回所影響的資料列數。
        /// </summary>
        /// <param name="connectionString">數據連接字符</param>
        /// <param name="cmdType">操作的類型</param>
        /// <param name="cmdText">SQL語句</param>
        /// <param name="commandParameters">參數列表</param>
        /// <returns></returns>
        public static int ExecuteNonQuery(CommandType cmdType, string cmdText, params SqlParameter[] commandParameters)
        {
            SqlCommand cmd = new SqlCommand();
            using (SqlConnection connection = new SqlConnection(ConnString))
            {
                PrepareCommand(cmd, connection, null, cmdType, cmdText, commandParameters);
                string aa = cmdText;
                int val = cmd.ExecuteNonQuery();
                cmd.Parameters.Clear();
                return val;
            }
        }
        /// <summary>
        /// 获取数据集
        /// </summary>
        /// <param name="connectionString"></param>
        /// <param name="cmdType"></param>
        /// <param name="cmdText"></param>
        /// <param name="commandParameters"></param>
        /// <returns></returns>
        public static SqlDataReader ExecuteReader(string connectionString, CommandType cmdType, string cmdText, params SqlParameter[] commandParameters)
        {

            //Create the command and connection
            SqlCommand cmd = new SqlCommand();
            SqlConnection conn = new SqlConnection(connectionString);
            try
            {
                PrepareCommand(cmd, conn, null, cmdType, cmdText, commandParameters);
                SqlDataReader rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                cmd.Parameters.Clear();
                return rdr;
            }
            catch
            {
                conn.Close();
                throw;
            }
            finally
            {
                conn.Close();
            }
        }

        /// <summary>
        /// 執行SQL事務，返回所影響的資料列數。
        /// </summary>
        /// <param name="connectionString">SQL事務</param>
        /// <param name="cmdType">操作的類型</param>
        /// <param name="cmdText">SQL語句</param>
        /// <param name="commandParameters">參數列表</param>
        /// <returns></returns>
        public static int ExecuteNonQuery(SqlTransaction trans, CommandType cmdType, string cmdText, params SqlParameter[] commandParameters)
        {
            SqlCommand cmd = new SqlCommand();
            PrepareCommand(cmd, trans.Connection, trans, cmdType, cmdText, commandParameters);
            int val = cmd.ExecuteNonQuery();
            cmd.Parameters.Clear();
            return val;
        }

        /// <summary>
        /// 返回第一行第一列值(object对象类型)
        /// </summary>
        /// <param name="cmdType"></param>
        /// <param name="cmdText"></param>
        /// <param name="commandParameters"></param>
        /// <returns></returns>
        public static object ExecuteScalar(CommandType cmdType, string cmdText, params SqlParameter[] commandParameters)
        {
            SqlCommand cmd = new SqlCommand();
            using (SqlConnection connection = new SqlConnection(ConnString))
            {
                PrepareCommand(cmd, connection, null, cmdType, cmdText, commandParameters);
                object val = cmd.ExecuteScalar();
                cmd.Parameters.Clear();
                return val;
            }
        }

        /// <summary>
        /// 執行SQL語句，返回指定資料列的值。
        /// </summary>
        /// <param name="connectionString"></param>
        /// <param name="cmdType"></param>
        /// <param name="cmdText"></param>
        /// <param name="commandParameters"></param>
        /// <returns></returns>
        public static object ExecuteScalar(string connectionString, CommandType cmdType, string cmdText, params SqlParameter[] commandParameters)
        {
            SqlCommand cmd = new SqlCommand();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                PrepareCommand(cmd, conn, null, cmdType, cmdText, commandParameters);
                object val = cmd.ExecuteScalar();
                cmd.Parameters.Clear();
                return val;
            }
        }

        /// <summary>
        /// 執行SQL事務，返回指定資料列的值。
        /// </summary>
        /// <param name="connectionString"></param>
        /// <param name="cmdType"></param>
        /// <param name="cmdText"></param>
        /// <param name="commandParameters"></param>
        /// <returns></returns>
        public static object ExecuteScalar(SqlTransaction transaction, CommandType commandType, string commandText, params SqlParameter[] commandParameters)
        {
            if (transaction == null)
                throw new ArgumentNullException("transaction");
            if (transaction != null && transaction.Connection == null)
                throw new ArgumentException("The transaction was rollbacked	or commited, please	provide	an open	transaction.", "transaction");
            SqlCommand cmd = new SqlCommand();
            PrepareCommand(cmd, transaction.Connection, transaction, commandType, commandText, commandParameters);
            object retval = cmd.ExecuteScalar();
            cmd.Parameters.Clear();
            return retval;
        }

        /// <summary>
        /// 執行SQL語句，返回指定資料列的值。
        /// </summary>
        /// <param name="connectionString"></param>
        /// <param name="cmdType"></param>
        /// <param name="cmdText"></param>
        /// <param name="commandParameters"></param>
        /// <returns></returns>
        public static object ExecuteScalar(SqlConnection connectionString, CommandType cmdType, string cmdText, params SqlParameter[] commandParameters)
        {
            SqlCommand cmd = new SqlCommand();

            PrepareCommand(cmd, connectionString, null, cmdType, cmdText, commandParameters);
            object val = cmd.ExecuteScalar();
            cmd.Parameters.Clear();
            return val;
        }

        /// <summary>
        /// 执行带参数的sql语句,返回受影响的行数
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="parameters"></param>
        /// <param name="cmdType"></param>
        /// <returns></returns>
        public static int ExecuteSql(string sql, SqlParameter[] parameters, CommandType cmdType)
        {
            int i = 0;
            try
            {
                SqlConnection con = new SqlConnection(ConnString);
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.CommandType = cmdType;
                if (parameters != null)
                {
                    cmd.Parameters.AddRange(parameters);
                }
                i = cmd.ExecuteNonQuery();
                cmd.Dispose();

            }
            catch (Exception ex)
            {
                i = 0;
                throw new Exception(ex.Message);
            }
            return i;
        }

        /// <summary>
        /// 执行带参数的Sql语句,返回DataSet数据集
        /// </summary>
        /// <param name="sqlstring"></param>
        /// <param name="cmdParms"></param>
        /// <returns></returns>
        public static DataSet GetDs(string sqlstring, params SqlParameter[] cmdParms)
        {
            using (SqlConnection connection = new SqlConnection(ConnString))
            {
                DataSet ds = new DataSet();
                try
                {
                    SqlCommand cmd = new SqlCommand();
                    PrepareCommand(cmd, connection, null,CommandType.Text, sqlstring.ToString(), cmdParms);
                    SqlDataAdapter sda = new SqlDataAdapter(cmd);
                    sda.Fill(ds, "ds");
                    cmd.Parameters.Clear();
                }
                catch (SqlException ex)
                {
                    ds = null;
                    throw new Exception(ex.Message);
                }
                finally
                {
                    if (connection.State != ConnectionState.Closed)
                    {
                        connection.Close();
                    }
                }
                return ds;
            }
        }


        #endregion


        /// <summary>
        /// 獲取參數
        /// </summary>
        /// <param name="cacheKey"></param>
        /// <returns></returns>
        public static SqlParameter[] GetCachedParameters(string cacheKey)
        {
            SqlParameter[] cachedParms = (SqlParameter[])parmCache[cacheKey];
            if (cachedParms == null)
            {
                return null;
            }
            SqlParameter[] clonedParms = new SqlParameter[cachedParms.Length];
            for (int i = 0, j = cachedParms.Length; i < j; i++)
            {
                clonedParms[i] = (SqlParameter)((ICloneable)cachedParms[i]).Clone();
            }
            return clonedParms;
        }

        /// <summary>
        /// 緩存參數列表
        /// </summary>
        /// <param name="cacheKey"></param>
        /// <param name="commandParameters"></param>
        public static void CacheParameters(string cacheKey, params SqlParameter[] commandParameters)
        {
            parmCache[cacheKey] = commandParameters;
        }


        public static void SetDDL(string sql, DropDownList ddl, int i)
        {
            DataSet ds = new DataSet();
            using (SqlConnection conn = new SqlConnection(ConnString))
            {
                SqlDataAdapter adp = new SqlDataAdapter(sql, conn);
                try
                {
                    conn.Open();
                    ds.Clear();
                    adp.Fill(ds);
                    ddl.DataSource = new DataView(ds.Tables[0]);
                    ddl.DataTextField = "f2";
                    ddl.DataValueField = "f1";
                    ddl.DataBind();
                    switch (i)
                    {
                        case 1:
                            ddl.Items.Add("ALL");
                            ddl.SelectedValue = "ALL";
                            break;
                        case 2:
                            ddl.Items.Add("");
                            ddl.SelectedValue = "";
                            break;
                        case 3:
                            ddl.Items.Add("NULL");
                            ddl.SelectedValue = "NULL";
                            break;
                        default:
                            conn.Close();
                            break;
                    }

                }
                catch (SqlException ex)
                {
                    throw new Exception(ex.Message);
                }
                finally
                {
                    conn.Close();
                }
            }
        }

        #region   执行存储过程操作

        /// <summary>
        /// 执行SQL存储过程
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public static int ExePro(string sql)
        {
            using (SqlConnection conn = new SqlConnection(ConnString))
            {
                SqlCommand cmd = new SqlCommand(sql, conn);
                conn.Open();
                int val = 0;
                try
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    val = cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    conn.Close();
                    val = -1;
                    throw new Exception(ex.Message);
                }
                finally
                {
                    conn.Close();
                }
                return val;
            }
        }

        /// <summary>
        /// 初始化SqlCommand对象,存储过程
        /// </summary>
        /// <param name="connection"></param>
        /// <param name="storedProcName"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        protected static SqlCommand PrepareProcCommand(SqlConnection connection, string storedProcName, IDataParameter[] parameters)
        {
            SqlCommand command = new SqlCommand(storedProcName, connection);
            command.CommandType = CommandType.StoredProcedure;
            foreach (SqlParameter parameter in parameters)
            {
                if (parameter != null)
                {
                    if (parameter.Value == null && parameter.Direction == ParameterDirection.InputOutput || parameter.Direction == ParameterDirection.Input)
                    {
                        parameter.Value = DBNull.Value;
                    }
                    command.Parameters.Add(parameter);
                }
            }
            return command;
        }

        /// <summary>
        /// 执行带参数的存储过程操作,返回SqlDateReader
        /// </summary>
        /// <param name="storedProcName"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public static SqlDataReader ExecuteProcedure(string storedProcName, IDataParameter[] parameters)
        {
            SqlConnection conn = new SqlConnection(ConnString);
            SqlDataReader sdr;
            conn.Open();
            SqlCommand cmd = PrepareProcCommand(conn,storedProcName, parameters);
            cmd.CommandType = CommandType.StoredProcedure;
            sdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
            return sdr;
        }

        #endregion

        public static string GetNumStr(string in_val)
        {
            string val = "";
            int count = 0;
            int length = in_val.Length;
            int dot = in_val.IndexOf(".");
            if (dot >= 0)
            {
                count = in_val.Substring(dot + 1).Length;
            }
            else
            {
                count = 0;
            }
            val = Convert.ToDouble(in_val).ToString("n" + count.ToString());
            return val;
        }


       
    }
}
