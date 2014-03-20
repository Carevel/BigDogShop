<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SysList.aspx.cs" Inherits="BigDogShop.Web.Admin.Authority.SysList" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <link href="../Styles/themes/default/easyui.css" rel="stylesheet" />
    <link href="../Styles/themes/icon.css" rel="stylesheet" />
    <script src="../../Js/jquery-1.4.2.min.js"></script>
    <script src="../Js/jquery.easyui.min.js"></script>
    <script src="../Js/Authority/SysList.js"></script>
    <style type="text/css">
        .info_blank
        {
            width: 100%;
            height: 40px;
            line-height: 40px;
        }

        .t_blank
        {
            width: 80px;
            display: block;
            float: left;
            text-align: right;
        }

        .o_blank
        {
            width: 150px;
            float: left;
        }
    </style>
</head>
    
<body class="easyui-layout">

    <!--datagrid-->
    <div region="center" style="padding: 5px;" border="false">
        <table id="data" toolbar="#dlg-toolbar"></table>
        <div id="dlg-toolbar">
            <%--                <span>系统管理员名称:</span>--%>
            <input id="txt_search" style="line-height: 20px; border: 1px solid #ccc">
            <a href="#" id="btnSearch" class="easyui-linkbutton" plain="true" iconcls="icon-search">查询</a>
            <a href="#" id="btnAdd" class="easyui-linkbutton" plain="true" iconcls="icon-add">添加</a>
            <a href="#" id="btnEdit" class="easyui-linkbutton" plain="true" iconcls="icon-edit">编辑</a>
            <a href="#" id="btnDetail" class="easyui-linkbutton" plain="true" iconcls="icon-details">详细</a>
            <a href="#" id="btnDel" class="easyui-linkbutton" plain="true" iconcls="icon-remove">删除</a>
        </div>
    </div>

    

    <!--添加-->
    <div id="dialog_add" class="easyui-dialog" style="padding: 5px; width: 500px; height: 300px;"
        title="添加系统管理员" iconcls="icon-ok" buttons="#dlg-buttonsAdd" closed="true" modal="true">
        <div class="info">
            <div class="info_blank">
                <span class="t_blank">名称</span>
                <span class="o_blank">
                    <input type="text" id="txt_user_name" />
                    <%--<asp:TextBox ID="txt_user_name" runat="server"></asp:TextBox>--%>
                </span>
            </div>
        </div>
        <div class="info">
            <div class="info_blank">
                <span class="t_blank">密码</span>
                <span class="o_blank">
                    <input type="text" id="txt_pwd" />
                    <%--<asp:TextBox ID="txt_pwd" runat="server"></asp:TextBox>--%>
                </span>
            </div>
        </div>
        <div class="info">
            <div class="info_blank">
                <span class="t_blank">E_mail</span>
                <span class="o_blank">
                    <input type="text" id="txt_e_mail" />
                    <%--<asp:TextBox ID="txt_e_mail" runat="server"></asp:TextBox>--%>
                </span>
            </div>
        </div>
        <div class="info">
            <div class="info_blank">
                <span class="t_blank">头像</span>
                <span class="o_blank">
                    <img id="img_user" alt="头像" />
                </span>
            </div>
        </div>
        <div class="info">
            <div class="info_blank">
                <span class="t_blank">是否锁定</span>
                <span class="o_blank">
                    <select id="txt_is_lock" name="dept" style="width: 50px;">
                        <option value="Y">是</option>
                        <option value="N">否</option>
                    </select>
                </span>
            </div>
        </div>
    </div>
    <div id="dlg-buttonsAdd">
        <a href="#" id="btnSubmitAdd" class="easyui-linkbutton" iconcls="icon-ok">添加</a>
        <a href="#" id="btnCancelAdd" class="easyui-linkbutton" iconcls="icon-cancel">取消</a>
    </div>

    <!--编辑-->
    <div id="dialog_edit" class="easyui-dialog" style="padding: 5px; width: 350px;"
        title="编辑管理员" iconcls="icon-edit" buttons="#dlg-buttonsEdit" closed="true" modal="true">
        <div class="info">
            <div class="info_blank">
                <span class="t_blank">名称</span>
                <span class="o_blank">
                    <input type="text" id="txt_edit_name" />
                    <%--<asp:TextBox ID="txt_edit_name" runat="server"></asp:TextBox>--%>
                </span>
            </div>
        </div>
        <div class="info">
            <div class="info_blank">
                <span class="t_blank">E_mail</span>
                <span class="o_blank">
                    <input type="text" id="txt_edit_e_mail" />
                    <%--<asp:TextBox ID="txt_edit_e_mail" runat="server"></asp:TextBox>--%>
                </span>
            </div>
        </div>
        <div class="info">
            <div class="info_blank">
                <span class="t_blank">密码</span>
                <span class="o_blank">
                    <input type="text" id="txt_edit_pwd" />
                    <%--<asp:TextBox ID="txt_edit_pwd" runat="server"></asp:TextBox>--%>
                </span>
            </div>
        </div>
        <div class="info">
            <div class="info_blank">
                <span class="t_blank">是否锁定</span>
                <span class="o_blank">
                    <select id="txt_edit_is_lock" style="width: 50px;">
                        <option value="Y">是</option>
                        <option value="F">否</option>
                    </select>
                </span>
            </div>
        </div>
    </div>
    <div id="dlg-buttonsEdit">
        <a href="#" id="btnSubmitEdit" class="easyui-linkbutton" iconcls="icon-ok">更新</a>
        <a href="#" id="btnCancelEdit" class="easyui-linkbutton" iconcls="icon-cancel">取消</a>
    </div>

    <!--详细-->
    <div id="Div1" class="easyui-dialog" style="padding: 5px; width: 350px;"
        title="管理员信息详细" iconcls="icon-edit" buttons="#dlg-buttonsEdit" closed="true" modal="true">
        <div class="info">
            <div class="info_blank">
                <span class="t_blank">名称</span>
                <span class="o_blank">
                    <input type="text" id="Text1" />
                    <%--<asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>--%>
                </span>
            </div>
        </div>
        <div class="info">
            <div class="info_blank">
                <span class="t_blank">E_mail</span>
                <span class="o_blank">
                    <%--<asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>--%>
                </span>
            </div>
        </div>
        <div class="info">
            <div class="info_blank">
                <span class="t_blank">密码</span>
                <span class="o_blank">
                    <%--<asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>--%>
                </span>
            </div>
        </div>
        <div class="info">
            <div class="info_blank">
                <span class="t_blank">是否锁定</span>
                <span class="o_blank">
                    <select id="Select1" style="width: 50px;">
                        <option value="Y">是</option>
                        <option value="F">否</option>
                    </select>
                </span>
            </div>
        </div>

    </div>

</body>
</html>
