using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BigDogShop.Common
{
    public class Keys
    {
        //cookie======================================================================
        /// <summary>
        /// 记住会员名
        /// </summary>
        public const string COOKIE_USER_NAME_REMEMBER = "bd_cookie_user_name_remember";

        /// <summary>
        /// 记住会员密码
        /// </summary>
        public const string COOKIE_USER_PWD_REMEMBER = "bd_cookie_user_pwd_remember";

        /// <summary>
        /// 记住管理员名
        /// </summary>
        public const string COOKIE_ADMIN_NAME_REMEMBER = "bd_cookie_admin_name_remeber"; 

        //session======================================================================
        /// <summary>
        /// 会员用户
        /// </summary>
        public const string SESSION_USER_INFO = "bd_session_user_info";

        /// <summary>
        /// 管理员用户
        /// </summary>
        public const string SESSION_ADMIN_INFO = "bd_session_admin_info";

        /// <summary>
        /// 验证码
        /// </summary>
        public const string SESSION_CODE = "bd_session_code";

        /// <summary>
        /// 返回上一页
        /// </summary>
        public const string COOKIE_URL_REFERRER = "bd_cookie_url_referrer";
       
        

    }
}
