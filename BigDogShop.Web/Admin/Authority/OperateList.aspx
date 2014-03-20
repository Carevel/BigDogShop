<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="OperateList.aspx.cs" Inherits="BigDogShop.Web.Admin.Authority.OperateList" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../Styles/themes/default/easyui.css" rel="stylesheet" />
    <link href="../Styles/themes/icon.css" rel="stylesheet" />
    <script src="../Js/jquery-2.1.0.js"></script>
    <script src="../Js/jquery.easyui.min.js"></script>
    <script src="../Js/Authority/OperateList.js"></script>
    <style type="text/css">
        body
        {
            padding: 0px;
            margin: 0px;
        }
    </style>
</head>
<body class="easyui-layout">
           <!--datagrid-->
        <div region="center" style="padding:5px;" border="false" >
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
        </div>


        <!--添加-->
        <div id="dialog_add" class="easyui-dialog" style="padding: 5px; width: 400px; height: 200px;"
            title="添加角色" iconcls="icon-ok" buttons="#dlg-buttonsAdd" closed="true" modal="true">
            <div style="margin-left: auto; margin-right: auto; text-align: center;">
                <table>
                    <tr>
                        <td>角色ID</td>
                        <td>
                            <input type="text" class="easyui-validatebox" data-options="prompt:'请输入角色名.',required:true,validType:'length[3,50]'" ID="txt_id" name="name" />
                            <%--<asp:TextBox class="easyui-validatebox" data-options="prompt:'请输入角色名.',required:true,validType:'length[3,50]'" ID="txt_id" name="name" runat="server" />--%>
                        </td>
                    </tr>
                    <tr>
                        <td>角色名称</td>
                        <td>
                            <input type="text" class="easyui-validatebox" data-options="prompt:'请输入角色名.',required:true,validType:'length[3,50]'" ID="txt_name" name="name" />
                            <%--<asp:TextBox class="easyui-validatebox" data-options="prompt:'请输入角色名称.',required:true,validType:'length[3,100]'" ID="TextBox1" name="name" runat="server" />--%>
                            <%--<asp:TextBox class="easyui-validatebox" data-options="prompt:'请输入角色名称.',required:true,validType:'length[3,100]'" ID="txt_name" name="name" runat="server" />--%>
                        </td>
                    </tr>
                    <tr>
                        <td>说明</td>
                        <td>
                            <input type="text" name="desc" id="txt_desc" />
                            <%--<asp:TextBox ID="txt_desc" name="desc" runat="server" />--%>
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
                        <input type="text" class="easyui-validatebox" data-options="prompt:'请输入角色名.',required:true,validType:'length[3,50]'" ID="txt_eid" name="name" />
                        <%--<asp:TextBox class="easyui-validatebox" data-options="prompt:'请输入角色名.',required:true,validType:'length[3,50]'" ID="txt_eid" name="name" runat="server"></asp:TextBox>--%></td>

                </tr>
                <tr>
                    <td>角色名称</td>
                    <td>
                        <%--<asp:TextBox class="easyui-validatebox" data-options="prompt:'请输入角色名称.',required:true,validType:'length[3,100]'" ID="txt_ename" name="name" runat="server"></asp:TextBox>--%></td>
                    <input type="text" class="easyui-validatebox" data-options="prompt:'请输入角色名.',required:true,validType:'length[3,50]'" ID="txt_ename" name="name" />
                </tr>
                <tr>
                    <td>说明</td>
                    <td>
                        <input type="text" id="txt_edesc" />
                        <%--<asp:TextBox ID="txt_edesc" type="text" name="desc" runat="server" />--%>
                    </td>
                </tr>
            </table>
        </div>
        <div id="dlg-buttonsEdit">
            <a href="#" id="btnSubmitEdit" class="easyui-linkbutton" iconcls="icon-ok">更新</a>
            <a href="#" id="btnCancelEdit" class="easyui-linkbutton" iconcls="icon-cancel">取消</a>
        </div>
</body>
</html>
