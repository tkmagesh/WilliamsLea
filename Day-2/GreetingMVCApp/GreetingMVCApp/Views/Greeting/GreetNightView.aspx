<%@ Page Language="C#" Inherits="System.Web.Mvc.ViewPage" %>

<!DOCTYPE html>

<html>
<head runat="server">
    <title>GreetNightView</title>
</head>
<body>
    <div>
        <h1 style="color:red">Hi there!!! <%=this.ViewData["greetMsg"] %></h1>
    </div>
</body>
</html>
