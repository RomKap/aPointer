<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeBehind="Default.aspx.cs" Inherits="WebApp._Default" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <h2>
        Welcome 
    </h2>
    
    <p>
       <asp:GridView ID="GRV1" runat="server" AutoGenerateColumns="false" OnRowCommand="GRV1_RowCommand">
       <Columns>
       <asp:BoundField HeaderText="ID" DataField="ApteeID" HeaderStyle-Width="10%" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" />
       <asp:BoundField HeaderText="First Name" DataField="FirstName" HeaderStyle-Width="30%" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left" />
       <asp:BoundField HeaderText="Last Name" DataField="LastName"  HeaderStyle-Width="30%" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left"  />
       <asp:TemplateField HeaderText="Action" >
       <ItemTemplate>
       <asp:LinkButton runat="server" Text="Delete" CommandArgument='<%# Eval("ApteeID") %>'  CommandName="DelAppointee" ></asp:LinkButton>
       
       </ItemTemplate>
       </asp:TemplateField>
       </Columns>
    </asp:GridView>
    </p>

    <div>
    First Name: <asp:TextBox ID="txtFirstName" runat="server"></asp:TextBox><br />
    Last Name: <asp:TextBox ID="txtLastName" runat="server"></asp:TextBox><br />   
        <asp:Button ID="Submit" runat="server" Text="Submit" onclick="Submit_Click" />
    </div>
    
</asp:Content>
