<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WebApp._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="jumbotron">
        <h1>ASP.NET</h1>
         <meta property="og:title" content="The Rock" />
         <meta property="og:url" content="www.abv.bg" />
        <div class="fb-share-button"
            data-href="https://developers.facebook.com/docs/plugins/"  data-layout="button_count">
          
        </div>
        <%-- <asp:Button ID="ButtonFb" runat="server" Text="Post To FB" OnClick="ButtonFb_Click"/>--%>
    </div>
</asp:Content>
