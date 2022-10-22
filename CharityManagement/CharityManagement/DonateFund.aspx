<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DonateFund.aspx.cs" Inherits="CharityManagement.DonateFund" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <center><h2>Donate the fund as per your interest</h2></center>
    <form id="form1" runat="server">
        <div>
            
       
            <br />
            <br />
            <br />
            
       
            You are donating for the user:
            <asp:Label ID="lbluserName" runat="server"></asp:Label>
            <br />
            <br />
            You are funding for the cause:
            <asp:Label ID="lblCause" runat="server"></asp:Label>
            <br />
            <br />
            
       
            <asp:Label ID="lblAmount" runat="server" Text="How much amount you want to funding?"></asp:Label>
            <br />
            <asp:TextBox ID="txtAmount" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidatorAmount" runat="server" ErrorMessage="Amount is required." ForeColor="Red" ControlToValidate="txtAmount"></asp:RequiredFieldValidator>
            <asp:RegularExpressionValidator ID="REVamount" runat="server" ControlToValidate="txtAmount" ErrorMessage="Please enter a valid amount." ForeColor="Red" ValidationExpression="^[0-9]+$"></asp:RegularExpressionValidator>
            <br />
            <br />
            <br />
            <br />
            <br />
            <asp:Button ID="btnDonateFund" runat="server" OnClick="btn_ClickDonateFund" Text="Submit" />
            
       
            <br />
            <br />
            <br />
            <br />
            <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/HomePage.aspx">Go to Home</asp:HyperLink>
       
            <br />
            <br />
            <asp:Button ID="btnLogout" runat="server" OnClick="btn_clickLogout" Text="Logout" />
       
        </div>
    </form>
</body>
</html>
