<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RoleManager.aspx.cs" Inherits="BigDogShop.Web.Admin.Authority.RoleManager" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
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
                frozenColumns: [[{ field: 'ck', checkbox: true }]],
                columns: [[
                      { field: 'Name', title: '角色名称', width: 120 },
                      {
                          field: 'Description', title: '说明', width: 220, rowspan: 2, sortable: true,
                          sorter: function (a, b) {
                              return (a > b ? 1 : -1);
                          }
                      },
                    { field: 'Created_Date', title: '创建时间', width: 150, rowspan: 2 },
                { field: 'Created_Date', title: '下属管理员', width: 150, rowspan: 2 }
                ]],
                pagination: true,
                rownumbers: true,
                toolbar: [{
                    id: 'btnsearch',
                    text: '查询',
                    iconCls: 'icon-search',
                    handler: function () {
                        $('#btnsave').linkbutton('enable');
                        alert('add')
                    }
                }, {
                    id: 'btnadd',
                    text: '新增',
                    iconCls: 'icon-add',
                    handler: function () {
                        $('#btnsave').linkbutton('enable');
                    }
                }, '-', {
                    id: 'btnedit',
                    text: '编辑',
                    disabled: true,
                    iconCls: 'icon-edit',
                    handler: function () {
                        $('#btnsave').linkbutton('disable');
                        alert('save')
                    }
                },
                {
                    id: 'btndetail',
                    text: '详细',
                    iconCls: 'icon-details',
                    handler: function () {
                        $('#btndetail').linkbutton('enable');
                        alert('cut')
                    }
                },
                {
                    id: 'btncut',
                    text: '删除',
                    iconCls: 'icon-remove',
                    handler: function () {
                        $('#btnremove').linkbutton('enable');
                        alert('cut')
                    }
                },
                {
                    id: 'btnshare',
                    text: '分配用户',
                    iconCls: 'icon-share',
                    handler: function () {
                        $('#btnsave').linkbutton('enable');
                        alert('cut')
                    }
                },
                ]
            });
            $("#btnadd").click(function () {
                $("#modalwindow").html("<iframe width='100%' height='98%' scrolling='no' frameborder='0'' src='Add.aspx'></iframe>");
                $("#modalwindow").window({ title: '新增', left: 200, top: 100, width: 300, height: 250, iconCls: 'icon-add' }).window('open');
            });
        });
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <div id="modalwindow" class="easyui-window" data-options="modal:true,closed:true,minimizable:false,shadow:false">
        </div>
        <div>
            <table id="data"></table>
        </div>
    </form>
</body>
</html>
