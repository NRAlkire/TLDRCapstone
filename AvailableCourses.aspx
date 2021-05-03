<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AvailableCourses.aspx.cs" Inherits="TLDR_Capstone.AvailableCourses" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Available Courses</title>
</head>
<body>
    <form id="form1" runat="server">
        <div style="text-align: center">
            <h2>Available Courses</h2>
        </div>
        <div>
			<asp:GridView ID="availableCoursesGV" runat="server" AutoGenerateColumns="False">
                <Columns>
					<asp:TemplateField>
						<ItemTemplate>
							<asp:CheckBox runat="server" ID="chkbox" />
						</ItemTemplate>
					</asp:TemplateField>
					<asp:BoundField DataField="Course"/>
                </Columns>
			</asp:GridView>
        </div>
        <div>
			<asp:Button ID="select" runat="server" Text="Select" OnClick="select_Click" />
        </div>
        <div>
			<asp:Label ID="selectedcourses" runat="server" Text="Label"></asp:Label>
        </div>
    </form>
</body>
</html>
