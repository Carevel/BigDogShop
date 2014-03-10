using System;
using System.Data;
using System.Configuration;
using System.Data.OleDb;
using BigDogShop.DBUtility;

/// <summary>
/// 表示實現登陸系統的驗証,驗証密碼用戶名,驗証權限信息的類別.
/// </summary>
public abstract class Verify
{
    private const string PARM_VERIFY_USER = " Verify_User";
    private const string PARM_VERIFY_PERMISSION = "verify_permission";
    private const string PARM_USER_NAME = "@p_user_name";
    private const string PARM_PROGRAM_ID = "@p_program_id";
    private const string PARM_PASS_WORD = "@p_password";
    private const string PARM_LOGIN_IP = "@p_login_ip";
    private const string PARM_RESULT = "@p_result";
    private const string PARM_RETURN = "@p_return";
    private const string PARM_USER_ID = "@user_id";
    private const string PARM_P_PROGRAM_ID = "@program_id";
    private const string PARM_P_VERSION = "@p_version";
    private const string PARM_ACCESS_IP = "@p_access_ip";
    public Verify()
    {

    }
    /// <summary>
    /// 驗証用戶名稱,密碼
    /// <para></para>
    /// <para>oracle數據庫過程:Verify_User</para>
    /// </summary>
    /// <param name="UserName"></param>
    /// <param name="ProgramId"></param>
    /// <param name="PassWord"></param>
    /// <param name="LoginIP"></param>
    /// <returns></returns>
    public static string VerifyUser(string UserName, string ProgramId, string PassWord, string LoginIP)
    {
        string vReturn;
        string vResult;
        string vStr;
        OleDbParameter[] orderParms = new OleDbParameter[] { 
            new OleDbParameter(PARM_USER_NAME,OleDbType.VarChar ,50),
            new OleDbParameter(PARM_PROGRAM_ID, OleDbType.VarChar,50),
            new OleDbParameter(PARM_PASS_WORD , OleDbType.VarChar,100),
            new OleDbParameter(PARM_LOGIN_IP , OleDbType.VarChar,50),
            new OleDbParameter(PARM_RESULT, OleDbType.VarChar,1000 ),
            new OleDbParameter(PARM_RETURN , OleDbType.VarChar,1000 )};
        orderParms[0].Value = UserName;
        orderParms[0].Direction = ParameterDirection.Input;
        orderParms[1].Value = ProgramId;
        orderParms[1].Direction = ParameterDirection.Input;
        orderParms[2].Value = PassWord;
        orderParms[2].Direction = ParameterDirection.Input;
        orderParms[3].Value = LoginIP;
        orderParms[3].Direction = ParameterDirection.Input;
        orderParms[4].Direction = ParameterDirection.Output;
        orderParms[5].Direction = ParameterDirection.Output;
        OracleHelper.ExecuteNonQuery(OracleHelper.ConnString, CommandType.StoredProcedure, PARM_VERIFY_USER, orderParms);
        vResult = orderParms[4].Value.ToString();
        vReturn = orderParms[5].Value.ToString();
        vStr = "<AUTHORIZATION>" + vResult + vReturn;
        return vStr;
    }
    /// <summary>
    /// 驗証用戶權限
    /// <para></para>
    /// <para>oracle數據庫過程:verify_permission</para>
    /// </summary>
    /// <param name="UserId"></param>
    /// <param name="ProgramId"></param>
    /// <param name="pVersion"></param>
    /// <param name="AcessIp"></param>
    /// <returns></returns>
    public static string VerifyPermission(string UserId, string ProgramId, string pVersion, string AcessIp)
    {
        string vResult;
        string vReturn;
        string vStr;
        OleDbParameter[] orderParms = new OleDbParameter[] { 
            new OleDbParameter(PARM_USER_ID,OleDbType.VarChar ,50),
            new OleDbParameter(PARM_P_PROGRAM_ID, OleDbType.VarChar,50),
            new OleDbParameter(PARM_P_VERSION , OleDbType.VarChar,100),
            new OleDbParameter(PARM_ACCESS_IP , OleDbType.VarChar,50),
            new OleDbParameter(PARM_RESULT, OleDbType.VarChar,1000 ),
            new OleDbParameter(PARM_RETURN , OleDbType.VarChar,1000 )};
        orderParms[0].Value = UserId;
        orderParms[0].Direction = ParameterDirection.Input;
        orderParms[1].Value = ProgramId;
        orderParms[1].Direction = ParameterDirection.Input;
        orderParms[2].Value = pVersion;
        orderParms[2].Direction = ParameterDirection.Input;
        orderParms[3].Value = AcessIp;
        orderParms[3].Direction = ParameterDirection.Input;
        orderParms[4].Direction = ParameterDirection.Output;
        orderParms[5].Direction = ParameterDirection.Output;
        OracleHelper.ExecuteNonQuery(OracleHelper.ConnString, CommandType.StoredProcedure, PARM_VERIFY_PERMISSION, orderParms);
        vResult = orderParms[4].Value.ToString();
        vReturn = orderParms[5].Value.ToString();
        vStr = "<AUTHORIZATION>" + vResult + vReturn;
        return vStr;
    }
    public static string GetValueName(string pStr, string pName)
    {
        int vHeader;
        string vTemp;
        int i;
        vTemp = "";
        if (!string.IsNullOrEmpty(pStr))
        {
            i = pStr.IndexOf(pName) + 1;
            vHeader = i + pName.Length;
            if ((vHeader <= pStr.Length) && (i != 0))
            {
                int j = pStr.Length;
                for (int vCount = vHeader; vCount <= j; vCount++)
                {
                    if (pStr.Substring(vCount - 1, 1) != "<")
                    {
                        vTemp = vTemp + pStr.Substring(vCount - 1, 1);
                    }
                    else
                    {
                        break;
                    }
                }
            }
        }
        return vTemp;
    }

}
