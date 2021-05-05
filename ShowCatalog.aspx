﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ShowCatalog.aspx.cs" Inherits="TLDR_Capstone.ShowCatalog" %>

<!DOCTYPE html>

<html>
<head runat="server">
	<link rel="stylesheet" href="css/interior-stylesheet.css">
	<title>Catalog</title>
	<script type="text/javascript">
		function popAddWindow()
		{
			window.open("AddCourse.aspx", "_blank", "width=400px, height=200px, alignment=center, left=400px, top=200px");
		}
	</script>
</head>
<body>
	<form id="form1" runat="server">
		<div style="text-align: center">
			<h1>Course Catalog</h1>
		</div>
		<div>
			<asp:Button ID="AddCourse" runat="server" Text="Add Course" OnClientClick="return popAddWindow();" />
		</div>
		<div>
			<h4><asp:Label ID="userandlvl" runat="server" Text="Label"></asp:Label></h4>
		</div>
		<div style="text-align: center">
			<asp:GridView ID="catalogGridview" runat="server" AutoGenerateColumns="False" width="100%" DataSourceID="SqlDataSource1">
			<HeaderStyle CssClass="HeaderStyle" />
             <RowStyle CssClass="RowStyle" />
             <AlternatingRowStyle CssClass="AlternatingRowStyle" />
				<Columns>
					<asp:TemplateField>
						<ItemTemplate>
							<asp:CheckBox runat="server" ID="chkbox" />
						</ItemTemplate>
					</asp:TemplateField>
					<asp:BoundField DataField="deptID" SortExpression="deptID" />
					<asp:BoundField DataField="courseNumber" SortExpression="courseNumber" />
					<asp:BoundField DataField="courseTitle" SortExpression="courseTitle" />
				</Columns>
			</asp:GridView>
		</div>
		<asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:capstoneDatabaseConnectionString %>" SelectCommand="SELECT * FROM [Catalog]"></asp:SqlDataSource>

		<div>
			<asp:Button class="submit-btn" ID="selectBtn" runat="server" Text="Select" OnClick="selectBtn_Click" /><br />
		</div>
		<div>
			<h4>
				<asp:Label ID="selected" runat="server" Text="Selected Courses"></asp:Label></h4><br />
		</div>
	</form>
</body>
</html>
