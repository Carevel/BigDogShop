using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OleDb;
using System.Data;
using System.Collections;
using System.Web.UI.WebControls;
using System.Web;
using System.Xml;
using System.IO;
using System.Web.UI.HtmlControls;
using System.Configuration;

namespace BigDogShop.DBUtility
{
    public class OracleHelper
    {
        public static object GetCValue(string sql, int i)
        {
            object va = OracleHelper.ExecuteScalar(OracleHelper.ConnString, CommandType.Text, sql, null);
            return va;
        }
        /// <summary>
        /// 連接字符串
        /// </summary>
        public static string ConnString = ConfigurationManager.AppSettings["p_link"].ToString();
        private static Hashtable parmCache = Hashtable.Synchronized(new Hashtable());
        public static string aa = "";
        public static OleDbDataReader rdr;

        /// <summary>
        /// 獲取參數
        /// </summary>
        /// <param name="cacheKey"></param>
        /// <returns></returns>
        public static OleDbParameter[] GetCachedParameters(string cacheKey)
        {
            OleDbParameter[] cachedParms = (OleDbParameter[])parmCache[cacheKey];
            if (cachedParms == null)
            {
                return null;
            }
            OleDbParameter[] clonedParms = new OleDbParameter[cachedParms.Length];
            for (int i = 0, j = cachedParms.Length; i < j; i++)
            {
                clonedParms[i] = (OleDbParameter)((ICloneable)cachedParms[i]).Clone();
            }
            return clonedParms;
        }

        /// <summary>
        /// 执行SQL语句返回datareader对象
        /// </summary>
        /// <param name="conn"></param>
        /// <param name="trans"></param>
        /// <param name="cmdType"></param>
        /// <param name="cmdText"></param>
        /// <param name="commandParameters"></param>
        /// <returns></returns>
        public static OleDbDataReader ExecuteReader(OleDbConnection conn, OleDbTransaction trans, CommandType cmdType, string cmdText, params OleDbParameter[] commandParameters)
        {

            //Create the command and connection
            OleDbCommand cmd = new OleDbCommand();
            try
            {
                PrepareCommand(cmd, conn, trans, cmdType, cmdText, commandParameters);
                OleDbDataReader rdr = cmd.ExecuteReader();
                cmd.Parameters.Clear();
                return rdr;
            }
            catch
            {
                conn.Close();
                throw;
            }
        }
        /// <summary>
        /// 緩存參數列表
        /// </summary>
        /// <param name="cacheKey"></param>
        /// <param name="commandParameters"></param>
        public static void CacheParameters(string cacheKey, params OleDbParameter[] commandParameters)
        {
            parmCache[cacheKey] = commandParameters;
        }

        /// <summary>
        /// 針對需要賦值的SQL語句進行參數初始化
        /// </summary>
        /// <param name="cmd"></param>
        /// <param name="conn"></param>
        /// <param name="trans"></param>
        /// <param name="cmdType"></param>
        /// <param name="cmdText"></param>
        /// <param name="commandParameters"></param>
        public static void PrepareCommand(OleDbCommand cmd, OleDbConnection conn, OleDbTransaction trans, CommandType cmdType, string cmdText, OleDbParameter[] commandParameters)
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
                foreach (OleDbParameter parm in commandParameters)
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
        public static void PrepareCommand(OleDbCommand cmd, CommandType cmdType, string cmdText, OleDbParameter[] commandParameters)
        {
            cmd.Parameters.Clear();
            cmd.CommandText = cmdText;
            cmd.CommandType = cmdType;
            if (commandParameters != null)
            {
                foreach (OleDbParameter parm in commandParameters)
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
        public static int ExecuteNonQuery(string connectionString, CommandType cmdType, string cmdText, params OleDbParameter[] commandParameters)
        {
            OleDbCommand cmd = new OleDbCommand();
            using (OleDbConnection connection = new OleDbConnection(connectionString))
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
        public static int ExecuteNonQuery(CommandType cmdType, string cmdText, params OleDbParameter[] commandParameters)
        {
            OleDbCommand cmd = new OleDbCommand();
            using (OleDbConnection connection = new OleDbConnection(ConnString))
            {
                PrepareCommand(cmd, connection, null, cmdType, cmdText, commandParameters);
                int val = cmd.ExecuteNonQuery();
                cmd.Parameters.Clear();
                return val;
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
        public static int ExecuteNonQuery(OleDbTransaction trans, CommandType cmdType, string cmdText, params OleDbParameter[] commandParameters)
        {
            OleDbCommand cmd = new OleDbCommand();
            PrepareCommand(cmd, trans.Connection, trans, cmdType, cmdText, commandParameters);
            int val = cmd.ExecuteNonQuery();
            cmd.Parameters.Clear();
            return val;
        }

        /// <summary>
        /// 執行SQL語句，返回資料列。
        /// <para></para>
        /// <para>例外狀況:</para>
        /// 無效的SQL語句以及無效的參數。
        /// </summary>
        /// <param name="connectionString"></param>
        /// <param name="cmdType"></param>
        /// <param name="cmdText"></param>
        /// <param name="commandParameters"></param>
        /// <returns></returns>
        public static OleDbDataReader ExecuteReader(string connectionString, CommandType cmdType, string cmdText, params OleDbParameter[] commandParameters)
        {

            //Create the command and connection
            OleDbCommand cmd = new OleDbCommand();
            OleDbConnection conn = new OleDbConnection(connectionString);
            try
            {
                PrepareCommand(cmd, conn, null, cmdType, cmdText, commandParameters);
                OleDbDataReader rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
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
        /// 返回表中某個字段的值。
        /// </summary>
        /// <param name="sql">SQL語句</param>
        /// <param name="id">字符編號</param>
        /// <returns>返回子段的值</returns>
        public static OleDbDataReader getsql(string sql, int id)
        {


            OleDbCommand cmd = new OleDbCommand();
            OleDbConnection conn = new OleDbConnection(ConnString);

            try
            {

                conn.Open();
                if (id == 1)
                    rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                if (id == 2)
                    rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                if (id == 3)
                    rdr = cmd.ExecuteReader();
                if (id == 4)
                    rdr = cmd.ExecuteReader(CommandBehavior.SchemaOnly);

            }
            catch
            {
                conn.Close();
            }
            return rdr;
        }

        /// <summary>
        /// 執行SQL語句，返回指定資料列的值。
        /// </summary>
        /// <param name="connectionString"></param>
        /// <param name="cmdType"></param>
        /// <param name="cmdText"></param>
        /// <param name="commandParameters"></param>
        /// <returns></returns>
        public static object ExecuteScalar(string connectionString, CommandType cmdType, string cmdText, params OleDbParameter[] commandParameters)
        {
            OleDbCommand cmd = new OleDbCommand();

            using (OleDbConnection conn = new OleDbConnection(connectionString))
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
        public static object ExecuteScalar(OleDbTransaction transaction, CommandType commandType, string commandText, params OleDbParameter[] commandParameters)
        {
            if (transaction == null)
                throw new ArgumentNullException("transaction");
            if (transaction != null && transaction.Connection == null)
                throw new ArgumentException("The transaction was rollbacked	or commited, please	provide	an open	transaction.", "transaction");
            OleDbCommand cmd = new OleDbCommand();
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
        public static object ExecuteScalar(OleDbConnection connectionString, CommandType cmdType, string cmdText, params OleDbParameter[] commandParameters)
        {
            OleDbCommand cmd = new OleDbCommand();

            PrepareCommand(cmd, connectionString, null, cmdType, cmdText, commandParameters);
            object val = cmd.ExecuteScalar();
            cmd.Parameters.Clear();
            return val;
        }

        /// <summary>
        /// 執行SQL語句，返回指定資料列的值。
        /// </summary>
        /// <param name="connectionString"></param>
        /// <param name="cmdType"></param>
        /// <param name="cmdText"></param>
        /// <param name="commandParameters"></param>
        /// <returns></returns>
        public static object ExecuteScalar(CommandType cmdType, string cmdText, params OleDbParameter[] commandParameters)
        {
            OleDbCommand cmd = new OleDbCommand();
            using (OleDbConnection conn = new OleDbConnection(ConnString))
            {

                PrepareCommand(cmd, conn, null, cmdType, cmdText, commandParameters);
                object val = cmd.ExecuteScalar();
                cmd.Parameters.Clear();
                return val;
            }

        }

        /// <summary>
        /// 执行SQL
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public static int ExeSQL(string sql)
        {
            using (OleDbConnection conn = new OleDbConnection(ConnString))
            {
                OleDbCommand cmd = new OleDbCommand(sql, conn);
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
        /// <summary>
        /// 查詢
        /// </summary>
        /// <param name="connectionString"></param>
        /// <param name="SQLString"></param>
        /// <returns></returns>
        /// <summary>



        /// <summary>
        /// 返回某行數據。忽略其他行的結果集
        /// </summary>
        /// <param name="sql">SQL語句</param>
        /// <param name="id">返回行的ID</param>
        /// <returns></returns>
        public static string selectsql(string sql, int id)
        {
            using (OleDbConnection conn = new OleDbConnection(ConnString))
            {
                string str_return;
                OleDbCommand cmd = new OleDbCommand(sql, conn);
                try
                {
                    conn.Open();
                    str_return = cmd.ExecuteScalar().ToString();
                    return str_return;
                }
                catch
                {
                    return "";

                }
                finally
                {
                    conn.Close();
                }
            }


        }

        /// 查詢
        /// </summary>
        /// <param name="connectionString"></param>
        /// <param name="SQLString"></param>
        /// <returns></returns>
        public static DataSet Query(string connectionString, string SQLString)
        {
            using (OleDbConnection connection = new OleDbConnection(connectionString))
            {
                DataSet ds = new DataSet();
                try
                {
                    connection.Open();
                    OleDbDataAdapter command = new OleDbDataAdapter(SQLString, connection);
                    command.Fill(ds, "ds");
                }
                catch (OleDbException ex)
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

        public static DataSet GetDS(string SQLString)
        {
            using (OleDbConnection connection = new OleDbConnection(ConnString))
            {
                DataSet ds = new DataSet();
                try
                {
                    connection.Open();
                    OleDbDataAdapter command = new OleDbDataAdapter(SQLString, connection);
                    command.Fill(ds, "ds");
                }
                catch (OleDbException ex)
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
        /// <summary>
        /// 執行SQL語句,綁定數據到GridView上.
        /// </summary>
        /// <param name="Sql"></param>
        /// <param name="Sender"></param>
        public static void BindGridView(string Sql, GridView Sender)
        {
            using (OleDbConnection Conn = new OleDbConnection(ConnString))
            {
                try
                {
                    DataSet Ds = new DataSet();
                    OleDbDataAdapter Adp = new OleDbDataAdapter(Sql, Conn);
                    Conn.Open();
                    Ds.Clear();
                    Adp.Fill(Ds);
                    Sender.DataSource = new DataView(Ds.Tables[0]);
                    Sender.DataBind();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    Conn.Close();
                }
            }
        }

        public static DataTable getDB(string sql)
        {
            DataTable dt = new DataTable();
            using (OleDbConnection conn = new OleDbConnection(ConnString))
            {
                OleDbDataAdapter comm = new OleDbDataAdapter(sql, conn);
                DataSet ds = new DataSet();
                try
                {
                    conn.Open();
                    ds.Clear();
                    comm.Fill(ds);
                    dt = ds.Tables[0];

                }
                catch
                {
                    conn.Close();
                }
                finally
                {
                    conn.Close();
                }
                return dt;
            }

        }


        /// <summary>
        /// 初始化dropdownlist
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="ddl"></param>
        public static void InitDropDownList(string sql, DropDownList ddl)
        {
            DataSet ds = new DataSet();
            using (OleDbConnection conn = new OleDbConnection(ConnString))
            {
                OleDbDataAdapter da = new OleDbDataAdapter(sql, conn);
                try
                {
                    conn.Open();
                    da.Fill(ds);
                    ddl.DataSource = new DataView(ds.Tables[0]);
                    ddl.DataTextField = "f2";
                    ddl.DataValueField = "f1";
                    ddl.DataBind();
                }
                catch (OleDbException ex)
                {
                    throw new Exception(ex.Message);
                }
                finally
                {
                    conn.Close();
                }
            }
        }

        public static void SetDDL(string sql, DropDownList ddl, int i)
        {
            DataSet ds = new DataSet();
            using (OleDbConnection conn = new OleDbConnection(ConnString))
            {
                OleDbDataAdapter adp = new OleDbDataAdapter(sql, conn);
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
                catch (OleDbException ex)
                {
                    throw new Exception(ex.Message);
                }
                finally
                {
                    conn.Close();
                }
            }
        }
        public static DataTable QueryTable(OleDbConnection connection, string SQLString)
        {

            DataTable dt = new DataTable();
            try
            {
                OleDbDataAdapter command = new OleDbDataAdapter(SQLString, connection);
                command.Fill(dt);
            }
            catch
            {

            }
            finally
            {

            }
            return dt;
        }
        public static DataTable QueryTable(string connectionString, string SQLString)
        {
            using (OleDbConnection connection = new OleDbConnection(connectionString))
            {
                DataTable dt = new DataTable();
                try
                {
                    connection.Open();
                    OleDbDataAdapter command = new OleDbDataAdapter(SQLString, connection);
                    command.Fill(dt);
                }
                catch (OleDbException ex)
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
                return dt;
            }
        }



        /*******************设置body中控件的文字开始***********************/
        public static void SetBodyLanguage(XmlNodeList xmllist, HtmlForm form)
        {
            foreach (XmlNode node in xmllist)
            {
                if (form.FindControl(node.Name) != null)
                {
                    string object_name = form.FindControl(node.Name).GetType().Name;
                    switch (object_name)
                    {
                        case "HtmlGenericControl":
                            HtmlGenericControl object_html = (HtmlGenericControl)form.FindControl(node.Name);
                            object_html.InnerHtml = node.InnerText;
                            break;
                        case "HtmlButton":
                            HtmlButton btn_html = (HtmlButton)form.FindControl(node.Name);
                            btn_html.InnerHtml = node.InnerText;
                            break;
                        case "Label":
                            Label lab = (Label)form.FindControl(node.Name);
                            lab.Text = node.InnerText;
                            break;
                        case "TextBox":
                            TextBox txt = (TextBox)form.FindControl(node.Name);
                            XmlAttributeCollection xmlattrlist = node.Attributes;
                            foreach (XmlAttribute xmlattr in xmlattrlist)
                            {
                                if (xmlattr.Name == "ToolTip")
                                {
                                    txt.ToolTip = xmlattr.Value;
                                }
                                else
                                {
                                    txt.Attributes.Add(xmlattr.Name, xmlattr.Value);
                                }

                            }
                            break;
                        case "DropDownList":
                            DropDownList ddl = (DropDownList)form.FindControl(node.Name);
                            XmlAttributeCollection ddl_xmlattrlist = node.Attributes;

                            foreach (XmlAttribute ddl_xmlattr in ddl_xmlattrlist)
                            {
                                ddl.Attributes.Add(ddl_xmlattr.Name, ddl_xmlattr.Value);
                            }
                            break;
                        case "Button":
                            Button btn = (Button)form.FindControl(node.Name);
                            btn.Text = node.InnerText;
                            break;
                        case "HyperLink":
                            HyperLink hl = (HyperLink)form.FindControl(node.Name);
                            hl.Text = node.InnerText;
                            break;
                        case "CheckBox":
                            CheckBox cb = (CheckBox)form.FindControl(node.Name);
                            cb.Text = node.InnerText;
                            break;
                        case "RadioButton":
                            RadioButton rb = new RadioButton();
                            rb.Text = node.InnerText;
                            break;
                        case "LinkButton":
                            LinkButton lb = new LinkButton();
                            lb.Text = node.InnerText;
                            break;
                        default:
                            break;
                    }
                }

            }
        }

        public static void SetPage(string path, string worker_id, string language, HtmlForm form, string cachename)
        {
            //System.Web.HttpContext.Current.Server.MapPath("~/Xml/General/Employee/Employee" + language + ".xml")
            if (File.Exists(path)) //如果存在，返回该文件夹所在的物理路径
            {
                cachename = cachename + language;
                XmlDocument XmlDoc = new XmlDocument();
                //XmlDocument xmlcache = (XmlDocument)System.Web.HttpContext.Current.Cache[cachename + language];
                //if (xmlcache == null)
                //{
                //    XmlDoc.Load(path);
                //    System.Web.HttpContext.Current.Cache[cachename + language] = XmlDoc;
                //}
                //else
                //{
                //    XmlDoc = xmlcache;
                //}
                XmlDoc.Load(path);
                if (XmlDoc.HasChildNodes)
                {
                    XmlNode root = XmlDoc.DocumentElement;
                    XmlNodeList xmlchild = root.SelectSingleNode("Page").ChildNodes;
                    if (xmlchild.Count > 0)
                    {
                        SetBodyLanguage(xmlchild, form);
                    }
                }

            }
        }
        /*******************设置body中控件的文字结束***********************/

        /*******************设置表头文字开始***********************/
        public static void SetTableHead(string path, string language, string cachename, object sender, string xmlTableName)
        {
            //System.Web.HttpContext.Current.Server.MapPath("~/Xml/General/Employee/Employee" + language + ".xml")
            if (File.Exists(path)) //如果存在，返回该文件夹所在的物理路径
            {
                cachename = cachename + language;
                XmlDocument XmlDoc = new XmlDocument();
                //XmlDocument xmlcache = (XmlDocument)System.Web.HttpContext.Current.Cache[cachename + language];
                //if (xmlcache == null)
                //{
                //    XmlDoc.Load(path);
                //    System.Web.HttpContext.Current.Cache[cachename + language] = XmlDoc;
                //}
                //else
                //{
                //    XmlDoc = xmlcache;
                //}
                XmlDoc.Load(path);
                if (XmlDoc.HasChildNodes)
                {
                    XmlNode root = XmlDoc.DocumentElement;
                    XmlNodeList xmlchild = root.SelectSingleNode(xmlTableName).ChildNodes;
                    if (xmlchild.Count > 0)
                    {
                        ((GridView)sender).Controls[0].Controls.AddAt(0, InitTable(xmlchild));//加到最前面
                    }
                }

            }
        }
        public static void SetTableHead(string path, string language, string cachename, object sender)
        {
            //System.Web.HttpContext.Current.Server.MapPath("~/Xml/General/Employee/Employee" + language + ".xml")
            if (File.Exists(path)) //如果存在，返回该文件夹所在的物理路径
            {

                cachename = cachename + language;
                XmlDocument XmlDoc = new XmlDocument();
                //XmlDocument xmlcache = (XmlDocument)System.Web.HttpContext.Current.Cache[cachename + language];
                //if (xmlcache == null)
                //{
                //    XmlDoc.Load(path);
                //    System.Web.HttpContext.Current.Cache[cachename + language] = XmlDoc;
                //}
                //else
                //{
                //    XmlDoc = xmlcache;
                //}
                XmlDoc.Load(path);
                if (XmlDoc.HasChildNodes)
                {
                    XmlNode root = XmlDoc.DocumentElement;
                    XmlNodeList xmlchild = root.SelectSingleNode("Table").ChildNodes;
                    if (xmlchild.Count > 0)
                    {
                        ((GridView)sender).Controls[0].Controls.AddAt(0, InitTable(xmlchild));//加到最前面
                    }
                }

            }
        }
        public static void SetDetailTableHead(string path, string language, string cachename, object sender)
        {
            //System.Web.HttpContext.Current.Server.MapPath("~/Xml/General/Employee/Employee" + language + ".xml")
            if (File.Exists(path)) //如果存在，返回该文件夹所在的物理路径
            {
                cachename = cachename + language;
                XmlDocument XmlDoc = new XmlDocument();
                //XmlDocument xmlcache = (XmlDocument)System.Web.HttpContext.Current.Cache[cachename + language];
                //if (xmlcache == null)
                //{
                //    XmlDoc.Load(path);
                //    System.Web.HttpContext.Current.Cache[cachename + language] = XmlDoc;
                //}
                //else
                //{
                //    XmlDoc = xmlcache;
                //}
                XmlDoc.Load(path);
                if (XmlDoc.HasChildNodes)
                {
                    XmlNode root = XmlDoc.DocumentElement;
                    XmlNodeList xmlchild = root.SelectSingleNode("DetailTable").ChildNodes;
                    if (xmlchild.Count > 0)
                    {
                        ((GridView)sender).Controls[0].Controls.AddAt(0, InitTable(xmlchild));//加到最前面
                    }
                }

            }
        }
        public static GridViewRow InitTable(XmlNodeList xmllist)
        {
            GridViewRow rowHeader = new GridViewRow(0, 0, DataControlRowType.Header, DataControlRowState.Normal);// 表头行
            int id = 1;
            foreach (XmlNode node in xmllist)
            {
                TableHeaderCell cell = new TableHeaderCell();
                cell.ColumnSpan = 1;
                cell.Text = node.InnerText;
                cell.ID = "cell" + id.ToString();
                rowHeader.Cells.Add(cell);
                id = id + 1;
            }
            return rowHeader;
        }
        /*******************设置表头文字结束***********************/

        /*******************设置Menu文字开始***********************/

        public static void SetMenuLanguage(XmlNodeList xmllist, HtmlForm form)
        {
            foreach (XmlNode node in xmllist)
            {

                if (node.Name != "menu")
                {
                    XmlElement xmle = (XmlElement)node;
                    if (form.FindControl(xmle.GetAttribute("id")) != null && xmle.GetAttribute("id") != "")
                    {
                        string object_name = form.FindControl(xmle.GetAttribute("id")).GetType().Name;

                        switch (object_name)
                        {
                            case "HtmlGenericControl":
                                HtmlGenericControl object_html = (HtmlGenericControl)form.FindControl(xmle.GetAttribute("id"));
                                object_html.InnerHtml = xmle.InnerText;
                                break;
                            default:
                                Button btn = (Button)form.FindControl(xmle.GetAttribute("id"));
                                btn.Text = xmle.InnerText;
                                break;
                        }
                    }
                }
                else
                {
                    XmlElement xmle = (XmlElement)node;
                    if (form.FindControl(xmle.GetAttribute("id")) != null && xmle.GetAttribute("id") != "")
                    {
                        string object_name = form.FindControl(xmle.GetAttribute("id")).GetType().Name;

                        switch (object_name)
                        {
                            case "HtmlGenericControl":
                                HtmlGenericControl object_html = (HtmlGenericControl)form.FindControl(xmle.GetAttribute("id"));
                                object_html.InnerHtml = xmle.GetAttribute("value");
                                break;
                            default:
                                Button btn = (Button)form.FindControl(xmle.GetAttribute("id"));
                                btn.Text = xmle.GetAttribute("value");
                                break;
                        }
                        if (xmle.HasChildNodes)
                        {
                            XmlNodeList xmlchild = xmle.ChildNodes;
                            foreach (XmlNode nodechild in xmlchild)
                            {
                                XmlElement xmle_child = (XmlElement)nodechild;
                                if (form.FindControl(xmle_child.GetAttribute("id")) != null && xmle_child.GetAttribute("id") != "")
                                {
                                    object_name = form.FindControl(xmle_child.GetAttribute("id")).GetType().Name;

                                    switch (object_name)
                                    {
                                        case "HtmlGenericControl":
                                            HtmlGenericControl object_html = (HtmlGenericControl)form.FindControl(xmle_child.GetAttribute("id"));
                                            object_html.InnerHtml = xmle_child.InnerText;
                                            break;
                                        default:
                                            Button btn = (Button)form.FindControl(xmle_child.GetAttribute("id"));
                                            btn.Text = xmle_child.InnerText;
                                            break;
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }

        public static void SetMenu(string worker_id, string language, HtmlForm form, string cachename)
        {
            if (File.Exists(System.Web.HttpContext.Current.Server.MapPath("~/Xml/HeadMenu/" + language + ".xml"))) //如果存在，返回该文件夹所在的物理路径
            {
                XmlDocument XmlDoc = new XmlDocument();
                //XmlDocument xmlcache = (XmlDocument)System.Web.HttpContext.Current.Cache[cachename + language];
                //if (xmlcache == null)
                //{
                //    XmlDoc.Load(System.Web.HttpContext.Current.Server.MapPath("~/Xml/HeadMenu/" + language + ".xml"));
                //    System.Web.HttpContext.Current.Cache[cachename + language] = XmlDoc;
                //}
                //else
                //{
                //    XmlDoc = xmlcache;
                //}
                XmlDoc.Load(System.Web.HttpContext.Current.Server.MapPath("~/Xml/HeadMenu/" + language + ".xml"));
                if (XmlDoc.HasChildNodes)
                {
                    XmlNode root = XmlDoc.DocumentElement;
                    XmlNodeList xmlmenu = root.SelectNodes("menu");
                    if (xmlmenu.Count > 0)
                    {
                        SetMenuLanguage(xmlmenu, form);
                    }
                    XmlNodeList xmlhead = root.SelectSingleNode("head").ChildNodes;
                    if (xmlhead.Count > 0)
                    {
                        SetMenuLanguage(xmlhead, form);
                    }
                }

            }
        }
        /*******************设置Menu文字结束***********************/

        /*******************系統常用控件的文字開始***********************/
        public static void SetCommon(string worker_id, string language, HtmlForm form, string cachename)
        {
            if (File.Exists(System.Web.HttpContext.Current.Server.MapPath("~/Xml/Common/" + language + ".xml"))) //如果存在，返回该文件夹所在的物理路径
            {
                XmlDocument XmlDoc = new XmlDocument();
                //XmlDocument xmlcache = (XmlDocument)System.Web.HttpContext.Current.Cache[cachename + language];
                //if (xmlcache == null)
                //{
                //    XmlDoc.Load(System.Web.HttpContext.Current.Server.MapPath("~/Xml/Common/" + language + ".xml"));
                //    System.Web.HttpContext.Current.Cache[cachename + language] = XmlDoc;
                //}
                //else
                //{
                //    XmlDoc = xmlcache;
                //}
                XmlDoc.Load(System.Web.HttpContext.Current.Server.MapPath("~/Xml/Common/" + language + ".xml"));
                if (XmlDoc.HasChildNodes)
                {
                    XmlNode root = XmlDoc.DocumentElement;
                    XmlNodeList xmlchild = root.SelectSingleNode("Page").ChildNodes;
                    if (xmlchild.Count > 0)
                    {
                        SetBodyLanguage(xmlchild, form);
                    }
                }

            }
        }
        /*******************系統常用控件的文字結束***********************/

        public static string ReturnTable(string path, string language, string id)
        {
            string title = "";
            //string path = System.Web.HttpContext.Current.Server.MapPath("~/Xml/Purchase/Po/Po" + language + ".xml");
            //string cachename = "Pocache";
            if (File.Exists(path)) //如果存在，返回该文件夹所在的物理路径
            {
                XmlDocument XmlDoc = new XmlDocument();
                //XmlDocument xmlcache = (XmlDocument)System.Web.HttpContext.Current.Cache[cachename + language];
                //if (xmlcache == null)
                //{
                //    XmlDoc.Load(path);
                //    System.Web.HttpContext.Current.Cache[cachename + language] = XmlDoc;
                //}
                //else
                //{
                //    XmlDoc = xmlcache;
                //}
                XmlDoc.Load(path);
                if (XmlDoc.HasChildNodes)
                {
                    XmlNode root = XmlDoc.DocumentElement;
                    XmlNode xmlchild = root.SelectSingleNode("Detail/Table/Item[@id=" + id + "]");
                    if (xmlchild != null)
                    {
                        title = xmlchild.InnerText;
                    }
                }

            }
            return title;
        }

        public static void TreeViewDataBind(TreeNodeCollection nodes, string parentNodeId)
        {
            string sql = " select revision,parent,b.short_name parent_name,child,c.short_name child_name, ";
            sql += " to_char(effect_date,'yyyy-mm-dd') effect_date ";
            sql += " ,to_char(a.close_date,'yyyy-mm-dd') close_date,site ,";
            sql += " (select description from mgs_users where worker_id=B.BOSS)  BOSS from ps_organization a, ";
            sql += " ps_department b,ps_department c where a.parent=b.deptno and a.child=c.deptno and a.site=b.com ";
            sql += " parent='" + parentNodeId + "' and a.CLOSE_DATE is null order by parent,child ";
            DataSet ds = new DataSet();
            TreeNode node;
            ds = OracleHelper.GetDS(sql);
            if (ds.Tables[0].Rows.Count > 0)
            {
                node = new TreeNode();
                if (ds.Tables[0].Rows[0].ItemArray[8].ToString() != "")
                {
                    node.Text = ds.Tables[0].Rows[0].ItemArray[2].ToString() + " - " + ds.Tables[0].Rows[0].ItemArray[8].ToString();
                }
                else
                {
                    node.Text = ds.Tables[0].Rows[0].ItemArray[2].ToString();
                }
                node.NavigateUrl = "#";
                nodes.Add(node);
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    //node = new TreeNode();
                    //node.Text = ds.Tables[0].Rows[i].ItemArray[2].ToString();
                    //node.NavigateUrl = "#";

                    TreeViewDataBind(node.ChildNodes, ds.Tables[0].Rows[i].ItemArray[3].ToString());

                    //nodes.Add(node);
                }
            }
            else
            {
                sql = " select revision,parent,b.short_name parent_name,child,c.short_name child_name, ";
                sql += " to_char(effect_date,'yyyy-mm-dd')effect_date ";
                sql += " ,to_char(a.close_date,'yyyy-mm-dd') close_date,site ,";
                sql += " (select description from mgs_users where worker_id=c.BOSS)  BOSS from ps_organization a, ";
                sql += " ps_department b,ps_department c where a.parent=b.deptno and a.child=c.deptno and  ";
                sql += " child='" + parentNodeId + "' and a.CLOSE_DATE is null and a.site=b.com order by parent,child ";
                ds = OracleHelper.GetDS(sql);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    node = new TreeNode();
                    if (ds.Tables[0].Rows[0].ItemArray[8].ToString() != "")
                    {
                        node.Text = ds.Tables[0].Rows[0].ItemArray[4].ToString() + " - " + ds.Tables[0].Rows[0].ItemArray[8].ToString();
                    }
                    else
                    {
                        node.Text = ds.Tables[0].Rows[0].ItemArray[4].ToString();
                    }

                    node.NavigateUrl = "#";
                    nodes.Add(node);
                }
            }

        }

        public static void pro_employee_mail(string in_key, string in_type)
        {
            using (OleDbConnection conn = new OleDbConnection(ConnString))
            {
                OleDbCommand cmd = new OleDbCommand();
                try
                {
                    conn.Open();
                    cmd = new OleDbCommand("pro_employee_mail", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    OleDbParameter para_in_key = cmd.Parameters.Add("@in_key", OleDbType.VarChar, 4000);
                    para_in_key.Direction = ParameterDirection.Input;
                    para_in_key.Value = in_key;
                    OleDbParameter para_in_type = cmd.Parameters.Add("@in_type", OleDbType.VarChar, 100);
                    para_in_type.Direction = ParameterDirection.Input;
                    para_in_type.Value = in_type;
                    cmd.ExecuteNonQuery();
                    cmd.Dispose();
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);

                }
                finally
                {
                    conn.Close();
                }
            }
        }

        public static void pro_ierp_manpower(string p_type, string p_user_id, string p_key)
        {
            using (OleDbConnection conn = new OleDbConnection(ConnString))
            {
                OleDbCommand cmd = new OleDbCommand();
                try
                {
                    conn.Open();
                    cmd = new OleDbCommand("pro_ierp_manpower", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    OleDbParameter para_p_type = cmd.Parameters.Add("@p_type", OleDbType.VarChar, 200);
                    para_p_type.Direction = ParameterDirection.Input;
                    para_p_type.Value = p_type;
                    OleDbParameter para_p_user_id = cmd.Parameters.Add("@p_user_id", OleDbType.VarChar, 100);
                    para_p_user_id.Direction = ParameterDirection.Input;
                    para_p_user_id.Value = p_user_id;
                    OleDbParameter para_p_key = cmd.Parameters.Add("@p_key", OleDbType.VarChar, 100);
                    para_p_key.Direction = ParameterDirection.Input;
                    para_p_key.Value = p_key;
                    cmd.ExecuteNonQuery();
                    cmd.Dispose();
                }
                catch (Exception ex)
                {
                    conn.Close();
                    throw new Exception(ex.Message);
                }
                finally
                {
                    conn.Close();
                }
            }
        }

        public static void pro_ierp_report(string p_type, string p_user_id, string p_key)
        {
            using (OleDbConnection conn = new OleDbConnection(ConnString))
            {
                OleDbCommand cmd = new OleDbCommand();
                try
                {
                    conn.Open();
                    cmd = new OleDbCommand("pro_ierp_report", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    OleDbParameter para_p_type = cmd.Parameters.Add("@p_type", OleDbType.VarChar, 200);
                    para_p_type.Direction = ParameterDirection.Input;
                    para_p_type.Value = p_type;
                    OleDbParameter para_p_user_id = cmd.Parameters.Add("@p_user_id", OleDbType.VarChar, 100);
                    para_p_user_id.Direction = ParameterDirection.Input;
                    para_p_user_id.Value = p_user_id;
                    OleDbParameter para_p_key = cmd.Parameters.Add("@p_key", OleDbType.VarChar, 100);
                    para_p_key.Direction = ParameterDirection.Input;
                    para_p_key.Value = p_key;
                    cmd.ExecuteNonQuery();
                    cmd.Dispose();
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
                finally
                {
                    conn.Close();
                }
            }
        }

        public static void pro_calendar(string in_year, string in_user_id)
        {
            using (OleDbConnection conn = new OleDbConnection(ConnString))
            {
                OleDbCommand cmd = new OleDbCommand();
                try
                {
                    conn.Open();
                    cmd = new OleDbCommand("pro_calendar", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    OleDbParameter para_in_year = cmd.Parameters.Add("@in_year", OleDbType.VarChar, 200);
                    para_in_year.Direction = ParameterDirection.Input;
                    para_in_year.Value = in_year;
                    OleDbParameter para_in_user_id = cmd.Parameters.Add("@in_user_id", OleDbType.VarChar, 100);
                    para_in_user_id.Direction = ParameterDirection.Input;
                    para_in_user_id.Value = in_user_id;
                    cmd.ExecuteNonQuery();
                    cmd.Dispose();
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
                finally
                {
                    conn.Close();
                }
            }
        }

        public static string ExecPro(string ProName, string KeyStr)
        {
            string v_out = "";
            using (OleDbConnection conn = new OleDbConnection(OracleHelper.ConnString))
            {
                OleDbCommand cmd = new OleDbCommand();
                try
                {
                    conn.Open();
                    cmd = new OleDbCommand(ProName, conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    OleDbParameter para_p_key = cmd.Parameters.Add("@p_key", OleDbType.VarChar, 4000);
                    para_p_key.Direction = ParameterDirection.Input;
                    para_p_key.Value = KeyStr;
                    OleDbParameter para_out_result = cmd.Parameters.Add("@p_out", OleDbType.VarChar, 4000);
                    para_out_result.Direction = ParameterDirection.Output;
                    cmd.ExecuteNonQuery();
                    v_out = cmd.Parameters["@p_out"].Value.ToString();
                    cmd.Dispose();
                }
                catch
                {
                }
                finally
                {
                    conn.Close();
                }
                return v_out;
            }
        }

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


        /// <summary>
        /// 执行SQL
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public static int ExePro(string sql)
        {
            using (OleDbConnection conn = new OleDbConnection(ConnString))
            {
                OleDbCommand cmd = new OleDbCommand(sql, conn);
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
    }
}
