<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="List.aspx.cs" Inherits="BigDogShop.Web.Admin.Authority.List" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <link href="../Styles/themes/default/easyui.css" rel="stylesheet" />
    <link href="../Styles/themes/icon.css" rel="stylesheet" />
    <script src="../../Js/jquery-1.4.2.min.js"></script>
    <script src="../Js/jquery.easyui.min.js"></script>
    <script type="text/javascript">
        $(function () {
            $("#data").datagrid({
                title: "角色列表",
                width: 965,
                height: 550,
                nowrap: true,
                autoRowHeight: false,
                url: '/Admin/Handler/Authority/List.ashx',
                idField: 'Id',
                striped: true,
                frozenColumns: [[{ field: 'Id', checkbox: true }]],
                columns: [[
                        {
                            field: 'Name', title: '角色名称', width: 120, rowspan: 3, sortable: true,
                            sorter: function (a, b) {
                                return (a > b ? 1 : -1);
                            }
                        },
                        { field: 'Description', title: '说明',width: 120, rowspan: 3 },
                        { field: 'Created_Date', title: '创建时间', width: 150, rowspan: 2 },
                        { field: 'Created_Date', title: '下属管理员', width: 150, rowspan: 2 }
                ]],
                pagination: true,
                rownumbers: true,
            });
            $("#btnAdd").click(function () {
                $("#d_add").dialog('open');
            });
            $("#btnSubmit").click(function () {
                var name= $("#txt_name").val();
                var desc=$("#txt_desc").val();
                $.ajax({
                    type: 'post',
                    url: '/Admin/Handler/Authority/Add.ashx',
                    data: 'name=' + name + '&desc=' + desc,
                    datatype: 'json',
                    success: function (data) {
                        var json = $.parseJSON(data);
                        if (json[0].result == "1")
                        {
                            $("#d_add").dialog('close');
                            $.messager.alert('操作提示', '操作成功!');
                            $("#data1").datagrid('reload');
                        }
                       
                    }
                });
            });
            $("#btnCancel").click(function () {
                $("#txt_name").val("");
                $("#txt_desc").val("");
                $("#d_add").dialog('close');
            });
        });
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <table id="data" toolbar="#dlg-toolbar"></table>
        <div id="d_add" class="easyui-dialog" style="padding: 5px; width: 400px; height: 200px;"
            title="添加角色" iconcls="icon-ok" buttons="#dlg-buttons" closed="true" modal="true">
            <table>
                <tr>
                    <td>角色名称</td>
                    <td>
                        <input id="txt_name" type="text" name="name" /></td>
                </tr>
                <tr>
                    <td>说明</td>
                    <td>
                        <input id="txt_desc" type="text" name="desc" /></td>
                </tr>
            </table>
        </div>
        <div id="dlg-toolbar">
            <span>角色名称:</span>
            <input id="txt_search" style="line-height: 20px; border: 1px solid #ccc">
            <a href="#" class="easyui-linkbutton" plain="true" iconcls="icon-search" onclick="javascript:alert('Ok')">查询</a>
            <a href="#" id="btnAdd" class="easyui-linkbutton" plain="true" iconcls="icon-add">添加</a>
            <a href="#" class="easyui-linkbutton" plain="true" iconcls="icon-edit" onclick="javascript:alert('Ok')">修改</a>
            <a href="#" class="easyui-linkbutton" plain="true" iconcls="icon-details" onclick="javascript:alert('Ok')">详细</a>
            <a href="#" class="easyui-linkbutton" plain="true" iconcls="icon-remove" onclick="javascript:alert('Ok')">删除</a>
            <a href="#" class="easyui-linkbutton" plain="true" iconcls="icon-share" onclick="javascript:alert('Ok')">分配用户</a>
        </div>
        <div id="dlg-buttons">
            <a href="#" id="btnSubmit" class="easyui-linkbutton" iconcls="icon-ok">提交</a>
            <a href="#" id="btnCancel" class="easyui-linkbutton" iconcls="icon-cancel">取消</a>
        </div>
    </form>
</body>
</html>




