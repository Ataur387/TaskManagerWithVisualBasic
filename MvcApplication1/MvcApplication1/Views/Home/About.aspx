<%@ Page Language="VB" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage(Of MvcApplication1.RegisterModel)" %>

<asp:Content ID="aboutTitle" ContentPlaceHolderID="TitleContent" runat="server">
    About Us
</asp:Content>

<asp:Content ID="aboutContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="about-container">
        <h2>About Us</h2>
        <div class="user-info">
            <p><strong>Full Name:</strong> <%= Model.Fullname %></p>
            <p><strong>Email:</strong> <%= Model.Email %></p>
        </div>
    </div>
</asp:Content>
