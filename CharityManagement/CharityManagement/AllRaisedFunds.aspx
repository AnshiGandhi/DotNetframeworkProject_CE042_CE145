<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AllRaisedFunds.aspx.cs" Inherits="CharityManagement.AllRaisedFunds" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="lblName" runat="server" Text="Label"></asp:Label>
            <br />
            <asp:GridView ID="GridViewRF" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None" AutoGenerateColumns="False" AutoGenerateSelectButton="True" SelectedIndex="1" OnSelectedIndexChanging="OnRowSelected" DataSourceID="usersRaisedfunds" DataKeyNames="name,cause">
                <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                
                <Columns>
             <asp:BoundField DataField="name" 
                 HeaderText="name" 
                 SortExpression="name" />
             <asp:BoundField DataField="total_amount" 
                 HeaderText="total_amount" 
                 SortExpression="total_amount" />
             <asp:BoundField DataField="cause" 
                 HeaderText="cause" 
                 SortExpression="cause" />
             <asp:BoundField DataField="raising_for" 
                 HeaderText="raising_for" 
                 SortExpression="raising_for" />
             <asp:BoundField DataField="description" 
                 HeaderText="description" 
                 SortExpression="description" />
                    <asp:BoundField DataField="gathered_amount" 
                 HeaderText="gathered_amount" 
                 SortExpression="gathered_amount" />
                    <asp:BoundField DataField="status" 
                 HeaderText="status" 
                 SortExpression="status" />
                    <asp:TemplateField HeaderText="Image">
                        <ItemTemplate>
                            <img src="Images/<%#Eval("photo") %>" style="width:80px; height:100px;"/>
                        </ItemTemplate>
                    </asp:TemplateField>
         </Columns>
                
       <selectedrowstyle backcolor="LightCyan"
         forecolor="DarkBlue"
         font-bold="true"/>

                <EditRowStyle BackColor="#999999" />
                <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                <SortedAscendingCellStyle BackColor="#E9E7E2" />
                <SortedAscendingHeaderStyle BackColor="#506C8C" />
                <SortedDescendingCellStyle BackColor="#FFFDF8" />
                <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
            </asp:GridView>
            <br />
            <br />
            <asp:SqlDataSource ID="usersRaisedfunds" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" SelectCommand="Select users.name, rf.total_amount, rf.cause, rf.raising_for, rf.description, rf.gathered_amount, rf.status,rf.photo from raisefunds as rf  INNER JOIN users ON rf.userId = users.u_id where rf.status = 'pending'"></asp:SqlDataSource>
            <br />
        </div>
        <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/HomePage.aspx">Go to Home</asp:HyperLink>
        <br />
        <br />
        <asp:Button ID="btnLogout" runat="server" OnClick="btn_clickLogout" Text="Logout" />
    </form>
</body>
</html>
