<%@ Page Language="VB" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage" %>

<asp:Content ID="indexTitle" ContentPlaceHolderID="TitleContent" runat="server">
    Home Page
</asp:Content>

<asp:Content ID="indexContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: ViewData("Message") %></h2>
    <p>
        This is a simple Task Management CRUD Service built on ASP.NET MVC 2 template. As an user you can Log On And List out the tasks, change their status, update and delete them.
    </p>
</asp:Content>
