using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Web;
using System.Web.SessionState;
using BigDogShop.DBUtility;

namespace Common
{
    public class SendMail:IRequiresSessionState
    {

        /// <summary>
        /// 返回发送的Email码，用于安全验证
        /// </summary>
        public static string SendEmail()
        {
            string randomStr = Function.GetRandomStr(4);
            //randomStr=Function.MD5Encrypt(randomStr);
            string email = HttpContext.Current.Session["email"].ToString();
            
            StringBuilder mailSql = new StringBuilder();
            mailSql.Append("insert into common_mail_notice (MAIL_ID,MAIL_INFO_ID,PARAMS,MAILED,MAILED_DATE,CREATOR,CREATION_DATE)");
            mailSql.Append(" values(common_mail_notice_seq.nextval,'4','"+email+"'|||" + randomStr + "','N',sysdate,'sys',sysdate)");
            OracleHelper.ExeSQL(mailSql.ToString());
            return randomStr;
        }
    }
}
