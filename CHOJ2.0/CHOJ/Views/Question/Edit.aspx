<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<CHOJ.Models.Question>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Edit</h2>

    <%= Html.ValidationSummary("Edit was unsuccessful. Please correct the errors and try again.") %>

    <% using (Html.BeginForm()) {%>

        <fieldset>
            <legend>Fields</legend>
            <p>
                <label for="Id">Id:</label>
                <%= Html.TextBox("Id", Model.Id) %>
                <%= Html.ValidationMessage("Id", "*") %>
            </p>
            <p>
                <label for="Title">Title:</label>
                <%= Html.TextBox("Title", Model.Title) %>
                <%= Html.ValidationMessage("Title", "*") %>
            </p>
            <p>
                <label for="Body">Body:</label>
                <%= Html.TextBox("Body", Model.Body) %>
                <%= Html.ValidationMessage("Body", "*") %>
            </p>
            <p>
                <label for="TimeLimit">TimeLimit:</label>
                <%= Html.TextBox("TimeLimit", Model.TimeLimit) %>
                <%= Html.ValidationMessage("TimeLimit", "*") %>
            </p>
            <p>
                <label for="MemoryLimit">MemoryLimit:</label>
                <%= Html.TextBox("MemoryLimit", Model.MemoryLimit) %>
                <%= Html.ValidationMessage("MemoryLimit", "*") %>
            </p>
            <p>
                <label for="AcceptedCount">AcceptedCount:</label>
                <%= Html.TextBox("AcceptedCount", Model.AcceptedCount) %>
                <%= Html.ValidationMessage("AcceptedCount", "*") %>
            </p>
            <p>
                <label for="SubmitCount">SubmitCount:</label>
                <%= Html.TextBox("SubmitCount", Model.SubmitCount) %>
                <%= Html.ValidationMessage("SubmitCount", "*") %>
            </p>
            <p>
                <label for="UserId">UserId:</label>
                <%= Html.TextBox("UserId", Model.UserId) %>
                <%= Html.ValidationMessage("UserId", "*") %>
            </p>
            <p>
                <label for="AddTime">AddTime:</label>
                <%= Html.TextBox("AddTime", String.Format("{0:g}", Model.AddTime)) %>
                <%= Html.ValidationMessage("AddTime", "*") %>
            </p>
            <p>
                <label for="GroupId">GroupId:</label>
                <%= Html.TextBox("GroupId", Model.GroupId) %>
                <%= Html.ValidationMessage("GroupId", "*") %>
            </p>
            <p>
                <label for="IsTrue">IsTrue:</label>
                <%= Html.TextBox("IsTrue", Model.IsTrue) %>
                <%= Html.ValidationMessage("IsTrue", "*") %>
            </p>
            <p>
                <label for="Test">Test:</label>
                <%= Html.TextBox("Test", Model.Test) %>
                <%= Html.ValidationMessage("Test", "*") %>
            </p>
            <p>
                <input type="submit" value="Save" />
            </p>
        </fieldset>

    <% } %>

    <div>
        <%=Html.ActionLink("Back to List", "Index") %>
    </div>

</asp:Content>

