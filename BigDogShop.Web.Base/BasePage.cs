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
using BigDogShop.Common;

namespace BigDogShop.Web.Base
{
    public partial class BasePage : System.Web.UI.Page
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
                    UserInfo user = UserBLL.GetById(id);
                    StringBuilder html = new StringBuilder();
                    html.Append("<ul>");
                    if (user.Id == 5)
                    {
                        string name = string.IsNullOrEmpty(user.Nick_Name) ? user.Password : user.Nick_Name;
                        html.AppendFormat(" <li id=\"user_ss\"><a href=\"javascript:void();\"><span style=\"float:left\">{0}</span></a></li>", user.Nick_Name);
                    }
                    else
                    {
                        string name = string.IsNullOrEmpty(user.Nick_Name) ? user.Password : user.Nick_Name;
                    }
                    html.Append(" <li><a href=\"Cart.aspx\">我的购物车</a></li>");
                    html.Append(" <li><a href=\"CenterInfo.aspx\">个人中心</a></li>");
                    html.Append(" <li><a href=\"Login.aspx?type=0\">退出</a></li>");
                    html.Append("</ul>");
                    htm.InnerHtml = html.ToString();
                }
            }
        }

        //判断是否已登录
       
        public void SetMenuVisitedV2(string menuId)
        {
            if (this.Form.FindControl(menuId) != null)
            {
                HtmlGenericControl nav = (HtmlGenericControl)this.Form.FindControl(menuId);
                nav.Attributes.Add("style", "background:Green");
            }
        }
        //public void BindUserInfoById(int id)
        //{
        //    //Users u = Users.GetInfo(id);
        //    UserInfo u = UserBLL.GetById(id);
        //    if (this.Form.FindControl("lbl_love") != null)
        //    {
        //        Label l_love = this.Form.FindControl("lbl_love") as Label;
        //    }

        //    if (this.Form.FindControl("user_photo") != null)
        //    {
        //        HtmlImage img = (HtmlImage)this.FindControl("user_photo");
        //        if (u.User_Photo_Url.ToString() == "")
        //        {
        //            u.User_Photo_Url = "unknow.jpg";
        //        }
        //        img.Src = "~/UploadImage/User/" + u.User_Photo_Url.ToString();

        //    }

        //    if (this.Form.FindControl("lbl_name") != null)
        //    {
        //        Label l_nick_name = this.Form.FindControl("lbl_name") as Label;
        //        l_nick_name.Text = string.IsNullOrEmpty(u.Password) ? "无" : u.Nick_Name;
        //    }

        //    if (this.Form.FindControl("lbl_nick_name2") != null)
        //    {
        //        Label lbl_nick_name2 = this.Form.FindControl("lbl_nick_name2") as Label;
        //        lbl_nick_name2.Text = string.IsNullOrEmpty(u.User_Photo_Url) ? u.User_Photo_Url : u.Nick_Name;
        //    }

        //    if (this.Form.FindControl("lbl_socore") != null)
        //    {
        //        Label l_score = this.Form.FindControl("lbl_socore") as Label;
        //        l_score.Text = string.IsNullOrEmpty(u.Score.ToString()) ? "0" : u.Score.ToString();
        //    }
        //    //if (this.Form.FindControl("lbl_special") != null)
        //    //{
        //    //    Label l_special = this.Form.FindControl("lbl_special") as Label;
        //    //    l_special.Text = string.IsNullOrEmpty(u.Special) ? "无" : u.Special;
        //    //}

        //    //if (this.Form.FindControl("lbl_leader_begin") != null)
        //    //{
        //    //    Label l_leader_begin = this.Form.FindControl("lbl_leader_begin") as Label;
        //    //    l_leader_begin.Text = string.IsNullOrEmpty(u.Income) ? "无" : u.Income;
        //    //}

        //    if (this.Form.FindControl("lbl_club") != null)
        //    {
        //        Label l_club = this.Form.FindControl("lbl_club") as Label;
        //        l_club.Text = string.IsNullOrEmpty(u.User_Name) ? "无" : u.User_Name;
        //    }

        //    if (this.Form.FindControl("lbl_contact") != null)
        //    {
        //        Label l_content = this.Form.FindControl("lbl_contact") as Label;
        //        l_content.Text = string.IsNullOrEmpty(u.Phone_Number) ? "无" : u.Phone_Number;
        //    }
        //    if (this.Form.FindControl("lbl_email") != null)
        //    {
        //        Label l_email = this.Form.FindControl("lbl_email") as Label;
        //        l_email.Text = u.E_Mail == "N" ? "未验证" : "已验证";
        //    }
        //    if (this.Form.FindControl("lbl_hobby") != null)
        //    {
        //        Label l_id_card = this.Form.FindControl("lbl_hobby") as Label;
        //        l_id_card.Text = u.Hobby;
        //    }
        //    if (this.Form.FindControl("lbl_leader_date") != null)
        //    {
        //        Label l_leader_begin = this.Form.FindControl("lbl_leader_date") as Label;
        //        //l_leader_begin.Text = string.IsNullOrEmpty(u.Leader_begin.ToString("yyyy-MM-dd")) ? "无" : u.Leader_begin.ToString("yyyy-MM-dd");
        //        l_leader_begin.Text = string.IsNullOrEmpty(u.Income) ? "无" : u.Income;
        //    }
        //    //if (this.Form.FindControl("is_vip") != null)
        //    //{
        //    //    Label l_id_card = this.Form.FindControl("is_vip") as Label;
        //    //    l_id_card.Text = string.IsNullOrEmpty(u.Isvvip) ? "无" : u.Isvvip;
        //    //}
        //    if (this.Form.FindControl("lbl_user_score") != null)
        //    {
        //        Label l_score = this.Form.FindControl("lbl_user_score") as Label;
        //        int score = u.Score / 1000;
        //        if (score >= 0 && score <= 1)
        //        {
        //            l_score.Text = "1级";
        //        }
        //        else
        //        {
        //            if (score > 1 && score <= 3)
        //            {
        //                l_score.Text = "2级";
        //            }
        //            else if (score > 3 && score <= 5)
        //            {
        //                l_score.Text = "3级";
        //            }
        //            else if (score > 5 && score <= 7)
        //            {
        //                l_score.Text = "4级";
        //            }
        //        }
        //    }
        //    if (this.Form.FindControl("lbl_user_type") != null)
        //    {
        //        Label l_user_type = this.Form.FindControl("lbl_user_type") as Label;
        //        switch (u.User_Type.ToString())
        //        {
        //            case "1":
        //                l_user_type.Text = "普通用户";
        //                break;
        //            case "2":
        //                l_user_type.Text = "领队";
        //                break;
        //            case "3":
        //                l_user_type.Text = "俱乐部";
        //                break;
        //            case "4":
        //                l_user_type.Text = "商家用户";
        //                break;
        //            case "5":
        //                l_user_type.Text = "Vip用户";
        //                break;
        //        }
        //    }
        //}
    }
}
