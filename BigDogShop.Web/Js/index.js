$(document).ready(function (e) {

    $("li[class='sort_color']").hover(function () {
        var typeId = $(this).attr("typeid");
        var temp = this;
        var thisLeft = $(this).parent().offset().top;
        var divShowSort = $(temp).children(".show_sort");
        var eq = $(temp).parent().children().index(this);//当前滑过的第几个元素
        var s = $(window).scrollTop();//浏览器滚动高度
        var h = $(this).parent().offset().top;//获取当前下拉菜单距离窗口多少像素
        var i = $(divShowSort).offset().top;//当前子元素滚动窗口像素
        var itemHeight = $(divShowSort).height();//子窗口高度
        var sortHeight = $(this).parent().height();//父容器高度
        //document.title = "eq:" + eq + ",s:" + s + ",h:" + h + ",i:" + i + "," + itemHeight + "," + sortHeight;

        var browserHeight = $(window).height();
        var divTop = $(temp).offset().top;
        var divLeft = $(divShowSort).offset().left;
        var divStyleTop = $(divShowSort).innerHeight();
        var vTop = $(temp).offset().top - $(temp).parent().offset().top;
        var css;
        css = { top: vTop, left: $(temp).parent().width() + "px" };
        $(divShowSort).css('left', $(temp).parent().width());
        
        if ($(divShowSort).children(".sort_list").length > 0) {
            if (itemHeight < sortHeight) {
                $(divShowSort).css('top', 0 + eq * $(temp).height());
            }
            else {
                if (s > h) {
                    if ((i - s) > 0) {
                        $(divShowSort).css('top', (s - h) + 2);
                    }
                    else {
                        $(divShowSort).css('top', (s - h) - (-(i - s)) + 2);
                    }
                }
                else {
                    $(divShowSort).css('top', 0);
                }
            }
            $(divShowSort).show();
            $(temp).siblings().children(".show_sort").hide();
        }
        else {
            $(temp).children(".show_sort").css('top', 0);
            $(temp).children(".show_sort").show();
            $(temp).children(".show_sort").children(".loading").show();
            $.ajax({
                type: 'post',
                url: 'Handler/GetGlobalLeftMenuData.ashx',
                data: 'typeId=' + typeId,
                dataType: 'json',
                success: function (data) {
                    if (itemHeight < sortHeight) {
                        $(divShowSort).css('top', 0 + eq * $(temp).height());
                    }
                    else {
                        if (s > h) {
                            if ((i - s) > 0) {
                                $(divShowSort).css('top', (s - h) + 2);
                            }
                            else {
                                $(divShowSort).css('top', (s - h) - (-(i - s)) + 2);
                            }
                        }
                        else {
                            $(divShowSort).css('top', 0);
                        }
                    }

                    var jsonObj = eval(data);
                    var j = jsonObj[0].value;
                    $(divShowSort).append(jsonObj[0].value);
                    $(temp).children(".show_sort").children(".loading").hide();
                    $(temp).siblings().children(".show_sort'").hide();
                }
            });
        }
    },
             function () {
                 var typeId = $(this).attr("typeid");
                 $("li[class^='sort_color']").children("div[typeid='" + typeId + "']").hover(function () {
                     $("li[class^='sort_color']").children("div[typeid='" + typeId + "']").show();
                 }, function () {
                     $("li[class^='sort_color']").children("div[typeid='" + typeId + "']").hide();
                 });
                 $("li[class^='sort_color']").children("div[typeid='" + typeId + "']").hide();
             }
       )

    var n = 1;
    $(".tabtn li").hover(function () {
        var temp = this; 
        var eq = $(temp).parent().children().index(this);
        $(temp).removeClass("liorigin");
        $(temp).addClass("liover");
        n = n + 1;
        $(".sublist li").eq(eq).css('z-index', n).show();
    }, function () {
        $(this).removeClass("liover");
        $(this).addClass("liorigin");
    });
});

