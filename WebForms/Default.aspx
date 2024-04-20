<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WebForms._Default" Async="true" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <main>
        <section class="row" aria-labelledby="aspnetTitle">
            <h1 id="aspnetTitle">Player Registration</h1>
            <br />
            <asp:Label ID="LabelFirstName" runat="server" Text="First Name"></asp:Label>
            <asp:TextBox ID="firstNametxt" runat="server" Width="250px"></asp:TextBox>

            <asp:Label ID="LabelLastName" runat="server" Text="Last Name"></asp:Label>
            <asp:TextBox ID="lastNametxt" runat="server" Width="250px"></asp:TextBox>

            <asp:Label ID="Label3" runat="server" Text="Age"></asp:Label>
            <asp:TextBox ID="agetxt" runat="server" Width="250px"></asp:TextBox>

            <asp:Label ID="Label4" runat="server" Text="ID Number"></asp:Label>
            <asp:TextBox ID="IDNumtxt" runat="server" Width="250px"></asp:TextBox>

            <asp:Label ID="Label5" runat="server" Text="Address"></asp:Label>
            <asp:TextBox ID="addresstxt" runat="server" Width="250px"></asp:TextBox>

            <asp:Label ID="Label6" runat="server" Text="Desired Team"></asp:Label>
            <asp:DropDownList ID="teamDropDown" runat="server" AppendDataBoundItems="true">
            </asp:DropDownList>
            <br />
            
        </section>
        <div class="row">
            <asp:Button ID="btnSubmit" runat="server" Text="Submit" Width="250px" BackColor="GreenYellow" OnClick="Button1_Click" />
            <asp:Label ID="LabelWorking" ForeColor="Red" runat="server" Text=""></asp:Label>
        </div>
       
    </main>

</asp:Content>
