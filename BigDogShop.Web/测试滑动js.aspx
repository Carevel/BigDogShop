<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="测试滑动js.aspx.cs" Inherits="BigDogShop.Web.测试滑动js" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script src="Js/jquery-1.4.1.min.js"></script>
    <style type="text/css">
        #slideBox
        {
            width: 680px;
            height: 150px;
            background: #ccc;
            margin-right: auto;
            margin-left: auto;
        }

            #slideBox ul
            {
                padding: 0px;
                margin: 0px;
                position: absolute;
            }

                #slideBox ul li
                {
                    list-style: none;
                    float: left;
                    width: 170px;
                    height: 150px;

                }
    </style>
    <script type="text/javascript">
        window.onload = function () {
            var timer = null;
            var Objli = document.getElementsByClassName('slidepic');
            //alert(Objli.length);
            Objli = Object + Object;
            alert(Objli.length);
            function slide() {
                var picBox = document.getElementById("picBox");
                //picBox =picBox+ picBox;
                var slideBox = document.getElementById("slideBox");
                picBox.style.left = picBox.offsetLeft - 1 + "px";
                if (picBox.offsetLeft == 0)
                {
                    clearInterval(timer);
                }
            }
            for (var i = 0; i < Objli.length; i++) {
                Objli[i].onmouseover=function () {
                    clearInterval(timer);
                };
                Objli[i].onmouseout=function () {
                    timer = setInterval(slide, 50);
                };
            }
            timer= setInterval(slide, 50);


        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <div id="slideBox">
                <ul id="picBox">
                    <li class="slidepic"><a href="#">
                        <img src="Images/Rotate/Slide/slide111.jpg" /></a></li>
                    <li class="slidepic"><a href="#">
                        <img src="Images/Rotate/Slide/slide111.jpg" /></a></li>
                    <li class="slidepic"><a href="#">
                        <img src="Images/Rotate/Slide/slide111.jpg" /></a></li>
                    <li class="slidepic"><a href="#">
                        <img src="Images/Rotate/Slide/slide111.jpg" /></a></li>
                </ul>
            </div>
        </div>
    </form>
</body>
</html>
