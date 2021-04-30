<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Schedules.aspx.cs" Inherits="TLDR_Capstone.Schedules" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
			<asp:Button ID="GenerateSchedules" runat="server" Text="Generate Schedules from Selected Courses" OnClick="GenerateSchedules_Click" />
        </div>
        <div>
			<asp:Label ID="schedules" runat="server" Text="Schedules go here."></asp:Label>
        </div>
    </form>
</body>
</html>
