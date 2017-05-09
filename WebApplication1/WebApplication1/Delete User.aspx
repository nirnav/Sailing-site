<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Delete User.aspx.cs" Inherits="WebApplication1.Delete_User" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <a href = "Home.aspx"><u>Home Page </u></a>
    <a href = "For Admin.aspx"><u>Admin Page </u></a>
    <h3>Enter a user name or an id to delete it.</h3>
    <%=message %>
    <form id="form1" runat="server">
    <div>
    <input type="number" name="UId" placeholder="User ID" />
    </div>
    <div>
    <input type="number" name="UserN" placeholder="Username" />
    </div>
    <div>
    <input type="submit" value="Delete"/>
    </div>
    </form>
</body>
</html>
