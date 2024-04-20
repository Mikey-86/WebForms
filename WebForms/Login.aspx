<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="Login.aspx.cs" Inherits="WebForms.Login" Async="true" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <main>
        <section class="row" aria-labelledby="aspnetTitle">
            <h1 id="aspnetTitle">Login</h1>
            <br />
            <asp:Label ID="LabelUserName" runat="server" Text="User Name"></asp:Label>
            <asp:TextBox ID="usernametxt" runat="server" Width="250px"></asp:TextBox>

            <asp:Label ID="LabelPassword" runat="server" Text="Password"></asp:Label>
            <asp:TextBox ID="passwordtxt" TextMode="Password" runat="server" Width="250px"></asp:TextBox>

            <br />
            
        </section>
        <div class="row">
            <br />
            <asp:Button ID="btnLogin" runat="server" Text="Login" Width="250px" BackColor="SteelBlue" OnClick="Button1_Click" />
        </div>
       
    </main>

</asp:Content>
