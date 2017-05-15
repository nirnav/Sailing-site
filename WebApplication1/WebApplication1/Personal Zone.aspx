<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Personal Zone.aspx.cs" Inherits="WebApplication1.WebForm5" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Personal Zone</title>
     <script type="text/javascript">
         function validateForm() {

             var form = document.forms["signup"];
             var username = form["Username"].value;
             var email = form["Email"].value;
             var password = form["Password"].value;
             var password2 = form["Password2"].value;
             var check = true;

             if ((username.length < 3 || username.length > 24) && username.length!=0) {
                 alert("Your username should be between 6 and 24 characters long");
                 check = false;
             }
             if (password == "") {
                 alert("Enter your current password to confirm any changes");
                 check = false;
             }
             if (password2.length < 8 && password2.length != 0) {
                 alert("Your password should be 8 characters or more");
                 check = false;
             }
             if (!validateEmail(email) && email.length != 0) {
                 alert("Enter a valid email address");
                 check = false;
             }
             return check;

         }
        function validateEmail(email) {
            var re = /^(([^<>()\[\]\\.,;:\s@"]+(\.[^<>()\[\]\\.,;:\s@"]+)*)|(".+"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/;
            return re.test(email);
        }
    </script>
</head>
<body>
    <a href = "Sign Out.aspx"><u>Sign out </u></a><br />
    <a href = "Home.aspx"><u>Home Page</u></a><br />
    <a href = "Create Event.aspx"><u>Create Event </u></a><br />
    <a href = "Delete Event.aspx"><u>Delete Event </u></a><br />
    <a href = "Confirm.aspx"><u>Delete Account </u></a><br />
    <a href = "List Participants.aspx"><u>List Participants </u></a><br />
    <a href = "Leave Event.aspx"><u>Leave Event </u></a><br />
    <a href = "Remove User.aspx"><u>Remove a user from your event </u></a><br />
    <%=admin %>
    <h3>Enter any details you would like to change</h3>
    <form id="signup" runat="server" onsubmit="return validateForm()" method="post">
    <div>
        <input type="text" name="FullName" placeholder="Full Name" /><%=nm %>
    </div>
    <div>
        <input type="text" name="Username"  placeholder="Username" /><%=um %>
    </div>
    <div>
        <input type="text" name="Email" placeholder="E-mail" /><%=em %>
    </div>
    
    <div>
        <input type="password" name="Password2" placeholder="New password" /><%=npm %>
    </div>
    <div>
        <select name="Sclass" id="Sclass">
            <option value="NA">Choose a class</option>
            <option value="Laser 4.7">Laser 4.7</option>
            <option value="Laser Radial">Laser Radial</option>
            <option value="Laser Standard">Laser Standard</option>
            <option value="Optimist">Optimist</option>
            <option value="470">470</option>
            <option value="420">420</option>
            <option value="RS:X">RS:X</option>
        </select><%=cm %>
    </div>
        Enter your current password to confirm:
    <div>
        <input type="password" name="Password" placeholder="Current password" />
    </div>
    <div>
        <input type="submit" />
    </div><%=pm %>
    </form>
</body>
</html>
