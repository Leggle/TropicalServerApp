<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="TropicalServer.UI.Login" %>

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
        <form id="BodyDetail" name="myForm" onsubmit="return validateForm()" action="http://www.google.com">
            <h1 id="Loginlbl">MOBILE CUSTOMER ORDER TRACKING</h1>
            <div id="loginBox">
                <label id="useridlbl">Login ID</label>
                <input id="useridtextbox" type="text" name="userid" />
                <label id="passwordlbl">Password</label>
                <input id="passwordtextbox" type="password" name="userpassword" />

                <div id="login">
                    <label style="color:gray">Remember my ID</label><input type="checkbox" value="RememberMyID" />
                    <input type="submit" id="loginButton" value="Login-In"/>
                </div>
            </div>
            <div style="padding-top:10px">
                <a href="#" id="forgotUsername">Forgot Username</a>
                <a href="ForgotPassword.aspx" id="forgotPassword">Forgot Password</a>
            </div>

        </form>
    </div>

    <footer id="footer">
        
    </footer>

</body>
</html>
