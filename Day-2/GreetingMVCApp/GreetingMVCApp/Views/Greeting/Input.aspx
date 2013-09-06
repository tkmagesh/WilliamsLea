<%@ Page Language="C#" Inherits="System.Web.Mvc.ViewPage" %>

<!DOCTYPE html>

<html>
<head runat="server">
    <title>Input</title
    <style type="text/css">
        .error {
            border: 1px solid red;
            background-color: lightpink;
        }
    </style>
</head>
<body>
    <%
        var firstName = (astring)ViewData["FirstName"];
        var lastName = (string)ViewData["LastName"];
        var validationResult = (Dictionary<string,string>) ViewData["ValidationResult"]; %>
    <form action="/Greeting/Greet" method="post">
        <div>
            First Name : <input type="text" name="firstName" id="firstName" value="<%= firstName %>" 
            class='<%= validationResult.ContainsKey("FirstName") ? "error" : "" %>'/>
            <% if (validationResult.ContainsKey("FirstName"))
               { %>
            <span><%= validationResult["FirstName"] %></span>
            <% } %>
        </div>
        <div>
            Last Name : <input type="text" name="lastName" id="lastName" value="<%= lastName %>"
            class='<%= validationResult.ContainsKey("LastName") ? "error" : "" %>'/>
            <% if (validationResult.ContainsKey("LastName"))
               { %>
            <span><%= validationResult["LastName"] %></span>
            <% } %>
        </div>
    <input type="submit" name="greet" value="Greet" />
    </form>
</body>
</html>
