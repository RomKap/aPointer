<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeBehind="Default.aspx.cs" Inherits="WebApp._Default" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <h2>
        Welcome 
    </h2>
    
    <p>
       <asp:GridView ID="GRV1" runat="server" AutoGenerateColumns="true">
    </asp:GridView>
    </p>

    <div>
    First Name: <asp:TextBox ID="txtFirstName" runat="server"></asp:TextBox><br />
    Last Name: <asp:TextBox ID="txtLastName" runat="server"></asp:TextBox><br />   
        <asp:Button ID="Submit" runat="server" Text="Submit" onclick="Submit_Click" />
    </div>
    
</asp:Content>
