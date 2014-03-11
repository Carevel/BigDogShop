var count = 0;

$(document).ready(function () {
    var id = 0;
    var mode = 'getTree';
    setMenuTree(0);
    var obj = document.getElementsByClassName("TreeMenu")[0];
    var div1 = document.getElementById("div1");
    $(".l-layout-header-toogle").click(function () {
        startMove(obj, 'height', 1000);
        startMove(div1, 'left', -20);
    });
});


//root     根节点
//level    默认显示级次
//url      链接
//img     默认图片
//imgOnClick 鼠标点击时图片
//isOpen   是否打开
function addTree(jsonData, root, level, url, img, imgOnClick, isOpen) {
    var arr = [];
    var treeView = getList(root);
    for (var i = 0; i < treeView.length; i++) {
        if (treeView[i].Has_Children == "true") {
            $li = $("<li><span><img src='" + img + "'/>" + treeView[i].Menu_Name + "</span></li>");
        }
    }
}
//初始化生成树
//root默认显示层次
function setMenuTree(root) {
    var arr = new Array();
    var treeView = getList(root);
    for (var i = 0; i < treeView.length; i++) {
        var node = treeView[i].Has_Children;
        if (node == "true") {
            //有子节点
            id = treeView[i].Menu_Id;
            $li = $("<li class=\"tree_li_header\"><span id=" + treeView[i].Menu_Id + " class=\"tree_hit tree_collapsed\"></span><div class=\"tree_title\">" + treeView[i].Menu_Name + "</div></li>");
            $(".tree").append($li);
            iconToggle($li,id,root);//添加图标单击事件并图标轮转
        }
        else {
            $li = $("<li class=\"tree_li_header\"><span class=\"tree_indent \"></span><span id=" + treeView[i].Menu_Id + " class=\"tree_indent \"></span><div id=" + treeView[i].Menu_Id + " class=\"tree_title\">" + treeView[i].Menu_Name + "</div></li>");
            $(".tree").append($li);
        }
    }
}
//获取节点数据JSON列表列表,返回为
function getList(id) {
    var result = null;
    var type = 'a';
    $.ajax({
        type: "post",
        async: false,
        url: "Handler/TreeView.ashx",
        data: "type=" + type + "&Id=" + id,//data:"Id="+id+"&a="+a+"&b="+b;    示例
        dataType: "json",
        success: function (data) {
            result = eval(data);
        }
    });
    return result;
}

var fl = true;
//根据节点数据列表生成<ul></ul>子节点树
function addTree(jsonTree) {
    $ul = $("<ul id=\"ul_" + jsonTree[0].Menu_Id + "\" ></ul>");
    for (var i = 0; i < jsonTree.length; i++) {
        var node = jsonTree[i].Has_Children;
        if (node == "true") {
            //有子节点
            id = jsonTree[i].Menu_Id;
            $li = $("<li><span id=" + jsonTree[i].Menu_Id + " class=\"tree_hit tree_collapsed \"></span><span class=\"tree_folder\"></span><div class=\"tree_title\">" + jsonTree[i].Menu_Name + "</div></li>");
            $ul.append($li);
            iconToggle($li, id);
            fl = false;
        }
        else {
            $li = $("<li><span class=\"tree_indent \"></span><span class=\"tree_indent \"></span><span class=\"tree_file\"></span><div dd=" + jsonTree[i].Link_Url + " id=" + jsonTree[i].Menu_Id + " class=\"tree_title\">" + jsonTree[i].Menu_Name + "</div></li>");
            $ul.append($li);
            fl = false;
        }
    }
    return $ul;
}
//图标轮转函数
function iconToggle($li, id) {
    var flag = true;
    var spanArr = $li.children("span");
    var id = spanArr.first().attr("id");
    spanArr.eq(0).bind('click', function () {
        if ($(this).parent().children("ul").length == 0) {
            spanArr.eq(1).removeClass("tree_folder");
            spanArr.eq(1).addClass("tree_loading");
            spanArr.eq(0).removeClass("tree_collapsed");
            spanArr.eq(0).addClass("tree_expanded");
            spanArr.eq(1).removeClass("tree_loading");
            spanArr.eq(1).addClass("tree_folder_open");
            var jsonData = getList(id);
            var node = addTree(jsonData);
            node.hide();
            $("#" + id).parent().append(node);
            flag = false;
        }
        if (flag) {
            spanArr.eq(1).removeClass("tree_folder_open");
            spanArr.eq(1).addClass("tree_folder");
            spanArr.eq(0).removeClass("tree_expanded");
            spanArr.eq(0).addClass("tree_collapsed");
            $(this).parent().children("ul").slideUp(150);
            flag = false;
        }
        else {
            spanArr.eq(1).removeClass("tree_folder");
            spanArr.eq(1).addClass("tree_folder_open");
            spanArr.eq(0).removeClass("tree_collapsed");
            spanArr.eq(0).addClass("tree_expanded");
            $(this).parent().children("ul").slideDown(150);
            flag = true;
        }
    });
}


//设置Url
function setIframeSrc() {
    var url = $(this).attr('dd');
    url = "Advertisement/" + url;
    //alert(url);
    $("#frameContent").attr("src", "" + url + "");
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


