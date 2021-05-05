<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ShowSections.aspx.cs" Inherits="TLDR_Capstone.ShowSections" %>

<!DOCTYPE html>

<html>
<head runat="server">
	<link rel="stylesheet" href="css/interior-stylesheet.css">
	<title>Catalog</title>
	<script type="text/javascript">
		function popAddWindow()
		{
			window.open("AddSection.aspx", "_blank", "width=400px, height=400px, alignment=center, left=400px, top=200px");
		}
	</script>
</head>
<body>
	<form id="form1" runat="server">
		<div style="text-align: center">
			<h1>Course Catalog</h1>
		</div>
		<div>
			<asp:Button ID="AddSection" runat="server" Text="Add Section" OnClientClick="return popAddWindow();" />
		</div>

		<div style="text-align: center">
			<asp:GridView ID="scheduleGridview" runat="server" AutoGenerateColumns="False" width="100%" DataSourceID="SqlDataSource1">
			<HeaderStyle CssClass="HeaderStyle" />
             <RowStyle CssClass="RowStyle" />
             <AlternatingRowStyle CssClass="AlternatingRowStyle" />
				<Columns>
					<asp:TemplateField>
						<ItemTemplate>
							<asp:CheckBox runat="server" ID="chkbox" />
						</ItemTemplate>
					</asp:TemplateField>
					<asp:BoundField DataField="deptID" HeaderText="deptID" SortExpression="deptID" />
					<asp:BoundField DataField="courseNumber" HeaderText="courseNumber" SortExpression="courseNumber" />
					<asp:BoundField DataField="courseTitle" HeaderText="courseTitle" SortExpression="courseTitle" />
					<asp:BoundField DataField="sectionID" HeaderText="sectionID" SortExpression="sectionID" />
					<asp:BoundField DataField="instructor" HeaderText="instructor" SortExpression="instructor" />
					<asp:BoundField DataField="days" HeaderText="days" SortExpression="days" />
					<asp:BoundField DataField="startTime" HeaderText="startTime" SortExpression="startTime" />
					<asp:BoundField DataField="endTime" HeaderText="endTime" SortExpression="endTime" />
				</Columns>
			</asp:GridView>
		</div>
		<asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:capstoneDatabaseConnectionString %>" SelectCommand="SELECT [deptID], [courseNumber], [courseTitle], [sectionID], [instructor], [days], [startTime], [endTime] FROM [Schedule]"></asp:SqlDataSource>
	</form>
</body>
</html>
