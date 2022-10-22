<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RaiseFund.aspx.cs" Inherits="CharityManagement.RaiseFund" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <br />
        <br />
        <asp:Label ID="Label1" runat="server" Font-Bold="True" Font-Names="Bahnschrift" Text="Start A Fundraiser For Free"></asp:Label>
        <br />
        <br />
        <asp:Label ID="lblAmount" runat="server" Text="*How much do you want to raise :"></asp:Label>
        &nbsp;<asp:CompareValidator ID="CompareValidator2" runat="server" ControlToValidate="amount" EnableClientScript="False" ErrorMessage="Amount must be greater than 500" ForeColor="Red" Operator="GreaterThanEqual" Type="Integer" ValueToCompare="500"></asp:CompareValidator>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="amount" ErrorMessage="Amount is required" ForeColor="Red"></asp:RequiredFieldValidator>
        <br />
        <asp:TextBox ID="amount" runat="server" ></asp:TextBox>
        <br />
        <asp:Label ID="lblCause" runat="server" Text="*For what cause are you raising :"></asp:Label>
        &nbsp;<asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="cause" ErrorMessage="Cause must be required" ForeColor="Red"></asp:RequiredFieldValidator>
        <br />
        <asp:DropDownList ID="cause" runat="server">
            <asp:ListItem>Orphans</asp:ListItem>
            <asp:ListItem>Poor and needy</asp:ListItem>
            <asp:ListItem>Personal Cause</asp:ListItem>
            <asp:ListItem>Environment</asp:ListItem>
            <asp:ListItem>Other</asp:ListItem>
        </asp:DropDownList>
        <br />
        <asp:Label ID="lblPerson" runat="server" Text="For Whom are you raising for :"></asp:Label>
        <br />
        <asp:TextBox ID="person" runat="server"></asp:TextBox>
        <br />
        <asp:Label ID="lbldescription" runat="server" Text="Description"></asp:Label>
        &nbsp;:
        <br />
        <textarea id="desc" runat="server" cols="20" maxlength="250" name="S1" rows="2"></textarea><br />
        <asp:Label ID="lblImage" runat="server" Text="Add images :"></asp:Label>
        &nbsp;<asp:Label ID="lblmsg" runat="server"></asp:Label>
        <br />
        <asp:FileUpload ID="FileUploadimage" runat="server" />
        <br />
        <!--<asp:FileUpload multiple="multiple" ID="image" OnServerValidate="ValidateFileSize" runat="server" AllowMultiple="True" />
        --><br />
        <asp:Button ID="ButtonRaiseFund" runat="server" OnClick="btn_clickRaiseFund" Text="Raise Fund" />
        <br />
        <br />
        <br />

        <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/HomePage.aspx">Go to Home</asp:HyperLink>
        <br />
        <br />
        <asp:Button ID="btnLogout" runat="server" OnClick="btn_clickLogout" Text="Logout" />
    </form>
</body>
</html>
