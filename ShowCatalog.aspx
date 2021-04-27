<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ShowCatalog.aspx.cs" Inherits="TLDR_Capstone.ShowCatalog" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
	<title>Catalog</title>
</head>
<body>
	<form id="form1" runat="server">
		<div style="text-align: center">
			<h2>Course Catalog</h2>
		</div>
		<div>
			<h4>
				<asp:Label ID="userandlvl" runat="server" Text="Label"></asp:Label></h4>
		</div>
		<div style="text-align: center">
			<asp:GridView ID="catalogGridview" runat="server" AutoGenerateColumns="False" DataSourceID="SqlDataSource1" OnSelectedIndexChanged="catalogGridview_SelectedIndexChanged">
				<Columns>
					<asp:TemplateField>
						<ItemTemplate>
							<asp:CheckBox runat="server" ID="chk_box" />
						</ItemTemplate>
					</asp:TemplateField>
					<asp:BoundField DataField="deptID" SortExpression="deptID" />
					<asp:BoundField DataField="courseNumber" SortExpression="courseNumber" />
					<asp:BoundField DataField="courseTitle" SortExpression="courseTitle" />
				</Columns>
			</asp:GridView>
		</div>
		<asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:capstoneDatabase%>" SelectCommand="SELECT DISTINCT [deptID], [courseNumber], [courseTitle] FROM [Schedule]"></asp:SqlDataSource>
	</form>
</body>
</html>
