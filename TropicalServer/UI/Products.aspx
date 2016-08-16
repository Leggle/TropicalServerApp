<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/TropicalServer.Master" AutoEventWireup="true" CodeBehind="Products.aspx.cs" Inherits="TropicalServer.UI.Products" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <div style="text-align:center;float:left">
    <asp:Repeater ID="Repeater1" runat="server" OnItemCommand="Repeater1_ItemCommand1">
        <HeaderTemplate>
            <table class="RepeaterTable">
                <tr class="RepeaterRow">
                    <th class="productCategoriesLabel">PRODUCT CATEGORIES</th>
                </tr>
        </HeaderTemplate>
        <ItemTemplate>
            <tr class="RepeaterRow">

                <td>
                <asp:LinkButton runat="server" id="sideBarbutton2" CommandArgument='<%# Eval("ItemTypeNumber") %>'
                 Text='<%# Eval("ItemTypeDescription") %>' 
                Font-Bold="True" Font-Size="9" Font-Names="Calibri"
                ForeColor="White" Font-Underline="False" />
                </td>

            </tr>
        </ItemTemplate>
        <FooterTemplate>
            </table>
        </FooterTemplate>
    </asp:Repeater>
        </div>
    <div class="chartdisplay" style="overflow:scroll">
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="true" ShowHeaderWhenEmpty="true"
            OnPageIndexChanging="GridView1_PageIndexChanging" AllowPaging="True" PageSize="5" >
             <PagerStyle CssClass="dataGrid" />
            <HeaderStyle CssClass="chartHeaderStyle" />
            <RowStyle CssClass="chartItemStyle" />
            <AlternatingRowStyle CssClass="alternatingItemStyle" />
        </asp:GridView>
    </div>
</asp:Content>
