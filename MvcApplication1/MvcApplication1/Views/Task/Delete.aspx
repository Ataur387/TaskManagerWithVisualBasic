<%@ Page Title="" Language="VB" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage(Of MvcApplication1.Task)" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Delete
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Delete Task</h2>

    <p>Are you sure you want to delete the following task?</p>

    <dl class="dl-horizontal">
        <dt>Task Name:</dt>
        <dd><%= Model.Name %></dd>

        <dt>Status:</dt>
        <dd><%= Model.Status %></dd>
    </dl>

<form action='<%= Url.Action("Delete", "Task", New With {.id = Model.Id}) %>' method="post">
    <button type="submit" class="btn btn-danger">Confirm Delete</button>
</form>


    <a href="@Url.Action("Index", "Task")" class="btn btn-default">Back</a>
</asp:Content>
