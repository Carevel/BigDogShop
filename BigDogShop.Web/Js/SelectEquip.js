$(document).ready(function () {
    $("#btn_rank").click(function () {
        if ($("#e_rank").val() == "") {
            $("#e_rank").val("order by rank desc");
            $("#e_price").val("");
            $("#e_count").val("");
        }
        else {
            $("#e_rank").val("");
        }
    });
    $("#btn_price").click(function () {
        if ($("#e_price").val() == "") {
            $("#e_price").val("order by price desc");
            $("#e_count").val("");
            $("#e_rank").val("");
        }
        else {
            $("#e_price").val("");
        }
    });
    $("#btn_count").click(function () {
        if ($("#e_count").val() == "") {
            $("#e_count").val("order by total_count desc");
            $("#e_rank").val("");
            $("#e_price").val("");
        }
        else {
            $("#e_count").val("");
        }
    });

    $("#btn_search").click(function () {
        var result = "";
        $("#filter a[class='seled']").each(function () {
            result += $(this).attr("value") + ",";
        });
        $("#selectString").val(result);
        //alert($("#selectString").val());
    });
});


    $(function () {
        //选中filter下的所有a标签，为其添加hover方法，该方法有两个参数，分别是鼠标移上和移开所执行的函数。
        $("#filter a").hover(
            function () {
                $(this).addClass("seling");
            },
            function () {
                $(this).removeClass("seling");
            }
        );


        //选中filter下所有的dt标签，并且为dt标签后面的第一个dd标签下的a标签添加样式seled。(感叹jquery的强大)
        $("#filter dt+dd a").attr("class", "seled"); /*注意：这儿应该是设置(attr)样式，而不是添加样式(addClass)，
                                                      不然后面通过$("#filter a[class='seled']")访问不到class样式为seled的a标签。*/       

        //为filter下的所有a标签添加单击事件
        $("#filter a").click(function () {
            $(this).parents("dl").children("dd").each(function () {
                //下面三种方式效果相同（第三种写法的内部就是调用了find()函数，所以，第二、三种方法是等价的。）
                //$(this).children("div").children("a").removeClass("seled");
                //$(this).find("a").removeClass("seled");
                $('a',this).removeClass("seled");
            });

            $(this).attr("class", "seled");

            //alert(RetSelecteds()); //返回选中结果   弹出
        });
        //alert(RetSelecteds()); //返回选中结果   弹出
    });



