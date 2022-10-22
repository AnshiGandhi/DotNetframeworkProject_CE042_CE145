<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SignUp.aspx.cs" Inherits="CharityManagement.SignUp" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <asp:Label ID="lblname" runat="server" Text="Name"></asp:Label>
&nbsp;: <asp:RequiredFieldValidator ID="RequiredFieldValidatorname" runat="server" ControlToValidate="username" ErrorMessage="Name is required" ForeColor="Red"></asp:RequiredFieldValidator>
        <br />
        <asp:TextBox ID="username" runat="server"></asp:TextBox>
        <br />
        <asp:Label ID="lblemail" runat="server" Text="Email"></asp:Label>
&nbsp;: <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="email" ErrorMessage="Email is required" ForeColor="Red"></asp:RequiredFieldValidator>
        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="email" ErrorMessage="Enter a valid email address" ForeColor="Red" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
        <br />
        <asp:TextBox ID="email" runat="server"></asp:TextBox>
        <br />
        <asp:Label ID="lblphone" runat="server" Text="Phone"></asp:Label>
&nbsp;: <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="phone" ErrorMessage="Phone number is required" ForeColor="Red"></asp:RequiredFieldValidator>
        <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="phone" ErrorMessage="Enter a valid phone number" ForeColor="Red" ValidationExpression="^[0-9]{10}$"></asp:RegularExpressionValidator>
        <br />
        <asp:TextBox ID="phone" runat="server"></asp:TextBox>
        <br />
        <asp:Label ID="lblpassword" runat="server" Text="Password"></asp:Label>
&nbsp;: 
        <asp:RequiredFieldValidator ID="RequiredFieldValidatorPass" runat="server" ErrorMessage="Password is required." ForeColor="Red" ControlToValidate="confirm">Password is required.</asp:RequiredFieldValidator>
        <br />
        <asp:TextBox ID="password" runat="server" TextMode="Password"></asp:TextBox>
        <br />
        <asp:Label ID="lblconfirm" runat="server" Text="Confirm password"></asp:Label>
&nbsp;:
         <asp:CompareValidator ID="CompareValidator2" runat="server" 
         ControlToValidate="confirm"
         CssClass="ValidationError"
         ControlToCompare="password"
         ErrorMessage="Password does not match" ForeColor="Red" Display="Dynamic" >Password does not match.</asp:CompareValidator>
        .<br />
        <asp:TextBox ID="confirm" runat="server" TextMode="Password"></asp:TextBox>

        <br />
        <asp:Button ID="signup" runat="server" Text="Sign Up" OnClick="signup_Click" />
        <br />
        <asp:HyperLink ID="login_link" runat="server" NavigateUrl="~/Login.aspx">Already have an account?</asp:HyperLink>
    </form>
</body>
</html>
