<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RoleList.aspx.cs" Inherits="BigDogShop.Web.Admin.Authority.List" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <link href="../Styles/themes/default/easyui.css" rel="stylesheet" />
    <link href="../Styles/themes/icon.css" rel="stylesheet" />
    <script src="../../Js/jquery-1.4.2.min.js"></script>
    <script src="../Js/jquery.easyui.min.js"></script>
    <script src="../Js/RoleList.js"></script>
    <%--<script type="text/javascript">
        $(function () {
            $('#form1').form({
                onSubmit: function () {
                    return $(this).form('validate');
                },
                success: function (data) {
                    $.messager.alert('Info', data, 'info');
                }
            });
            $("#data").datagrid({
                title: "角色列表",
                width: 965,
                height: 550,
                nowrap: true,
                autoRowHeight: false,
                url: '/Admin/Handler/Authority/List.ashx',
                idField: 'Id',
                striped: true,
                //frozenColumns: [[{ field: 'Id', checkbox: true }]],
                columns: [[
                        { field: 'ck', checkbox: true, rowspan: 2 },
                        { field: 'Id', title: '角色ID', width: 120, rowspan: 3 },
                        {
                            field: 'Name', title: '角色名称', width: 120, rowspan: 3, sortable: true,
                            sorter: function (a, b) {
                                return (a > b ? 1 : -1);
                            }
                        },
                        { field: 'Description', title: '说明', width: 120, rowspan: 3 },
                        { field: 'Created_Date', title: '创建时间', width: 150, rowspan: 2 },
                        { field: 'Created_Date', title: '下属管理员', width: 150, rowspan: 2 }
                ]],
                pagination: true,
                rownumbers: true,
            });
            $("#btnSearch").click(function () {
                var name = $("#txt_search").val();
                $("#data").datagrid('reload', {
                    Name: name
                });
            });
            $("#btnAdd").click(function () {
                $("#txt_id").val("");
                $("#txt_name").val("");
                $("#txt_desc").val("");
                $("#dialog_add").dialog('open');
            });
            $("#btnSubmitAdd").click(function () {
                var id = $("#txt_id").val();
                var name = $("#txt_name").val();
                var desc = $("#txt_desc").val();
                $.ajax({
                    type: 'post',
                    url: '/Admin/Authority/RoleList.aspx/Add',
                    data: "{'name':'" + name + "','desc':'" + desc + "','id':'" + id + "'}",
                    contentType: 'application/json',
                    datatype: 'json',
                    success: function (data) {
                        $.messager.alert('操作提示', '操作成功!');
                        $("#dialog_add").dialog('close');
                        $("#data").datagrid('reload');
                    },
                    error: function (err) {
                        $.messager.alert('操作提示', '操作失败!');
                    }
                });
            });
            $("#btnCancelAdd").click(function () {
                $("#dialog_add").dialog('close');
            });
            $("#btnDel").click(function () {
                var id = "";
                var row = $("#data").datagrid('getChecked');
                for (var i = 0; i < row.length; i++) {
                    id = id + row[i].Id + ",";
                }
                id = id.substr(0, id.length - 1);
                //var id = row.Id;
                if (row) {
                    $.messager.confirm("提示信息", "确定要删除吗？", function (r) {
                        if (r) {
                            $.ajax({
                                type: "post",
                                url: "/Admin/Authority/RoleList.aspx/Delete",
                                contentType: "application/json",
                                data: "{'id':'" + id + "'}",
                                success: function (result) {
                                    var s = $.parseJSON(result.d)[0];
                                    if (s.success) {
                                        $.messager.show({
                                            title: '操作提示',
                                            msg: '操作成功.'
                                        });
                                        $("#data").datagrid('clearSelections');
                                        $("#data").datagrid('reload');
                                    }
                                    else {
                                        $.messager.show({
                                            title: '发生错误',
                                            msg: result.errorMsg
                                        });
                                        $("#data").datagrid('clearSelections');
                                        $("#data").datagrid('reload');
                                    }
                                }
                            });
                        }
                    });
                }
            });
            $("#btnEdit").click(function () {
                var row = $("#data").datagrid("getSelected");
                if (row) {
                    $("#dialog_edit").dialog('open');
                    var id = row.Id;
                    $.ajax({
                        type: "post",
                        url: "/Admin/Authority/RoleList.aspx/GetById",
                        contentType: "application/json",
                        data: "{'id':'" + id + "'}",
                        datatype: "json",
                        success: function (data) {
                            var a = $.parseJSON(data.d)[0];
                            $("#txt_eid").val(a.Id);
                            $("#txt_ename").val(a.Name);
                            $("#txt_edesc").val(a.Description);
                            $("#dialog_edit").dialog('open');
                        }
                    });
                }
                else {
                    $.messager.alert("操作提示", "请选择一项!");
                }
            });
            $("#btnCancelEdit").click(function () {
                $("#txt_id").val("");
                $("#txt_name").val("");
                $("#txt_desc").val("");
                $("#dialog_edit").dialog('close');
            });
            $("#btnSubmitEdit").click(function () {
                var id = $("#txt_eid").val();
                var name = $("#txt_ename").val();
                var desc = $("#txt_edesc").val();
                $.ajax({
                    type: "post",
                    url: "/Admin/Authority/RoleList.aspx/Update",
                    contentType: "application/json",
                    data: "{'id':'" + id + "','name':'" + name + "','desc':'" + desc + "'}",
                    datatype: "json",
                    success: function (data) {
                        var s = $.parseJSON(result.d)[0];
                        if (s.success) {
                            $.messager.show({
                                title: '操作提示',
                                msg: '操作成功.'
                            });
                            $("#data").datagrid('clearSelections');
                            $("#data").datagrid('reload');
                        }
                        else {
                            $.messager.show({
                                title: '发生错误',
                                msg: result.errorMsg
                            });
                            $("#data").datagrid('clearSelections');
                            $("#data").datagrid('reload');
                        }
                    }
                });
            });
        });
    </script>--%>
</head>
<body>
    <form id="form1" runat="server">
        <!--datagrid-->
        <table id="data" toolbar="#dlg-toolbar"></table>
        <div id="dlg-toolbar">
            <span>角色名称:</span>
            <input id="txt_search" style="line-height: 20px; border: 1px solid #ccc">
            <a href="#" id="btnSearch" class="easyui-linkbutton" plain="true" iconcls="icon-search">查询</a>
            <a href="#" id="btnAdd" class="easyui-linkbutton" plain="true" iconcls="icon-add">添加</a>
            <a href="#" id="btnEdit" class="easyui-linkbutton" plain="true" iconcls="icon-edit">编辑</a>
            <a href="#" class="easyui-linkbutton" plain="true" iconcls="icon-details" onclick="javascript:alert('Ok')">详细</a>
            <a href="#" id="btnDel" class="easyui-linkbutton" plain="true" iconcls="icon-remove">删除</a>
            <a href="#" class="easyui-linkbutton" plain="true" iconcls="icon-share" onclick="javascript:alert('Ok')">分配用户</a>
        </div>

        <!--添加-->
        <div id="dialog_add" class="easyui-dialog" style="padding: 5px; width: 400px; height: 200px;"
            title="添加角色" iconcls="icon-ok" buttons="#dlg-buttonsAdd" closed="true" modal="true">
            <div style="margin-left: auto; margin-right: auto; text-align: center;">
                <table>
                    <tr>
                        <td>角色ID</td>
                        <td>
                            <asp:TextBox class="easyui-validatebox" data-options="prompt:'请输入角色名.',required:true,validType:'length[3,50]'" ID="txt_id" name="name" runat="server" />
                        </td>
                    </tr>
                    <tr>
                        <td>角色名称</td>
                        <td>
                            <asp:TextBox class="easyui-validatebox" data-options="prompt:'请输入角色名称.',required:true,validType:'length[3,100]'" ID="txt_name" name="name" runat="server" />
                        </td>
                    </tr>
                    <tr>
                        <td>说明</td>
                        <td>
                            <asp:TextBox ID="txt_desc" name="desc" runat="server" />
                        </td>
                    </tr>
                </table>
            </div>

        </div>
        <div id="dlg-buttonsAdd">
            <a href="#" id="btnSubmitAdd" class="easyui-linkbutton" iconcls="icon-ok">提交</a>
            <a href="#" id="btnCancelAdd" class="easyui-linkbutton" iconcls="icon-cancel">取消</a>
        </div>

        <!--编辑-->
        <div id="dialog_edit" class="easyui-dialog" style="padding: 5px; width: 400px; height: 200px;"
            title="编辑角色" iconcls="icon-edit" buttons="#dlg-buttonsEdit" closed="true" modal="true">
            <table>
                <tr>
                    <td>角色ID</td>
                    <td>
                        <asp:TextBox class="easyui-validatebox" data-options="prompt:'请输入角色名.',required:true,validType:'length[3,50]'" ID="txt_eid" name="name" runat="server"></asp:TextBox></td>

                </tr>
                <tr>
                    <td>角色名称</td>
                    <td>
                        <asp:TextBox class="easyui-validatebox" data-options="prompt:'请输入角色名称.',required:true,validType:'length[3,100]'" ID="txt_ename" name="name" runat="server"></asp:TextBox></td>

                </tr>
                <tr>
                    <td>说明</td>
                    <td>
                        <asp:TextBox ID="txt_edesc" type="text" name="desc" runat="server" />
                    </td>
                </tr>
            </table>
        </div>
        <div id="dlg-buttonsEdit">
            <a href="#" id="btnSubmitEdit" class="easyui-linkbutton" iconcls="icon-ok">更新</a>
            <a href="#" id="btnCancelEdit" class="easyui-linkbutton" iconcls="icon-cancel">取消</a>
        </div>

    </form>
</body>
</html>




