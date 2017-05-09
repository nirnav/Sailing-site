<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Remove User.aspx.cs" Inherits="WebApplication1.ReFroEve" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Remove User</title>
</head>
<body>
    <a Href="Home.aspx">Return Home</a>
    <h3>
        Remove user from event
    </h3>
    <%=message %>
    <form id="form1" runat="server">
    <div>
    <input type="number" name="UId" placeholder="User ID" />
    </div>
    <div>
    <input type="number" name="EId" placeholder="Event ID" />
    </div>
    <div>
    <input type="submit" value="Remove"/>
    </div>
    </form>
</body>
</html>