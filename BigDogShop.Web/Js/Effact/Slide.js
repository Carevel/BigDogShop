$(function () {
    var n = 1;
    var eq = 0;
    $(".wgt").each(function () {
        var wgt_rotation = this;
        var wgt_tabs = $(wgt_rotation).children(".wgt_tabs")[0];
        var wgt_list = $(wgt_rotation).children(".wgt_list")[0];
        var wgt_box;
        var wgt_ul = $(wgt_box).children("ul");
        var wgt_lis = $(wgt_ul).children("li");
        var wgt_imgArr = $(wgt_lis).children();//图片数组
        var wgt_width = $(wgt_rotation).width();//图片宽度
        var wgt_imgNum = $(wgt_lis).size();//每个li下的图片个数
        var wgt_box_realwidth = wgt_imgNum * wgt_width;
        var nextId = 0;
        var activeId = 0;
        var intervalTime = 2000;
        var intervalId;
        var imgSpeed = 400;
        $(wgt_box).css({ 'width': wgt_box_realwidth + "px" });//设置宽度
        $(wgt_box).css({ 'z-index': n });

        //intervalId = setInterval(rotate, intervalTime);

        $(".wgt_tabs").children("a").hover(function () {//鼠标移过时开定时器
            //activeId = 0;
            clearInterval(intervalId);
            var temp = this;

            $(temp).siblings(".blur_out").removeClass("blur_out");
            $(temp).siblings().addClass("blur_in");
            $(temp).addClass("blur_out");

            eq = $(temp).parent().children().index(temp);
            wgt_box = $(wgt_list).children(".wgt_box")[eq];

            var flag = $(wgt_box).attr("index");

            $(wgt_box).siblings().hide();
            $(wgt_box).show();

            n = n + 1;//z-index
            if (flag) {
                activeId = flag;
            }

            //rotate(activeId);
            //intervalId = setInterval(rotate, intervalTime);
            intervalId = setInterval(rotate, intervalTime);
        });

        var rotate = function (clickId) {
            wgt_box = $(wgt_list).children(".wgt_box")[eq];
            $(wgt_box).css({ 'z-index': n });
            if (clickId) {
                nextId = clickId;
            }
            else {
                nextId = activeId < 4 ? (parseInt(activeId) + 1) : 0;
            }

            $(wgt_box).animate({
                'left': -(nextId) * wgt_width,
            }, imgSpeed);
            $(wgt_box).attr("index", nextId);
            activeId = nextId;

        };
    });
})