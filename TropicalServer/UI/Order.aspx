<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/TropicalServer.Master" AutoEventWireup="true" CodeBehind="Order.aspx.cs" Inherits="TropicalServer.UI.Order" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajax" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server" >
    

    <table id="CriteriaBar">
        <tr>
            <td class="Criteria">
                <asp:Label runat="server" Text="Order Date:" CssClass="label"></asp:Label>
                <asp:DropDownList runat="server" CssClass="Input" >
                    <asp:ListItem Text="Today" Value="0"></asp:ListItem>
                    <asp:ListItem Text="Last 7 Days" Value="1"></asp:ListItem>
                    <asp:ListItem Text="Last 1 Month" Value="2"></asp:ListItem>
                    <asp:ListItem Text="Last 6 Months" Value="3"></asp:ListItem>
                </asp:DropDownList>
            </td>
            <td class="Criteria">
                <asp:Label runat="server" Text="Customer ID:" CssClass="label"></asp:Label>
                <asp:TextBox runat="server" CssClass="Input"></asp:TextBox>
            </td>
            <td class="Criteria">
                <asp:Label runat="server" Text="Customer Name:" CssClass="label"></asp:Label>
                <asp:TextBox runat="server" CssClass="Input"></asp:TextBox>
            </td>
            <td class="Criteria">
                <asp:Label runat="server" Text="Sales Manager:" CssClass="label"></asp:Label>
                <asp:DropDownList runat="server" CssClass="Input"></asp:DropDownList>
            </td>
        </tr>
    </table>

    <ajax:ToolkitScriptManager ID = "ToolkitScriptManager1" runat = "server"></ajax:ToolkitScriptManager>

    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" Width="100%" OnSelectedIndexChanged="GridView1_SelectedIndexChanged"
          OnRowEditing="GridView1_RowEditing"  OnRowDeleting="GridView1_RowDeleting"
         OnRowCancelingEdit="GridView1_RowCancelingEdit" OnRowUpdating="GridView1_RowUpdating" >
        <%--<PagerStyle CssClass="gvOrders" />--%>
        <HeaderStyle CssClass="gvOrdersth" />
        <RowStyle CssClass="chartItemStyle" />
        <AlternatingRowStyle CssClass="chartAlternatingItemStyle" />
        <Columns>

            <asp:TemplateField HeaderText="Tracking#">

                <ItemTemplate>
                    <asp:Label runat="server" Text='<%# Bind("OrderTrackingNumber") %>' ID="trackinglbl"></asp:Label>
                </ItemTemplate>

                <EditItemTemplate>
                    <asp:TextBox runat="server" Text='<%# Bind("OrderTrackingNumber") %>'  ID="trackingtbx"></asp:TextBox>
                </EditItemTemplate>
                
            </asp:TemplateField>

            <asp:TemplateField HeaderText="Order Date">

                <ItemTemplate>
                    <asp:Label runat="server" Text='<%# Bind("OrderDate") %>' ID="orderdate"></asp:Label>
                </ItemTemplate>

<%--                <EditItemTemplate>
                    <asp:TextBox runat="server" ID="orderDate" Text='<%# Eval("OrderDate") %>'></asp:TextBox>
                </EditItemTemplate>--%>
                
            </asp:TemplateField>

            <asp:TemplateField HeaderText="Customer ID">

                <ItemTemplate>
                    <asp:Label runat="server" Text='<%# Eval("CustNumber") %>' ID="CustIDlbl"></asp:Label>
                </ItemTemplate>

<%--                <EditItemTemplate>
                    <asp:TextBox runat="server" Text='<%# Eval("CustNumber") %>' ID="CustID"></asp:TextBox>
                </EditItemTemplate>--%>
                
            </asp:TemplateField>

            <asp:TemplateField HeaderText="Customer Name">

                <ItemTemplate>
                    <asp:Label runat="server" Text='<%# Eval("CustName") %>' ID="CustNamelbl"></asp:Label>
                </ItemTemplate>

<%--                <EditItemTemplate>
                    <asp:TextBox runat="server" Text='<%# Eval("CustName") %>' ID="CustName"></asp:TextBox>
                </EditItemTemplate>--%>
                
            </asp:TemplateField>

            <asp:TemplateField HeaderText="Address">

                <ItemTemplate>
                    <asp:Label runat="server" Text='<%# Eval("CustOfficeAddress1") %>' ID="addresslbl"></asp:Label>
                </ItemTemplate>

<%--                <EditItemTemplate>
                    <asp:TextBox runat="server" Text='<%# Eval("CustOfficeAddress1") %>' ID="CustAddress"></asp:TextBox>
                </EditItemTemplate>--%>

            </asp:TemplateField>

             <asp:TemplateField HeaderText="Route #">

                <ItemTemplate>
                    <asp:Label runat="server" Text='<%# Eval("CustRouteNumber") %>' ID="routelbl"></asp:Label>
                </ItemTemplate>

<%--                <EditItemTemplate>
                    <asp:TextBox runat="server" Text='<%# Eval("CustRouteNumber") %>' ID="CustRoute"></asp:TextBox>
                </EditItemTemplate>--%>
                
            </asp:TemplateField>


             <asp:TemplateField HeaderText="Available Actions">
                <ItemTemplate>
                    <asp:LinkButton runat="server" Text="View" ID="View" ></asp:LinkButton>
                    <asp:LinkButton runat="server" Text="Edit" CommandName="Edit"></asp:LinkButton>
                    <asp:LinkButton runat="server" Text="Delete" CommandName="Delete"></asp:LinkButton>

                    <ajax:ModalPopupExtender ID="mpe" runat="server" PopupControlID="pnlPopup" TargetControlID="View"
                    CancelControlID="btnClose">
                    </ajax:ModalPopupExtender>
                </ItemTemplate>

                 <EditItemTemplate>
                    <asp:LinkButton runat="server" Text="Update" CommandName="Update"></asp:LinkButton>
                    <asp:LinkButton runat="server" Text="Cancel" CommandName="Cancel"></asp:LinkButton>
                </EditItemTemplate>
                        
            </asp:TemplateField>
        </Columns>


    </asp:GridView>

    
    <asp:Panel ID="pnlPopup" runat="server" Style="display: none">
        <div class="header">
            Details
        </div>
        <div class="body">
            <table border="0" cellpadding="0" cellspacing="0">
                <tr>
                    <td style = "width:60px">
                        <b>Tracking #: </b>
                    </td>
                    <td>
                        <asp:Label ID="trackingId" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td>
                        <b>Order Date: </b>
                    </td>
                    <td>
                        <asp:Label ID="lblOrderDate" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td>
                        <b>Custom ID: </b>
                    </td>
                    <td>
                        <asp:Label ID="lblCustID" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td>
                        <b>Custom Name: </b>
                    </td>
                    <td>
                        <asp:Label ID="lblCustName" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td>
                        <b>Address: </b>
                    </td>
                    <td>
                        <asp:Label ID="lblAddress" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td>
                        <b>Route #: </b>
                    </td>
                    <td>
                        <asp:Label ID="lblRoute" runat="server" />
                    </td>
                </tr>
        </table>
    </div>
    <div>
        <asp:Button ID="btnClose" runat="server" Text="Close" />
    </div>
</asp:Panel>


</asp:Content>
