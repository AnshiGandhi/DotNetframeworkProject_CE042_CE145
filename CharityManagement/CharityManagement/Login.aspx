<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="CharityManagement.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div class="auto-style1">
            <asp:Label ID="lblusername" runat="server" Text="Username"></asp:Label>
&nbsp;: <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="username" ErrorMessage="Username is required" ForeColor="Red"></asp:RequiredFieldValidator>
            <br />
            <asp:TextBox ID="username" runat="server"></asp:TextBox>
            <br />
            <asp:Label ID="lblpassword" runat="server" Text="Password"></asp:Label>
&nbsp;:<asp:RequiredFieldValidator ID="RequiredFieldValidatorPass" runat="server" ControlToValidate="password" ErrorMessage="Password is required." ForeColor="Red"></asp:RequiredFieldValidator>
            <br />
            <asp:TextBox ID="password" runat="server" TextMode="Password"></asp:TextBox>
            <br />
            <br />
            <asp:Button ID="btn_login" runat="server" Text="Login" OnClick="btn_login_Click" />
            <br />
            <asp:HyperLink ID="signup_link" runat="server" NavigateUrl="~/SignUp.aspx">Don&#39;t have an account?</asp:HyperLink>
        </div>
    </form>
</body>
</html>
