<%@  Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="Teams.aspx.cs" Inherits="WebForms.WebForm1" Async="true" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <main>
        <section class="row" aria-labelledby="aspnetTitle">
        <h1 id="aspnetTitle">Add A New Team</h1>
        <br />

        <asp:Label ID="Label1" runat="server" Text="Team Name"></asp:Label>
        <asp:TextBox ID="txtName" runat="server" Width="250px"></asp:TextBox>

        <asp:Label ID="Label2" runat="server" Text="Created Date"></asp:Label>
        <asp:TextBox ID="txtCreatedDate" runat="server" Width="250px"></asp:TextBox>

        <asp:Label ID="Label4" runat="server" Text="Is Active?"></asp:Label>
            <div>
        <asp:CheckBox ID="chkActive" runat="server" TextAlign="Left" />
        </div>
        <br />
        </section>
    <div class="row">
        <asp:Button ID="btnSubmit" runat="server" Text="Submit" Width="250px" BackColor="GreenYellow" OnClick="Button1_Click" />
        <asp:Label ID="lblWorking" ForeColor="Red" runat="server" Text=""></asp:Label>
    </div>
    </main>
    
</asp:Content>