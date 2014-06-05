<%@ Page Language="C#" AutoEventWireup="true" Inherits="BigDogShop.Web.Index" CodeBehind="Index.aspx.cs" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>BigDog商城,货到付款,放心购物!</title>
    <link rel="shortcut icon" href="favicon.ico" />
    <link href="Css/Base.css" rel="stylesheet" />
    <link href="Css/Rotation.css" rel="stylesheet" />
    <script type="text/javascript" src="Js/jquery-1.4.2.min.js"></script>
    <script type="text/javascript" src="Js/Effact/Rotation2.js"></script>
    <script type="text/javascript" src="Js/Effact/LazyLoad.js"></script>
    <script src="Js/index.js"></script>
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
                    <asp:Repeater ID="rpt_bd" runat="server">
                        <ItemTemplate>
                            <a href="#" target="_blank">
                                <img src='/Images/Rotate/Slide/<%#Eval("Image_Url") %>'></img></a>
                        </ItemTemplate>
                    </asp:Repeater>
                </div>
                <div class="tuan_index">
                    <div class="tabs">
                        <ul class="tabtn">
                            <li>团购</li>
                            <li>特产中国</li>
                            <li>新品</li>
                            <li>特卖</li>
                        </ul>

                        <div class="sublist">
                            <ul>
                                <li>
                                    <ul>
                                        <asp:Repeater ID="rpt_tuan" runat="server">
                                            <ItemTemplate>
                                                <a href="#" target="_blank">
                                                    <img src="/images/rotate/slide/<%#Eval("img_url") %>" alt="团购" /></a>
                                            </ItemTemplate>
                                        </asp:Repeater>
                                    </ul>


                                </li>
                                <li>
                                    <ul>
                                        <asp:Repeater ID="rpt_specialty" runat="server">
                                            <ItemTemplate>
                                                <a href="#" target="_blank">
                                                    <img src="/images/rotate/slide/<%#Eval("img_url") %>" alt="特产" /></a>
                                            </ItemTemplate>
                                        </asp:Repeater>
                                    </ul>

                                </li>
                                <li>
                                    <ul>
                                        <asp:Repeater ID="rpt_newgoods" runat="server">
                                            <ItemTemplate>
                                                <a href="#" target="_blank">
                                                    <img src="/images/rotate/slide/<%#Eval("img_url") %>" alt="新品" /></a>
                                            </ItemTemplate>
                                        </asp:Repeater>
                                    </ul>


                                </li>
                                <li>
                                    <ul>

                                        <asp:Repeater ID="rpt_" runat="server">
                                            <ItemTemplate>
                                                <a href="#" target="_blank">
                                                    <img src="/images/rotate/slide/<%#Eval("img_url") %>" alt="特卖" /></a>
                                            </ItemTemplate>
                                        </asp:Repeater>
                                    </ul>

                                </li>
                            </ul>
                        </div>
                    </div>

                </div>
            </div>
        </div>

        <!--家电通讯-->
        <div id="electronics">
            <div class="left_nav">
            </div>
            <div class="center_nav">
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
        <Service:Se ID="se1" runat="server" />
        <Link:Li ID="li1" runat="server" />
    </form>
</body>
</html>
