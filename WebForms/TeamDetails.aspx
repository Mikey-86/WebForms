<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" Async="true" CodeBehind="TeamDetails.aspx.cs" Inherits="WebForms.TeamDetails" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <main>
        <section class="row" aria-labelledby="aspnetTitle">
            <h1 id="aspnetTitle">Players By Team</h1>
            <asp:DropDownList ID="TeamDropDownList" runat="server" AppendDataBoundItems="true" AutoPostBack="True" OnSelectedIndexChanged="TeamDropDownList_SelectedIndexChanged">
            </asp:DropDownList>
            <br />
            <asp:GridView ID="PlayerGridView" runat="server"></asp:GridView>
            
        </section>
        <div class="row">
            <asp:Label ID="LabelWorking" runat="server" Text=""></asp:Label>
        </div>
       
    </main>

</asp:Content>
