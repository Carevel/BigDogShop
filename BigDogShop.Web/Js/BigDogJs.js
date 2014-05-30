$(document).ready(function (e) {
    window.onscroll = function () {
        document.title = window.pageYOffset;
    }

    $("li[class='sort_color']").hover(function () {
        var type_id = $(this).attr("typeid");
        var temp = this;
        var left = $(this).offset().top;
        var top2 = -60;
        //document.title = $(this).top;
        var top1 = window.pageYOffset;
        var h1 = $(this).children("div[class^='show_sort']").height();//500
        var h2 = top1 - 147;
        document.title = (h1 + h2) + ",窗口:" + window.innerHeight + ",offset().top" + $(this).offset().top;
        if (top1 == 0) {
            //alert(top1);
            h2 = $(this).offset().top;

            if ((h1 + h2) > window.innerHeight) {

                top2 = (h1 + h2) - window.innerHeight;
            }
        }
        if (top1 > 147) {


            if ((h1 + h2) < window.innerHeight) {

                top2 = $(this).offset().top;
            }
            else {
                top2 = top1 - 147 + 20;
            }

        }
        else if ((h1 + h2) > window.innerHeight) {
            top2 = window.innerHeight - 20 - h1;
        }
        else {
            top2 = $(this).offset().top - 147;
        }

        //document.title = window.pageYOffset;
        //alert(top);
        //var etop=0;
        var actualScrollTop = top2;
        document.title = top2;
        var css = { top: actualScrollTop + "px" };
        //alert($(this).children("div[class^='show_sort']").children().length);
        if ($(this).children("div[class^='show_sort']").children().length > 0) {
            $(this).children("div[class^='show_sort']").css(css);
            $(this).children("div[class^='show_sort']").show();
            $(temp).siblings().children("div[class^='show_sort']").hide();
        }
        else {
            $.ajax({
                type: 'post',
                url: 'Handler/GetGlobalLeftMenuData.ashx',
                data: 'type_id=' + type_id,
                dataType: 'json',
                success: function (data) {
                    var jsonObj = eval(data);
                    var j = jsonObj[0].value;
                    var a = $("li[class^='sort_color']").find("div[typeid='" + type_id + "']");
                    $("li[class^='sort_color']").children("div[typeid='" + type_id + "']").append(jsonObj[0].value);
                    //setTimeout(function () {
                    $("li[class^='sort_color']").children("div[typeid='" + type_id + "']").show();

                    $("li[class^='sort_color']").children("div[typeid='" + type_id + "']").css(css);
                    $(temp).siblings().children("div[class^='show_sort']").hide();
                    //}, 300);                                                    
                }
            });
        }
    },
             function () {
                 var type_id = $(this).attr("typeid");
                 $("li[class^='sort_color']").children("div[typeid='" + type_id + "']").hover(function () {
                     $("li[class^='sort_color']").children("div[typeid='" + type_id + "']").show();
                 }, function () {
                     $("li[class^='sort_color']").children("div[typeid='" + type_id + "']").hide();
                 });
                 $("li[class^='sort_color']").children("div[typeid='" + type_id + "']").hide();
             }
       )
    function getTop(e) {
        var offset = e.offsetTop;
        if (e.offsetParent != null) offset += getTop(e.offsetParent);
        return offset;
    }
});

