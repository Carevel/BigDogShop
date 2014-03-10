<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Service.ascx.cs" Inherits="BigDogShop.Web.UserControl.Service" %>
<div class="service-2014">
    <asp:Repeater ID="rpt_service" runat="server" OnItemDataBound="rpt_service_ItemDataBound">
        <ItemTemplate>
            <dl>
                <dt><strong><%#Eval("Service_Name") %></strong>
                    <asp:Repeater ID="rpt_service_detail" runat="server">
                        <ItemTemplate>
                            <dd>
                                <div>
                                    <a href="#"><%#Eval("Service_Name") %></a>
                                </div>                              
                            </dd>
                        </ItemTemplate>
                    </asp:Repeater>
                </dt>
            </dl>
        </ItemTemplate>
    </asp:Repeater>
</div>
