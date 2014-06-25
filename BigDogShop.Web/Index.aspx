<%@ Page Language="C#" AutoEventWireup="true" Inherits="BigDogShop.Web.Index" CodeBehind="Index.aspx.cs" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>货到付款,放心购物!</title>
    <link rel="shortcut icon" href="favicon.ico" />
    <link href="Css/Base.css" rel="stylesheet" />
    <link href="Css/Rotation.css" rel="stylesheet" />
    <script type="text/javascript" src="Js/jquery-1.4.2.min.js"></script>
    <script type="text/javascript" src="Js/Effact/Rotation2.js"></script>
    <script type="text/javascript" src="Js/Effact/LazyLoad.js"></script>
    <script src="Js/index.js"></script>
    <script src="Js/Effact/Slide.js"></script>
    <script type="text/javascript">
        $(document).ready(function () {
            imgLazyLoad();
        });
    </script>
</head>
<body id="body">
    <form id="form1" runat="server">

        <Top:To ID="to1" runat="server" />
        <Header:He ID="he1" runat="server" />
        <HeaderNav:Hn ID="hn1" runat="server" />
        <div class="watch">
            <div class="o_slide">

                <asp:Label ID="lbl1" runat="server"></asp:Label>
                <!--滚动图片-->
                <div class="imageRotation">
                    <div class="imageBox">
                        <asp:Repeater ID="rpt_news" runat="server">
                            <ItemTemplate>
                                <a href="#" target="_blank">
                                    <img src="/Images/Rotate/Slide/<%#Eval("Image_Url") %>" alt="图片出错" />
                                </a>
                            </ItemTemplate>
                        </asp:Repeater>
                    </div>
                    <%-- <div class="titleBox">
                        <p class="active"><span>图片1</span></p>
                        <p>图片2</p>
                        <p>图片3</p>
                        <p>图片4</p>
                        <p>图片5</p>
                        <p>图片6</p>
                    </div>--%>
                    <div class="icoBox">
                        <span class="active" rel="1"></span>
                        <span rel="2"></span>
                        <span rel="3"></span>
                        <span rel="4"></span>
                        <span rel="5"></span>
                        <span rel="6"></span>
                    </div>
                </div>

                <!--滑动图片-->
                <div class="imageSlide">
                    <ul class="ul_s">
                        <asp:Repeater ID="rpt_slide" runat="server">
                            <ItemTemplate>
                                <li>
                                    <a href="#" target="_blank">
                                        <img src='/Images/Rotate/Slide/<%#Eval("Image_Url") %>'></img></a>
                                </li>
                            </ItemTemplate>
                        </asp:Repeater>
                    </ul>

                </div>
            </div>
            <div class="o_news">
                <div class="a_right">
                    <asp:Repeater ID="rpt_corner" runat="server">
                        <ItemTemplate>
                            <a href="#" target="_blank">
                                <img src='/Images/Rotate/Slide/<%#Eval("Image_Url") %>'></img></a>
                        </ItemTemplate>
                    </asp:Repeater>
                </div>

                <!--轮番-->
                <div class="wgt">
                    <div class="wgt_tabs">
                        <a class="blur_in" href="#">团购</a>
                        <a class="blur_in" href="#">特产中国</a>
                        <a class="blur_in" href="#">新品</a>
                        <a class="blur_in" href="#">特卖</a>
                        <a class="blur_in" href="#">大牌</a>
                    </div>
                    <div class="wgt_list">
                        <div class="wgt_box">
                            <ul>
                                <asp:Repeater ID="rpt_tuan" runat="server">
                                    <ItemTemplate>
                                        <li>
                                            <a href="#" target="_blank">
                                                <img src="/images/rotate/tabs/tuan/<%#Eval("Image_Url") %>" alt="团购" /></a>
                                        </li>

                                    </ItemTemplate>
                                </asp:Repeater>
                            </ul>
                        </div>
                        <div class="wgt_box">
                            <ul>
                                <asp:Repeater ID="rpt_specialty" runat="server">
                                    <ItemTemplate>
                                        <li>
                                            <a href="#" target="_blank">
                                                <img src="/images/rotate/tabs/special/<%#Eval("Image_Url") %>" alt="特产" /></a>
                                        </li>

                                    </ItemTemplate>
                                </asp:Repeater>
                            </ul>
                        </div>
                        <div class="wgt_box">
                            <ul>
                                <asp:Repeater ID="rpt_newgoods" runat="server">
                                    <ItemTemplate>
                                        <li>
                                            <a href="#" target="_blank">
                                                <img src="/images/rotate/tabs/newgoods/<%#Eval("Image_Url") %>" alt="新品" /></a>

                                        </li>

                                    </ItemTemplate>
                                </asp:Repeater>
                            </ul>
                        </div>
                        <div class="wgt_box">
                            <ul>
                                <asp:Repeater ID="rpt_activity" runat="server">
                                    <ItemTemplate>
                                        <li>
                                            <a href="#" target="_blank">
                                                <img src="/images/rotate/tabs/activity/<%#Eval("Image_Url") %>" alt="特卖" /></a>
                                        </li>

                                    </ItemTemplate>
                                </asp:Repeater>
                            </ul>
                        </div>
                        <div class="wgt_box">
                            <ul>
                                <asp:Repeater ID="Repeater1" runat="server">
                                    <ItemTemplate>
                                        <li>
                                            <a href="#" target="_blank">
                                                <img src="/images/rotate/tabs/activity/<%#Eval("Image_Url") %>" alt="大牌" /></a>
                                        </li>
                                    </ItemTemplate>
                                </asp:Repeater>
                            </ul>
                        </div>
                    </div>
                </div>

            </div>
        </div>
        <div class="floor_list">
            <div class="lifeshow">
                <div class="fl_notice"></div>
                <div class="showlist">
                    <div class=""></div>
                </div>
                <div class="fa"></div>
            </div>
            <!--家电通讯-->
            <div id="electronics">
                <div class="left_nav">
                    <asp:Repeater ID="rpt_home" runat="server" >
                        <ItemTemplate>
                            <div class=""></div>
                        </ItemTemplate>
                    </asp:Repeater>
                </div>
                <div class="center_nav">
                    <asp:Repeater ID="rpt_home_center" runat="server">
                        <ItemTemplate>
                            <div class=""></div>
                        </ItemTemplate>
                    </asp:Repeater>
                </div>
            </div>
            <!--电脑数码-->
            <div id="digitals">
                <div class="left_nav">
                </div>
                <div class="center_nav">
                </div>
            </div>
            <!--服饰鞋包-->
            <div id="clothing">
                <div class="left_nav">
                </div>
                <div class="center_nav">
                </div>
            </div>
            <!--美容珠宝-->
            <div id="jewellery">
                <div class="left_nav">
                </div>
                <div class="center_nav">
                </div>
            </div>
        </div>

        <Service:Se ID="se1" runat="server" />
        <Link:Li ID="li1" runat="server" />
    </form>
</body>
</html>
