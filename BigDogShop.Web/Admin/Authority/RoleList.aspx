<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RoleList.aspx.cs" Inherits="BigDogShop.Web.Admin.Authority.List" %>


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
                //frozenColumns: [[{ field: 'Id', checkbox: true }]],
                columns: [[
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
            $("#btnAdd").click(function () {
                $("#d_add").dialog('open');
            });
            $("#btnSubmit1").click(function () {
                var id = $("#txt_id").val();
                var name = $("#txt_name").val();
                var desc = $("#txt_desc").val();
                $.ajax({
                    type: 'post',
                    url: '/Admin/Authority/List.aspx/Add',
                    data: "{'name':'" + name + "','desc':'" + desc + "','id':'" + id + "'}",
                    contentType: 'application/json',
                    datatype: 'json',
                    success: function (data) {
                        $.messager.alert('操作提示', '操作成功!');
                        $("#d_add").dialog('close');
                        $("#data").datagrid('reload');
                    },
                    error: function (err) {
                        $.messager.alert('操作提示', '操作失败!');
                    }
                });
            });
            $("#btnCancel1").click(function () {
                $("#txt_id").val("");
                $("#txt_name").val("");
                $("#txt_desc").val("");
                $("#d_add").dialog('close');
            });
            $("#btnDel").click(function () {
                var row = $("#data").datagrid('getSelected');
                var id = row.Id;
                if (row) {
                    $.messager.confirm("提示信息", "确定要删除吗？", function (r) {
                        if (r) {
                            $.ajax({
                                type: "post",
                                url: "/Admin/Authority/List.aspx/Delete",
                                contentType: "application/json",
                                data: "{'id':'" + id + "'}",
                                success: function (result) {
                                    var s = $.parseJSON(result.d)[0];
                                    if (s.success) {
                                        $.messager.show({
                                            title: '操作提示',
                                            msg: '操作成功.'
                                        });
                                        $("#data").datagrid('reload');
                                    }
                                    else {
                                        $.messager.show({
                                            title: '发生错误',
                                            msg: result.errorMsg
                                        });
                                        $("#data").datagrid('reload');
                                    }
                                }
                            });
                        }
                    });
                }
            });
            $("#btnEdit").click(function () {
                $("#Div1").window('open');
                var row = $("#data").datagrid("getSelected");
                if (row) {
                    $("#d_edit").dialog('open');
                    var id = row.Id;
                    $.ajax({
                        type: "post",
                        url: "/Admin/Authority/List.aspx/GetById",
                        contentType: "application/json",
                        data: "{'id':'" + id + "'}",
                        datatype: "json",
                        success: function (data) {
                            var a = $.parseJSON(data.d)[0];
                            $("#txt_eid").val(a.Id);
                            $("#txt_ename").val(a.Name);
                            $("#txt_edesc").val(a.Description);
                            $("#d_edit").dialog('open');
                        }
                    });
                }
                else {
                    $.messager.alert("操作提示", "请选择一项!");
                }
            })
        });
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <table id="data" toolbar="#dlg-toolbar"></table>
        <div id="d_add" class="easyui-dialog" style="padding: 5px; width: 400px; height: 200px;"
            title="添加角色" iconcls="icon-ok" buttons="#dlg-buttons1" closed="true" modal="true">
            <table>
                <tr>
                    <td>角色ID</td>
                    <td>
                        <%--<input id="txt_name" type="text" name="name"" />--%></td>
                    <asp:TextBox ID="txt_id" name="name" runat="server"></asp:TextBox>
                </tr>
                <tr>
                    <td>角色名称</td>
                    <td>
                        <%--<input id="txt_name" type="text" name="name"" />--%></td>
                    <asp:TextBox ID="txt_name" name="name" runat="server"></asp:TextBox>
                </tr>
                <tr>
                    <td>说明</td>
                    <td>
                        <asp:TextBox ID="txt_desc" type="text" name="desc" runat="server" />
                    </td>
                </tr>
            </table>
        </div>
      <div id="w" class="easyui-window" title="Modal Window" data-options="modal:true,closed:true,iconCls:'icon-save'" style="width:500px;height:200px;padding:10px;">
        The window content.
    </div>
        <div id="dlg-toolbar">
            <span>角色名称:</span>
            <input id="txt_search" style="line-height: 20px; border: 1px solid #ccc">
            <a href="#" class="easyui-linkbutton" plain="true" iconcls="icon-search" onclick="javascript:alert('Ok')">查询</a>
            <a href="#" id="btnAdd" class="easyui-linkbutton" plain="true" iconcls="icon-add">添加</a>
            <a href="#" id="btnEdit" class="easyui-linkbutton" plain="true" iconcls="icon-edit">编辑</a>
            <a href="#" class="easyui-linkbutton" plain="true" iconcls="icon-details" onclick="javascript:alert('Ok')">详细</a>
            <a href="#" id="btnDel" class="easyui-linkbutton" plain="true" iconcls="icon-remove">删除</a>
            <a href="#" class="easyui-linkbutton" plain="true" iconcls="icon-share" onclick="javascript:alert('Ok')">分配用户</a>
        </div>
        <div id="Div1" class="easyui-window" title="Modal Window" data-options="modal:true,closed:true,iconCls:'icon-save'" style="width:500px;height:200px;padding:10px;">
        The window content.
            <div data-options="region:'center',border:false" style="text-align:right;padding:5px 0 0;">
                <a class="easyui-linkbutton" data-options="iconCls:'icon-ok'" href="javascript:void(0)" onclick="javascript:alert('ok')">Ok</a>
                <a class="easyui-linkbutton" data-options="iconCls:'icon-cancel'" href="javascript:void(0)" onclick="javascript:alert('cancel')">Cancel</a>
            </div>
        </div>
        <div id="dlg-buttons">
            <a href="#" id="btnSubmit" class="easyui-linkbutton" iconcls="icon-ok">提交</a>
            <a href="#" id="btnCancel" class="easyui-linkbutton" iconcls="icon-cancel">取消</a>
        </div>
    </form>
</body>
</html>




