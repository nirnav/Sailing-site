<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Leave Event.aspx.cs" Inherits="WebApplication1.Leave_Event" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Leave Event</title>
</head>
<body>
    <a href = "Home.aspx"><u>Home Page</u></a>
    <h3>Leave Event</h3>
    <form id="form1" runat="server">
    <div>
    <input type="number" name="EId" placeholder="Event ID" />
    </div>
    <div>
    <input type="submit" value="Leave"/>
    </div>
    </form>
</body>
</html>
