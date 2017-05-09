<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="WebApplication1.index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Home Page</title>
</head>
<body>
    <h3><%=message%></h3>
    <a href ="Sign Out.aspx">Sign out </a><br />
    <a href ="Personal Zone.aspx">Personal Zone </a>
    <br/>
    <h4>Enter your sail number and tick the events you want to compete in to sign up.</h4>
    <h5><%=success %><br /><%=fail %></h5>
    <form id="signin" runat="server">
       <div><input type="number" name="sailn" Placeholder="Sail number"/></div>
         <div><input type="submit" /></div>
      <h3><%=sclass %> Events</h3>
        <table border="1"><%=table %></table>   
    </form>
</body>
</html>
