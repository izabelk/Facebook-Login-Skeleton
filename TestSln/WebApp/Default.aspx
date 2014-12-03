<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WebApp._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="jumbotron">
        <h1>ASP.NET</h1>
        <a id="lnkFacebook" target="_blank" runat="server">Facebook Share</a>
       <%-- <div class="fb-share-button"
            data-href="https://developers.facebook.com/docs/plugins/"  data-layout="button_count">
          --%>
        <%--</div>--%>
        <%-- <asp:Button ID="ButtonFb" runat="server" Text="Post To FB" OnClick="ButtonFb_Click"/>--%>
        <a runat="server" href="https://www.facebook.com/dialog/feed?app_id=795170443855153&link=https://developers.facebook.com/docs/reference/dialogs/&picture=http://fbrell.com/f8.jpg&name=Izi%20Dialogs&caption=Reference%20Documentation&description=Izi%20Dialogs%20to%20interact%20with%20users.&redirect_uri=http://localhost:55534/Default.aspx/&display=popup">Izi</a>
    </div>
</asp:Content>
