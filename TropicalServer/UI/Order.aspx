<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/TropicalServer.Master" AutoEventWireup="true" CodeBehind="Order.aspx.cs" Inherits="TropicalServer.UI.Order" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajax" %>


<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server" >
    
    <table id="CriteriaBar" runat="server">
        <tr>
            <td class="Criteria">
                <asp:Label runat="server" Text="Order Date:" CssClass="label"></asp:Label>
                <asp:DropDownList runat="server" CssClass="Input"  ID="datefilter" OnSelectedIndexChanged="Unnamed_TextChanged" AutoPostBack="true">
                    <asp:ListItem Text="" Value=""></asp:ListItem>
                    <asp:ListItem Text="Today" Value="today"></asp:ListItem>
                    <asp:ListItem Text="Last 7 Days" Value="last7days"></asp:ListItem>
                    <asp:ListItem Text="Last 1 Month" Value="last1month"></asp:ListItem>
                    <asp:ListItem Text="Last 6 Months" Value="last6months"></asp:ListItem>
                </asp:DropDownList>
            </td>
            <td class="Criteria">
                <asp:Label runat="server" Text="Customer ID:" CssClass="label"></asp:Label>
                <asp:TextBox runat="server" CssClass="Input" OnTextChanged="Unnamed_TextChanged" ID="tb_custID" AutoPostBack="true"></asp:TextBox>
            </td>
            <td class="Criteria">
                <asp:Label runat="server" Text="Customer Name:" CssClass="label"></asp:Label>
                <asp:TextBox runat="server" CssClass="Input" ID="tb_custName"  OnTextChanged="Unnamed_TextChanged" AutoPostBack="true"></asp:TextBox>
            </td>
            <td class="Criteria">
                <asp:Label runat="server" Text="Sales Manager:" CssClass="label"></asp:Label>
                <asp:DropDownList runat="server" CssClass="Input" ID="manager" OnSelectedIndexChanged="Unnamed_TextChanged" AutoPostBack="true">
                    <asp:ListItem Text="" Value=""></asp:ListItem>
                    <asp:ListItem Text="Anupam" Value="Anupam"></asp:ListItem>
                    <asp:ListItem Text="Andy" Value="Andy"></asp:ListItem>
                    <asp:ListItem Text="Chee" Value="Chee"></asp:ListItem>
                    <asp:ListItem Text="Nii" Value="Nii"></asp:ListItem>
                    <asp:ListItem Text="Hitesh" Value="Hitesh"></asp:ListItem>
                </asp:DropDownList>
            </td>
        </tr>
    </table>

    <ajax:ToolkitScriptManager ID = "ToolkitScriptManager1" runat = "server"></ajax:ToolkitScriptManager>

    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" Width="100%" OnSelectedIndexChanged="GridView1_SelectedIndexChanged"
          OnRowEditing="GridView1_RowEditing"  OnRowDeleting="GridView1_RowDeleting" ShowHeaderWhenEmpty="true"
         OnRowCancelingEdit="GridView1_RowCancelingEdit" OnRowUpdating="GridView1_RowUpdating">
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

                <EditItemTemplate>
                    <asp:TextBox runat="server" ID="orderDatetbx" Text='<%# Bind("OrderDate") %>'></asp:TextBox>
                </EditItemTemplate>
                
            </asp:TemplateField>

            <asp:TemplateField HeaderText="Customer ID">

                <ItemTemplate>
                    <asp:Label runat="server" Text='<%# Eval("CustNumber") %>' ID="CustIDlbl"></asp:Label>
                </ItemTemplate>
                
            </asp:TemplateField>

            <asp:TemplateField HeaderText="Customer Name">

                <ItemTemplate>
                    <asp:Label runat="server" Text='<%# Eval("CustName") %>' ID="CustNamelbl"></asp:Label>
                </ItemTemplate>
                
            </asp:TemplateField>

            <asp:TemplateField HeaderText="Address">

                <ItemTemplate>
                    <asp:Label runat="server" Text='<%# Eval("CustOfficeAddress1") %>' ID="addresslbl"></asp:Label>
                </ItemTemplate>

            </asp:TemplateField>

             <asp:TemplateField HeaderText="Route #">

                <ItemTemplate>
                    <asp:Label runat="server" Text='<%# Eval("CustRouteNumber") %>' ID="routelbl"></asp:Label>
                </ItemTemplate>
                
            </asp:TemplateField>


             <asp:TemplateField HeaderText="Available Actions">
                <ItemTemplate>
                    <asp:LinkButton runat="server" Text="View"  CommandName="Select" ID="View" ></asp:LinkButton>
                    <asp:LinkButton runat="server" Text="Edit" CommandName="Edit"></asp:LinkButton>
                    <asp:LinkButton runat="server" Text="Delete" CommandName="Delete"></asp:LinkButton>

                    
                </ItemTemplate>

                 <EditItemTemplate>
                    <asp:LinkButton runat="server" Text="Update" CommandName="Update"></asp:LinkButton>
                    <asp:LinkButton runat="server" Text="Cancel" CommandName="Cancel"></asp:LinkButton>
                </EditItemTemplate>  
             </asp:TemplateField>

        </Columns>


    </asp:GridView>
    <asp:LinkButton runat="server" Text="" ID="lbllink" ></asp:LinkButton>
    <ajax:ModalPopupExtender ID="mpe" runat="server" PopupControlID="pnlPopup" TargetControlID="lbllink"
                    CancelControlID="btnClose" BackgroundCssClass="modalBackground">
                    </ajax:ModalPopupExtender>
    <asp:Panel ID="pnlPopup" runat="server" CssClass="modalPopup" Style="display: none">
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
    <div class="footer" >
        <asp:Button ID="btnClose" runat="server" Text="Close" />
    </div>
</asp:Panel>


</asp:Content>
