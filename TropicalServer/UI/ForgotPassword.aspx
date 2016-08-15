<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ForgotPassword.aspx.cs" Inherits="TropicalServer.UI.ForgotPassword" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
        <link href="~/AppThemes/TropicalStyles/Login.css" rel="stylesheet" type="text/css" />
    <script src="JS_Functions.js">
    </script>
</head>
<body>
    <form id="header" >
        <div class="page">
            <div class="header">            
                <div class="imageDisplay">
                    <asp:Image ID="Image" runat="server" 
                        CssClass="imageHeader" ImageUrl="~/Images/HeaderTropicalServer.png" />          
                </div>
            </div>
            </div>
    </form>

    <div id="container" runat="server">
        <form id="BodyDetail" runat="server" name="myForm" >
            <h1 id="Loginlbl">MOBILE CUSTOMER ORDER TRACKING</h1>
            <div id="loginBox">
                <label id="useridlbl">Login ID</label>

                <asp:TextBox runat="server" id="useridtextbox" />
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
                    ControlToValidate="passwordtextbox" ErrorMessage="*" 
                    ValidationGroup="r1" ForeColor="#FF3300"></asp:RequiredFieldValidator>

                <label id="oldpasswordlbl">New Password</label>

                <asp:TextBox runat="server" id="passwordtextbox" TextMode="password" />
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                    ControlToValidate="passwordtextbox" ErrorMessage="*" 
                    ValidationGroup="r1"  ForeColor="#FF3300"></asp:RequiredFieldValidator>

                <label id="newpsdlbl">Reenter New Password</label>

                <asp:TextBox runat="server" id="newpasswordtextbox" TextMode="password" />
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                    ControlToValidate="newpasswordtextbox" ErrorMessage="*"
                    ValidationGroup="r1"  ForeColor="#FF3300"></asp:RequiredFieldValidator>

                <asp:CompareValidator ID="CompareValidator1" runat="server" 
                   ControlToValidate="passwordtextbox" ControlToCompare="newpasswordtextbox" ValidationGroup="r2"
                     EnableClientScript="false"></asp:CompareValidator>
                
                <div id="changepwd">
                    <asp:Button runat="server" id="confirm" Text="submit" OnClick="confirmPwd"/>
                    <asp:Button runat="server" Text="clear" OnClick="Unnamed1_Click" />
                </div>

            </div>

            
               

        </form>
    </div>

    <footer id="footer">
        
    </footer>

</body>
</html>
