<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddCourse.aspx.cs" Inherits="TLDR_Capstone.AddCourse" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div style="text-align: center">
        	<asp:Label ID="Label1" runat="server" Text="Dept ID" Width="100px"></asp:Label>
			<asp:TextBox ID="deptIDTB" runat="server"></asp:TextBox>
			<br />
			<asp:Label ID="Label2" runat="server" Text="Course #" Width="100px"></asp:Label>
			<asp:TextBox ID="courseNumTB" runat="server"></asp:TextBox>
			<br />
			<asp:Label ID="Label3" runat="server" Text="Course Title" Width="100px"></asp:Label>
			<asp:TextBox ID="courseTitleTB" runat="server"></asp:TextBox>
        </div>
		<div style="text-align:center">
			<asp:Button ID="Save" runat="server" Text="Add Course" width="75px" OnClick="Save_Click"/>
		</div>
	</form>
</body>
</html>
