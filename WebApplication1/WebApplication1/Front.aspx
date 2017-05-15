<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Front.aspx.cs" Inherits="WebApplication1.WebForm6" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Front Page</title>
</head>
<body>
    <h2<>Welcome to Saily</h2>
    <a href = "Sign Up.aspx"><u>Sign Up </u></a><br />
    <a href = "Sign In.aspx"><u>Sign In </u></a><br />
    You are visitor number <%=Application["Counter"]%>!
    <form id="form1" runat="server">
    <div>
    
    </div>
    </form>
</body>
</html>
