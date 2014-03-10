using System;
using System.Collections.Generic;
using System.Web;
using System.Text;
using System.Data;
using System.Data.OleDb;
using BigDogShop.DBUtility;

/// <summary>
/// Summary description for ErrorTracking
/// </summary>
public static class ErrorTracking
{
    private static readonly log4net.ILog log = log4net.LogManager.GetLogger(typeof(ErrorTracking));
    /// <summary>
    /// 页面异常记录
    /// </summary>
    /// <param name="objErr"></param>
    /// <returns></returns>
    public static int LodError(Exception objErr)
    {
        int m = 0;
        log.Error(objErr);
        try
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append("详细错误信息:请求页：" + HttpContext.Current.Request.RawUrl);
            sb.Append("\r\nSOURCE: " + objErr.Source);
            sb.Append("\r\nStackTrace: " + objErr.StackTrace);
            sb.Append("\r\nIP: " + HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"]);
            sb.Append("\r\n操作人: " + HttpContext.Current.Request["temp_worker_id"]);
            sb.Append("\r\n引发当前异常的原因:" + objErr.Message);
            sb.Append("\r\n堆栈跟踪: " + objErr.TargetSite + "\r\n---------------------------------\r\n");
            StringBuilder SQL = new StringBuilder(" INSERT INTO ierp_error_tracking_info(ERROR_ID,ERROR_TYPE,ERROR_LEVEL,ERROR_CONTENT,ERROR_DATE) ");
            SQL.Append("     VALUES( ierp_error_tracking_info_SEQ.NEXTVAL,'E','A',?,SYSDATE) ");
            OleDbParameter[] errorPara = new OleDbParameter[] { new OleDbParameter("ERROR_CONTENT", sb.ToString()) };
            m = OracleHelper.ExecuteNonQuery(OracleHelper.ConnString, CommandType.Text, SQL.ToString(), errorPara);
        }
        catch { }
        return m;
    }
    /// <summary>
    /// 页面异常记录
    /// </summary>
    /// <param name="message">异常的名称</param>
    /// <param name="objErr"></param>
    /// <returns></returns>
    public static int LodError(string message, Exception objErr)
    {
        log.Error(objErr);
        int m = 0;
        try
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append("主旨信息:" + message);
            sb.Append("\r\n详细错误信息:请求页：" + HttpContext.Current.Request.RawUrl);
            sb.Append("\r\n引发当前异常的原因:" + objErr.Message);
            sb.Append("\r\nSOURCE: " + objErr.Source);
            sb.Append("\r\nStackTrace: " + objErr.StackTrace);
            sb.Append("\r\n堆栈跟踪: " + objErr.TargetSite + "\r\n---------------------------------\r\n");
            StringBuilder SQL = new StringBuilder(" INSERT INTO ierp_error_tracking_info(ERROR_ID,ERROR_TYPE,ERROR_LEVEL,ERROR_CONTENT,ERROR_DATE) ");
            SQL.Append("     VALUES( ierp_error_tracking_info_SEQ.NEXTVAL,'E','A',?,SYSDATE) ");
            OleDbParameter[] errorPara = new OleDbParameter[] { new OleDbParameter("ERROR_CONTENT", sb.ToString()) };
            m = OracleHelper.ExecuteNonQuery(OracleHelper.ConnString, CommandType.Text, SQL.ToString(), errorPara);
        }
        catch
        {
        }
        return m;
    }
    /// <summary>
    /// 页面异常记录
    /// </summary>
    /// <param name="objErr"></param>
    /// <param name="isReserve"></param>
    /// <returns></returns>
    public static int LodError(Exception objErr, bool isReserve)
    {
        int m = 0;
        try
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append("\r\n详细错误信息:请求页：" + HttpContext.Current.Request.RawUrl);
            sb.Append("\r\n引发当前异常的原因:" + objErr.Message);
            sb.Append("\r\nSOURCE: " + objErr.Source);
            sb.Append("\r\nStackTrace: " + objErr.StackTrace);
            sb.Append("\r\n堆栈跟踪: " + objErr.TargetSite + "\r\n---------------------------------\r\n");
            StringBuilder SQL = new StringBuilder(" INSERT INTO ierp_error_tracking_info(ERROR_ID,ERROR_TYPE,ERROR_LEVEL,ERROR_CONTENT,ERROR_DATE) ");
            SQL.Append("     VALUES( ierp_error_tracking_info_SEQ.NEXTVAL,'E','A',?,SYSDATE) ");
            OleDbParameter[] errorPara = new OleDbParameter[] { new OleDbParameter("ERROR_CONTENT", sb.ToString()) };
            m = OracleHelper.ExecuteNonQuery(OracleHelper.ConnString, CommandType.Text, SQL.ToString(), errorPara);
        }
        catch
        {

        }
        return m;
    }
}
