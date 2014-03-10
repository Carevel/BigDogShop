$(document).ready(function () {
    //var OliArr = $(".sort_color");
    //$("li[class^='sort_color']").children("span").each(function () {
    //    var timer;
    //    $(this).hover(
    //        function () {
    //            var type_id = $(this).next(".show_sort").attr("typeid");
    //            var a = $(this).next(".show_sort");
    //            var b = $(this).next(".show_sort").children();
    //            if ($(this).next(".show_sort").children().length > 0) {
    //                $(this).next(".show_sort").show();
    //            }
    //            else {
    //                $.ajax({
    //                    type: 'get',
    //                    url: 'Handler/GetGlobalLeftMenuData.ashx',
    //                    data: 'type_id=' + type_id,
    //                    dataType: 'json',
    //                    success: function (data) {
    //                        var jsonObj = eval(data);
    //                        var j = jsonObj[0].value;
    //                        var a = $("li[class^='sort_color']").find("div[typeid='" + type_id + "']");
    //                        $("li[class^='sort_color']").children("div[typeid='" + type_id + "']").append(jsonObj[0].value);
    //                        //setTimeout(function () {
    //                        $("li[class^='sort_color']").children("div[typeid='" + type_id + "']").show();
    //                        //}, 300);                                                    
    //                    }
    //                });
    //            }
    //        },
    //         function () {
    //             var type_id = $(this).next(".show_sort").attr("typeid");
    //             $("li[class^='sort_color']").children("div[typeid='" + type_id + "']").hover(function () {
    //                 $("li[class^='sort_color']").children("div[typeid='" + type_id + "']").show();
    //             }, function () {
    //                 $("li[class^='sort_color']").children("div[typeid='" + type_id + "']").hide();
    //             });
    //             $("li[class^='sort_color']").children("div[typeid='" + type_id + "']").hide();
    //         }
    //   )
    //});
    $("li[class^='sort_color']").children("span").hover(function () {
        var type_id = $(this).next(".show_sort").attr("typeid");
        if ($(this).next(".show_sort").children().length > 0) {
            $(this).next(".show_sort").show();
        }
        else {
            $.ajax({
                type: 'get',
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
                    //}, 300);                                                    
                }
            });
        }
    },
             function () {
                 var type_id = $(this).next(".show_sort").attr("typeid");
                 $("li[class^='sort_color']").children("div[typeid='" + type_id + "']").hover(function () {
                     $("li[class^='sort_color']").children("div[typeid='" + type_id + "']").show();
                 }, function () {
                     $("li[class^='sort_color']").children("div[typeid='" + type_id + "']").hide();
                 });
                 $("li[class^='sort_color']").children("div[typeid='" + type_id + "']").hide();
             }
       )

});

