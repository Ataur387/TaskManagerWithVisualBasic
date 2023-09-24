<%@ Page Title="" Language="VB" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage(Of List(Of MvcApplication1.Task))" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Tasks
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>List of Tasks</h2>
    <%= Html.ActionLink("Create", "Create")%>
    <% If Model.Count > 0 Then %>
    <table class="table">
        <thead>
            <tr>
                <th>Name</th>
                <th>Status</th>
                <th>Action</th>
            </tr>
        </thead>
        <tbody>
            <% For Each task In Model %>
                <tr>
                    <td><%= task.Name %></td>
                    <td><%= task.Status %></td>
                    <td>
                        <%-- Add action links or buttons here, e.g., Edit, Delete, Details --%>
                        <%= Html.ActionLink("Edit", "Edit", New With {.id = task.Id}) %>
                        <%= Html.ActionLink("Delete", "Delete", New With {.id = task.Id}) %>
                    </td>
                </tr>
            <% Next %>
        </tbody>
    </table>
<% Else %>
    <p>No tasks to display.</p>
<% End If %>


</asp:Content>
