<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="List Participants.aspx.cs" Inherits="WebApplication1.List_Events" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Participants List</title>
</head>
<body>
    <a href = "Home.aspx"><u>Home Page</u></a>
    <form id="form1" runat="server">
    <div>
    <input type="text" name="EId" placeholder="Event ID" />
    </div>
        <div><input type="submit" value="List" /></div>
    </form>
    <table><%=table %></table>
</body>
</html>
