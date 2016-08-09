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
    <form id="header" runat="server">
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
        <form id="BodyDetail" name="myForm" >
            <h1 id="Loginlbl">MOBILE CUSTOMER ORDER TRACKING</h1>
            <div id="loginBox">
                <label id="useridlbl">Login ID</label>
                <input id="useridtextbox" type="text" name="userid" />
                <label id="oldpasswordlbl">Old Password</label>
                <input id="passwordtextbox" type="password" name="userpassword" />
                <label id="newpsdlbl">New Password</label>
                <input id="newpasswordtextbox" type="password" name="userpassword" />

                <div id="changepwd">
                    <input id="confirm" type="submit" value="confirm" />
                    <input type="button" value="cancel" onclick="location.href='Login.aspx'"/>
                </div>

            </div>

            
               

        </form>
    </div>

    <footer id="footer">
        
    </footer>

</body>
</html>
