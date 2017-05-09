<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Delete Event.aspx.cs" Inherits="WebApplication1.Delete_Event" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <%=message %>
    <form id="form1" runat="server">
    <div>
    <input type="number" name="EId" placeholder="Event ID" />
    </div>
    <div>
    <input type="submit" value="Delete"/>
    </div>
    </form>
</body>
</html>
