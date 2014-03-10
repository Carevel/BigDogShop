<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UserCenter.aspx.cs" Inherits="BigDogShop.Web.UserCenter" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
        <link href="Css/Base.css" rel="stylesheet" />
     <link href="Css/User/User.base.2014.css" rel="stylesheet" />

    <script  type="text/javascript" src="Js/jquery-1.4.2.min.js"></script>
    <script  type="text/javascript" src="Js/Effact/LazyLoad.js"></script>
    <script  type="text/javascript" src="Js/ajaxfileupload.js"></script>
    <script  type="text/javascript" src="Js/Effact/Left_Menu.js"></script>
    <script  type="text/javascript" src="Js/Effact/jquery.cityselect.js"></script>
    <script  type="text/javascript" src="Js/UploadUser.js"></script>
    <script type="text/javascript">
        $(document).ready(function () {
            $("#city_1").citySelect({
                prov: "北京",
                nodata: "none"
            });
            $("#change_user_photo").click(function () {

            });

        });

    </script>
</head>
<body>
    <form id="form1" runat="server">
     <!--#include file='~/Include/MenuHeader.txt'-->
    <div id="container">
        <!--#include file='~/Include/left_nav.txt'-->
        <div class="info_container">
            <div class="info_container">
                <div class="title_info">
                    <span><strong>帐户信息</strong></span>
                   
                </div>
            </div>
            <div class="user_info">
                <!--#Include file='~/Include/UserInfoList.txt-->
                <div class="info_detail_left">
                    <table>
                        <tr>
                            <td>用户名：</td>
                            <td>
                                <asp:Label ID="txt_user_name" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>用户等级：</td>
                            <td>
                                <asp:Label ID="lbl_user_score" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>会员类型：</td>
                            <td>
                                <asp:Label ID="lbl_user_type" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>昵称：</td>
                            <td>
                                <asp:TextBox ID="txt_nick_name"  CssClass="tx_input"  runat="server"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>手机号码：</td>
                           <td>
                               <asp:TextBox ID="txt_phone_number"  CssClass="tx_input"  runat="server"></asp:TextBox>
                           </td>
                        </tr>
                        <tr>
                            <td>邮箱：</td>
                            <td>
                                <a href="#"><asp:Label ID="lbl_email" runat="server"></asp:Label></a>
                            </td>
                        </tr>
                        <tr>
                            <td>真实姓名：</td>
                            <td>
                                <asp:TextBox ID="txt_real_name"  CssClass="tx_input"  runat="server"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>所在地：</td>
                            <td>
                               <div id="city_1">
                                    <select class="prov" runat="server" id="ddl_prov"></select>  
                                    <select class="city" runat="server" id="ddl_city" disabled="disabled"></select> 
                                    <select class="dist" runat="server" id="ddl_dist" disabled="disabled"></select> 
                               </div>
                                
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Button ID="btn_confirm" runat="server" Text="提交" OnClick="btn_confirm_Click" style="height: 26px" />
                            </td>
                        </tr>
                    </table>
                </div>
                <div class="info_detail_right">
                    <div class="photo_container">
                        <img id="user_photo" runat="server" src="" alt=""  />    
                    </div>
                   <br />
                    <input type="file" id="fileToUpload" runat="server" />
                    <input type="button" id="btn_upload" runat="server" value="确定修改" />
                </div>
            </div>
        </div>


    </div>

    </form>
</body>
</html>
