<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Confirm.aspx.cs" Inherits="WebApplication1.Confirm" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <h3>Enter your password to delete your account</h3>
    <%=message %>
    <form id="form1" runat="server">
    <div>
    <input type="password" name="pass" placeholder="password" />
    </div>
    <div>
    <input type="submit" value="Delete"/>
    </div>
    </form>
</body>
</html>
