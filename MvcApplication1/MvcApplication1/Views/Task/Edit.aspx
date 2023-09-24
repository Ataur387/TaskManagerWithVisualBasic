<%@ Page Title="" Language="VB" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage(Of MvcApplication1.Task)" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Edit
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Edit Task</h2>

    <% Using Html.BeginForm("Edit", "Task", FormMethod.Post)%>
        <div class="form-group">
            <label for="Name">Task Name:</label>
            <%= Html.TextBoxFor(Function(model) model.Name, New With {.class = "form-control"}) %>
        </div>

        <div class="form-group">
            <label for="Status">Status:</label>
            <%= Html.TextBoxFor(Function(model) model.Status, New With {.class = "form-control"}) %>
        </div>

        <button type="submit" class="btn btn-primary">Update Task</button>
    <% End Using %>
</asp:Content>

