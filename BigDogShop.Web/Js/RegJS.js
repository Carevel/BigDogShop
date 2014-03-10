$(document).ready(function () {
    var arrObj = new Array();
    arrObj[0] = 'txt_user_name';
    arrObj[1] = 'txt_password';
    arrObj[2] = 'txt_confirm_password';
    arrObj[3] = 'txt_email';
    var textObj=new Array();
    textObj[0]='输入用户名，字母，数字或下线组合';
    textObj[1]='6~12位字符，可使用字母，数字或符号的组合，不建议使用纯字母，纯数字，纯符号';
    textObj[2]='请再次输入密码';
    textObj[3] = '用于用户注册验证和向您推荐信息';
    var ob = $("input[rel='txt_info']");
    //alert(textObj[3]);
    //alert($("#" + arrObj[2]).offset().left);

    for (var i = 0; i < arrObj.length-1; i++)
    {
        //arrObj[i].addEventListener('focus', function () {
        //    alert('a');
        //},false);
        //var a = textObj[i];
        //var opp = $("#" + arrObj[i]);
        //opp.focus(function () {
        //    if (opp.val() == "") {

        //        var left = $(opp).offset().left;
        //        var top = $(opp).offset().top;
        //        var css = { position: "absolute", top: top + "px", left: left + "px", style: 'width:"200px",Height:"30px", z-index:"1000"' };
        //        //alert(textObj[i]);
        //        var div = "<div><span id='txt_info" + i + "'>" + textObj[i] + "</span></div>";
        //        $(div).css(css);
        //        $("#reg_content").append(div);
        //    }
        //});
    }


    $("#btn_submit").click(function () {
        var pwd = $("#txt_password").val();
        var confirePwd = $("#txt_confirm_password").val();
        if (pwd != confirePwd)
        {
            return false;
        }
    });
});

window.onload = function () {   
        //addListener(txt_password, 'focus', showInfo('txt_password'));
        
}

function showInfo(id)
{
    var opp = $("#" + id);
    opp.focus(function () {
        if (opp.val() == "") {
            var left = $(opp).offset().left;
            var top = $(opp).offset().top;
            var css = { position: "absolute", top: top + "px", left: left + "px", style: 'width:"200px",Height:"30px", z-index:"1000"' };
            var div = "<div><span id='txt_info" + getMessage(id) + "'>" + textObj[i] + "</span></div>";
            $(div).css(css);
            $("#reg_content").append(div);
        }
    });
}
function getMessage(id) {
    var message = "";
    if (id == 'txt_user_name')
    {
        message = "输入用户名，字母，数字或下线组合";
    }
    if (id == 'txt_password')
    {
        message = "6~12位字符，可使用字母，数字或符号的组合，不建议使用纯字母，纯数字，纯符号";
    }
    if (id == 'txt_confirm_password')
    {
        message = "请再次输入密码";
    }
    if (id == 'txt_email')
    {
        message = "用于用户注册验证和向您推荐信息";
    }
}
//function addListener(element, e, fn) {
//    if (element.addEventListener) {
//        element.addEventListener(e, fn, false);
//    } else {
//        element.attachEvent("on" + e, fn);
//    }
//}

function addListener(element, e, fn)
{
    if (element.addEventListener) {
        element.addEventListener(e, fn, false);
    }
    else {
        element.attachEvent("on" + e, fn);//IE
    }
}