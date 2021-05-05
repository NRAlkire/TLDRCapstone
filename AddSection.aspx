<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddSection.aspx.cs" Inherits="TLDR_Capstone.AddSection" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body onunload="opener.location.reload();">
    <form id="form1" runat="server">
        <div style="text-align: center">
        	<asp:Label ID="deptID" runat="server" Text="Dept ID" Width="100px"></asp:Label>
			<asp:TextBox ID="deptIDTB" runat="server"></asp:TextBox>
			<br />
			<asp:Label ID="courseNum" runat="server" Text="Course #" Width="100px"></asp:Label>
			<asp:TextBox ID="courseNumTB" runat="server"></asp:TextBox>
			<br />
			<asp:Label ID="courseTitle" runat="server" Text="Course Title" Width="100px"></asp:Label>
			<asp:TextBox ID="courseTitleTB" runat="server"></asp:TextBox>
        	<br />
        	<asp:Label ID="sectionID" runat="server" Text="Section ID" Width="100px"></asp:Label>
			<asp:TextBox ID="sectionIDTB" runat="server"></asp:TextBox>
			<br />
			<asp:Label ID="instructor" runat="server" Text="Instructor" Width="100px"></asp:Label>
			<asp:TextBox ID="instructorTB" runat="server"></asp:TextBox>
			<br />
			<asp:Label ID="days" runat="server" Text="Course Days" Width="100px"></asp:Label>
			<asp:TextBox ID="daysTB" runat="server"></asp:TextBox>
			<br />
			<asp:Label ID="start" runat="server" Text="Start Time" Width="100px"></asp:Label>
			<asp:TextBox ID="startTB" runat="server"></asp:TextBox>
			<br />
			<asp:Label ID="end" runat="server" Text="End Time" Width="100px"></asp:Label>
			<asp:TextBox ID="endTB" runat="server"></asp:TextBox>
        </div>
		<div style="text-align:center">
			<asp:Button ID="Save" runat="server" Text="Add Section" width="75px" OnClick="Save_Click"/>
		</div>
	</form>
</body>
</html>
