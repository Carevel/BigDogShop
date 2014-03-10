using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.SessionState;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Text;
using BigDogShop.Model;
using BigDogShop.BLL;

namespace BigDogShop.Web.Base
{
    public  partial class BasePageInfo : System.Web.UI.Page
    {
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            if (Session["user_id"] == null)
            {

                HtmlGenericControl htm = (HtmlGenericControl)this.FindControl("top_header");
                if (htm != null)
                {
                    StringBuilder html = new StringBuilder();
                    html.Append("<ul>");
                    html.Append(" <li><a href=\"Login.aspx\">登录</a>｜<a href=\"Register.aspx\">注册</a></li>");
                    html.AppendFormat("  <li><a href=\"Cart.aspx\"><div class=\"cart\"></div></a></li>");
                    html.Append("</ul>");
                    htm.InnerHtml = html.ToString();

                }
            }
            else
            {
                int id = Convert.ToInt32(Session["user_id"].ToString());
                HtmlGenericControl htm = (HtmlGenericControl)this.FindControl("top_header");
                if (htm != null)
                {
                    //Users user = Users.GetInfo(Convert.ToInt32(Session["user_id"].ToString()));
                    UserInfo user = UserBLL.GetById(Convert.ToInt32(Session["user_id"].ToString()));
                    StringBuilder html = new StringBuilder();
                    html.Append("<ul>");


                    if (user.User_Type == 5)
                    {
                        string name = string.IsNullOrEmpty(user.Nick_Name) ? Session["user_name"].ToString() : user.Nick_Name;
                        html.AppendFormat(" <li id=\"user_ss\"><a href=\"javascript:void();\"><div><span style=\"float:left\">{0}</span></a></li>", user.Nick_Name);
                    }
                    else
                    {
                        string name = string.IsNullOrEmpty(user.Nick_Name) ? Session["user_name"].ToString() : user.Nick_Name;
                    }
                    html.Append(" <li><a href=\"Cart.aspx\">我的购物车</a></li>");
                    html.Append(" <li><a href=\"CenterInfo.aspx\">个人中心</a></li>");
                    html.Append(" <li><a href=\"Login.aspx?type=0\">退出</a></li>");
                    html.Append("</ul>");
                    htm.InnerHtml = html.ToString();
                    //SetLeftMenu(id);
                    BindUserInfoById(id);
                }
            }
        }

        public void SetMenuVisited(string menuId)
        {
            if (this.Form.FindControl(menuId) != null)
            {
                HtmlGenericControl nav = (HtmlGenericControl)this.Form.FindControl(menuId);
                nav.Attributes.Add("style", "background:#bb0404");
            }
        }
        public void SetMenuVisitedV2(string menuId)
        {
            if (this.Form.FindControl(menuId) != null)
            {
                HtmlGenericControl nav = (HtmlGenericControl)this.Form.FindControl(menuId);
                nav.Attributes.Add("style", "background:Green");
            }
        }
        public void BindUserInfoById(int id)
        {
            //Users u = Users.GetInfo(id);
            UserInfo u = UserBLL.GetById(id);
            if (this.Form.FindControl("lbl_love") != null)
            {
                Label l_love = this.Form.FindControl("lbl_love") as Label;
            }

            if (this.Form.FindControl("user_photo") != null)
            {
                HtmlImage img = (HtmlImage)this.FindControl("user_photo");
                //if (u.Birthday.ToString() == "")
                //{
                //    u.Birthday = "unknow.jpg";
                //}
                //img.Src = "~/UploadImage/User/" + u.Birthday.ToString();

            }

            if (this.Form.FindControl("lbl_name") != null)
            {
                Label l_nick_name = this.Form.FindControl("lbl_name") as Label;
                l_nick_name.Text = string.IsNullOrEmpty(u.Password) ? "无" : u.Nick_Name;
            }

            if (this.Form.FindControl("lbl_nick_name2") != null)
            {
                Label lbl_nick_name2 = this.Form.FindControl("lbl_nick_name2") as Label;
                lbl_nick_name2.Text = string.IsNullOrEmpty(u.User_Photo_Url) ? u.User_Photo_Url : u.Nick_Name;
            }

            if (this.Form.FindControl("lbl_socore") != null)
            {
                Label l_score = this.Form.FindControl("lbl_socore") as Label;
                l_score.Text = string.IsNullOrEmpty(u.Score.ToString()) ? "0" : u.Score.ToString();
            }
            //if (this.Form.FindControl("lbl_special") != null)
            //{
            //    Label l_special = this.Form.FindControl("lbl_special") as Label;
            //    l_special.Text = string.IsNullOrEmpty(u.Special) ? "无" : u.Special;
            //}

            if (this.Form.FindControl("lbl_leader_begin") != null)
            {
                Label l_leader_begin = this.Form.FindControl("lbl_leader_begin") as Label;
                l_leader_begin.Text = string.IsNullOrEmpty(u.Income) ? "无" : u.Income;
            }

            if (this.Form.FindControl("lbl_club") != null)
            {
                Label l_club = this.Form.FindControl("lbl_club") as Label;
                l_club.Text = string.IsNullOrEmpty(u.User_Name) ? "无" : u.User_Name;
            }

            //if (this.Form.FindControl("lbl_contact") != null)
            //{
            //    Label l_content = this.Form.FindControl("lbl_contact") as Label;
            //    l_content.Text = string.IsNullOrEmpty(u.Telephone) ? "无" : u.Telephone;
            //}
            if (this.Form.FindControl("lbl_email") != null)
            {
                Label l_email = this.Form.FindControl("lbl_email") as Label;
                l_email.Text = u.E_Mail == "N" ? "未验证" : u.E_Mail.ToString();
            }
            if (this.Form.FindControl("lbl_hobby") != null)
            {
                Label l_id_card = this.Form.FindControl("lbl_hobby") as Label;
                l_id_card.Text = u.Hobby;
            }
            if (this.Form.FindControl("lbl_leader_date") != null)
            {
                Label l_leader_begin = this.Form.FindControl("lbl_leader_date") as Label;
                //l_leader_begin.Text = string.IsNullOrEmpty(u.Leader_begin.ToString("yyyy-MM-dd")) ? "无" : u.Leader_begin.ToString("yyyy-MM-dd");
                l_leader_begin.Text = string.IsNullOrEmpty(u.Income) ? "无" : u.Income;
            }
            //if (this.Form.FindControl("is_vip") != null)
            //{
            //    Label l_id_card = this.Form.FindControl("is_vip") as Label;
            //    l_id_card.Text = string.IsNullOrEmpty(u.Isvvip) ? "无" : u.Isvvip;
            //}
            if (this.Form.FindControl("lbl_user_score") != null)
            {
                Label l_score = this.Form.FindControl("lbl_user_score") as Label;
                int score = u.Score / 1000;
                if (score >= 0 && score <= 1)
                {
                    l_score.Text = "1级";
                }
                else
                {
                    if (score > 1 && score <= 3)
                    {
                        l_score.Text = "2级";
                    }
                    else if (score > 3 && score <= 5)
                    {
                        l_score.Text = "3级";
                    }
                    else if (score > 5 && score <= 7)
                    {
                        l_score.Text = "4级";
                    }
                }
            }
            if (this.Form.FindControl("lbl_user_type") != null)
            {
                Label l_user_type = this.Form.FindControl("lbl_user_type") as Label;
                switch (u.User_Type.ToString())
                {
                    case "1":
                        l_user_type.Text = "普通用户";
                        break;
                    case "2":
                        l_user_type.Text = "领队";
                        break;
                    case "3":
                        l_user_type.Text = "俱乐部";
                        break;
                    case "4":
                        l_user_type.Text = "商家用户";
                        break;
                    case "5":
                        l_user_type.Text = "Vip用户";
                        break;
                }
            }
        }

        public string EncryptStr(string str)
        {
            int n = str.IndexOf("@");
            string result = string.Empty;
            for (int i = 1; i < 4; i++)
            {
                string oldStr = str.Substring(i, 1);
                string newStr = "*";

                str = str.Replace(oldStr, newStr);
            }
            return str;
        }
        //public void SetLeftMenu(int id)
        //{
        //    List<string> v1 = new List<string>();
        //    List<string> v2 = new List<string>();
        //    List<string> v3 = new List<string>();
        //    List<string> v4 = new List<string>();
        //    List<string> v5 = new List<string>();
        //    StringBuilder sTitle = new StringBuilder();
        //    sTitle.Append("<li  runat=\"server\" id=\"n_1\" class=\"body_no\"><a href=\"updateUserInfo.aspx\">修改个人信息</a></li>");
        //    sTitle.Append("<li  runat=\"server\" id=\"n_2\" class=\"body_no\"><a href=\"ModifyPwd.aspx\">修改密码</a></li>");
        //    sTitle.Append("<li  runat=\"server\" id=\"n_3\" class=\"body_no\"><a href=\"Contactslist.aspx\">联系人管理</a></li>");
        //    sTitle.Append("<li  runat=\"server\" id=\"n_4\" class=\"body_no\"><a href=\"Visual.aspx\">视觉与百科</a></li>");

        //    //普通用户
        //    v1.AddRange(new string[] { "OrderDetails", "Centerinfo", "ModifyPwd", "Visual", "ManagerContects", "ContactEdit", "Order_list.aspx" });

        //    //领队用户权限
        //    v2.AddRange(new string[] { "OrderDetails", "Centerinfo", "ModifyPwd", "Visual", "ManagerContects", "ContactEdit", "Order_list.aspx", "CentificateEdit", "ExprienceEdit" });

        //    //超级管理员
        //    v3.AddRange(new string[] { });


        //    StringBuilder com_user = new StringBuilder();
        //    com_user.Append(" <li id=\"n_22\" class=\"body_no\" ><a href=\"visual.aspx\">视觉与百科短消息</a></li>");
        //    v1.AddRange(new string[] { "visual" });

        //    StringBuilder leader = new StringBuilder();
        //    leader.Append(" <li id=\"n_5\" class=\"body_no\"><a href=\"centificate.aspx\">证书管理</a></li>");
        //    leader.Append(" <li id=\"n_6\" class=\"body_no\"><a href=\"Experience.aspx\">户外经历</a></li>");
        //    leader.Append(" <li id=\"n_7\" class=\"body_no\"><a href=\"leaderDetail.aspx\">领队信息</a></li>");
        //    leader.Append(" <li id=\"n_22\" class=\"body_no\" ><a href=\"visual.aspx\">视觉与百科短消息</a></li>");
        //    v2.AddRange(new string[] { "centificate", "experience", "leaderdetail" });

        //    StringBuilder Seller = new StringBuilder();
        //    Seller.Append(" <li id=\"n_22\" class=\"body_no\" ><a href=\"Equipment.aspx\">装备发布</a></li>");
        //    Seller.Append(" <li id=\"n_9\" class=\"body_no\"><a href=\"SellerInfo.aspx\">商家信息</a></li>");
        //    Seller.Append(" <li id=\"n_22\" class=\"body_no\" ><a href=\"visual.aspx\">视觉与百科短消息</a></li>");
        //    v3.AddRange(new string[] { "LineList", "SignUp", "LineComment", "Visual" });

        //    v4.AddRange(new string[] { "Equipment", "SellerInfo", "VisualComments" });

        //    StringBuilder admin = new StringBuilder();
        //    admin.Append(" <li id=\"n_11\" class=\"body_no\" ><a href=\"Ad.aspx\">滚动广告管理</a></li>");
        //    admin.Append(" <li id=\"n_12\" class=\"body_no\" ><a href=\"LineCheck.aspx\">线路审核</a></li>");
        //    admin.Append(" <li id=\"n_13\" class=\"body_no\" ><a href=\"EquipmentCheck.aspx\">装备审核</a></li>");
        //    admin.Append(" <li id=\"n_14\" class=\"body_no\" ><a href=\"UpGrade.aspx\">用户升级审核</a></li>");
        //    admin.Append(" <li id=\"n_15\" class=\"body_no\" ><a href=\"CustomerService.aspx\">客服管理</a></li>");
        //    admin.Append(" <li id=\"n_16\" class=\"body_no\" ><a href=\"ModifyUser.aspx\">修改用户信息</a></li>");
        //    admin.Append(" <li id=\"n_17\" class=\"body_no\" ><a href=\"OrderReturn.aspx\">退款订单处理</a></li>");
        //    admin.Append(" <li id=\"n_18\" class=\"body_no\" ><a href=\"LineSignUpInfo.aspx\">线路报名信息</a></li>");
        //    admin.Append(" <li id=\"n_19\" class=\"body_no\" ><a href=\"LineComment.aspx\">滚动广告管理</a></li>");
        //    admin.Append(" <li id=\"n_20\" class=\"body_no\" ><a href=\"Report.aspx\">网站访问统计</a></li>");
        //    v5.AddRange(new string[] { "ad", "linecheck", "equipmentcheck", "upgrade", "customerService", "modifyUser", "orderreturn", "linesignupinfo", "linecomment", "report" });

        //    HtmlGenericControl left_menu = (HtmlGenericControl)this.FindControl("left_menu");
        //    if (left_menu != null)
        //    {
        //        left_menu.InnerHtml = "";
        //        string type = Session["user_type"] == null ? "" : Session["user_type"].ToString();
        //        if (type == "1")
        //        {
        //            //List<string> status = Users.GetUserStatus(Convert.ToInt32(Session["user_id"]));
        //            List<string> status = UserBLL.GetUserStatus(Convert.ToInt32(Session["user_id"]));
        //            if (status != null)
        //            {
        //                if (status[0] == "S" && status[1] == "2")
        //                {
        //                    com_user.Append("<li  id=\"n_4\" class=\"body_no\"><a href=\"Centerleader.aspx\">升级为领队</a></li>");
        //                }
        //                else if (status[0] == "S" && status[1] == "3")
        //                {
        //                    com_user.Append(" <li id=\"n_10\" class=\"body_no\"><a href=\"Club.aspx \">升级为俱乐部</a></li>");
        //                }
        //                else if (status[0] == "S" && status[1] == "4")
        //                {
        //                    com_user.Append(" <li id=\"n_11\" class=\"body_no\"><a href=\"Seller.aspx \">升级为商家</a></li>");
        //                }
        //                else
        //                {
        //                    com_user.Append("<li  id=\"n_4\" class=\"body_no\"><a href=\"Centerleader.aspx\">升级为领队</a></li>");
        //                    com_user.Append(" <li id=\"n_10\" class=\"body_no\"><a href=\"Club.aspx \">升级为俱乐部</a></li>");
        //                    com_user.Append(" <li id=\"n_11\" class=\"body_no\"><a href=\"Seller.aspx \">升级为商家</a></li>");
        //                    v1.AddRange(new string[] { "Centerleader", "Club", "Seller" });
        //                }
        //            }
        //            left_menu.InnerHtml = com_user.ToString();
        //            if (!IsContain(v1, item => { return HttpContext.Current.Request.Url.ToString().ToLower().IndexOf(item.ToLower()) > 0; }))
        //            {
        //                HttpContext.Current.Response.Redirect("404.aspx", false);
        //            }
        //        }
        //        else if (type == "2")
        //        {
        //            left_menu.InnerHtml = sTitle.ToString() + leader.ToString();
        //            if (!IsContain(v2, item => { return HttpContext.Current.Request.Url.ToString().ToLower().IndexOf(item.ToLower()) > 0; }))
        //            {
        //                HttpContext.Current.Response.Redirect("404.aspx", false);
        //            }
        //        }
        //        //else if (type == "3")
        //        //{
        //        //    left_menu.InnerHtml = com_user.ToString() + club.ToString();
        //        //    if (!IsContain(v1, item => { return HttpContext.Current.Request.Url.ToString().ToLower().IndexOf(item.ToLower()) > 0; }))
        //        //    {
        //        //        HttpContext.Current.Response.Redirect("404.aspx", false);
        //        //    }
        //        //}
        //        else if (type == "4")
        //        {
        //            left_menu.InnerHtml = sTitle.ToString() + Seller.ToString();
        //            //if (!IsContain(v4, item => { return HttpContext.Current.Request.Url.ToString().ToLower().IndexOf(item.ToLower()) > 0; }))
        //            //{
        //            //    HttpContext.Current.Response.Redirect("404.aspx", false);
        //            //}
        //        }
        //        else if (type == "5")
        //        {
        //            left_menu.InnerHtml = sTitle.ToString() + admin.ToString();
        //            //if (!IsContain(v5, item => { return HttpContext.Current.Request.Url.ToString().ToLower().IndexOf(item.ToLower()) > 0; }))
        //            //{
        //            //    HttpContext.Current.Response.Redirect("404.aspx", false);
        //            //}
        //        }
        //    }
        //}

        /// <summary>
        /// 判断是否包含每个字符串
        /// </summary>
        /// <param name="list"></param>
        /// <param name="hander"></param>
        /// <returns></returns>
        public static bool IsContain(List<string> list, Func<string, bool> hander)
        {
            bool result = false;
            for (int i = 0; i < list.Count; i++)
            {
                if (hander(list[i]))
                {
                    result = true;
                    break;
                }
            }
            return result;
        }
    }
}
