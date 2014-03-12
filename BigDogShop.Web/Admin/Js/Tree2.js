$(document).ready(function () {
    var id = 0;
 
    setMenuTree(0);
});
var flag = true;
//获取节点数据JSON列表列表,返回为
function getList(obj, id) {
   
    //$(obj).parent().append(result);
    if ($(obj).siblings('ul').length > 0) {
        if (flag) {
            $(obj).removeClass('tree_collapsed');
            $(obj).addClass('tree_expanded');
            $(obj).next().removeClass("tree_folder");
            $(obj).next().addClass("tree_folder_open");
            $(obj).siblings('ul').show();
            flag = false;
        }
        else {
            $(obj).removeClass('tree_expanded');
            $(obj).addClass('tree_collapsed');
            $(obj).next().removeClass("tree_folder_open");
            $(obj).next().addClass("tree_folder");
            $(obj).siblings('ul').hide();
            flag = true;
        }
    }
    else {
        var result = null;
        var type = 'a';
        $.ajax({
            type: "post",
            async: false,
            url: "Handler/GlobalTree.ashx",
            data: "type=" + type + "&Id=" + id,//data:"Id="+id+"&a="+a+"&b="+b;    示例
            dataType: "text",
            success: function (data) {
                result = data;
            }
        });
        if (result == "")
        {
            $(obj).click = function () {
                alert('a');
            }
            return false;
        }
        $(obj).removeClass('tree_collapsed');
        $(obj).addClass('tree_expanded');
        $(obj).next().removeClass("tree_folder");
        $(obj).next().addClass("tree_folder_open");
        $(obj).parent().append(result);
        flag = false;

    }
    var OLi = document.getElementsByClassName("tree_child");
    for (var i = 0; i < OLi.length; i++)
    {
        OLi[i].onclick = function ()
        {
            setIframeSrc(this);
        }
    }
}

//设置Url
function setIframeSrc(obj) {
    var url = $(obj).attr('data-rel');
    //url = "Advertisement/" + url;
    //alert(url);
    $("#sysContent").attr("src", "" + url + "");
}

//初始化生成树
//root默认显示层次
function setMenuTree(root) {
    var result = null;
    var type = 'a';
    //$.get('Handler/GlobalTree.ashx', { id: root }, function (data) {
    //    result = data;
    //});
    $.ajax({
        type: "post",
        async: false,
        url: "Handler/GlobalTree.ashx",
        data: "type=" + type + "&Id=" + root,//data:"Id="+id+"&a="+a+"&b="+b;    示例
        dataType: "text",
        success: function (data) {
            result = data;
        }
    });
    $(".tree").append(result);
}

//图标轮转并获取绑定单击事件函数
function ToggleIcon($div) {
    var flag = true;
    var id = $div.attr("id");
    var jsonData = getList(id);
    var hasChild = $div.attr("data-flag");
    $div.toggle(function (e) {
        $(this).children("span").eq(1).show();
        
        if (jsonData == null)
        {
            return;
        }
        var node = addTree(jsonData);
           
        node.hide();
        node.insertAfter($div);
        $(this).next().slideDown(150);
        $(this).children("span").last().removeClass("div_tree_collapsed");
        $(this).children("span").last().addClass("div_tree_expanded");
        $(this).children("span").eq(1).hide();
        e.preventDefault(); 
    }, function () {
        if (jsonData != null)
        {
            $(this).children("span").last().removeClass("div_tree_expanded");
            $(this).children("span").last().addClass("div_tree_collapsed");
            $(this).next().slideUp(150);
            //$(this).next().remove();
        }
        
    });
}


//通用设置监听事件函数
function addEvent(elememt, type, fn) {
    if (window.attachEvent) {
        addEvent = function (elememt, type, fn) {
            elememt.attachEvent("on" + type, fn);
        };
    }
    else {
        addEvent = function (elememt, type, fn) {
            elememt.addEventListener(type, fn, false);
        }
    }
    addEvent(elememt, type, fn);
}


