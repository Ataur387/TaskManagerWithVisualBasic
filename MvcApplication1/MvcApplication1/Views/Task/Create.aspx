<%@ Page Title="" Language="VB" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Create
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Create a Task</h2>

    <% Using Html.BeginForm("Create", "Task", FormMethod.Post) %>
        <div class="form-group">
            <label for="Name">Task Name:</label>
            <%= Html.TextBox("Name", Nothing, New With {.class = "form-control"}) %>
        </div>

        <button type="submit" class="btn btn-primary">Create Task</button>
    <% End Using %>
</asp:Content>
